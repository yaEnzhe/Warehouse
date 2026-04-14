using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;

namespace WarehouseApp.Forms
{
    public partial class CatalogAdminForm : Form
    {
        private BindingList<Products> allProducts;
        private ComboBox _currentCombo;

        public CatalogAdminForm()
        {
            InitializeComponent();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            try
            {
                List<Categories> categoriesList;
                List<UnitOfMeasure> unitsList;
                using (var db = new WarehouseContext())
                {
                    categoriesList = db.Categories.ToList();
                    unitsList = db.UnitOfMeasure.ToList();
                }
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv.RowTemplate.Height = 30;
                dgv.GridColor = Color.Black;
                dgv.AllowUserToAddRows = false;
                dgv.AutoGenerateColumns = false;

                dgv.Columns.Add("Article", "Артикул");
                dgv.Columns["Article"].DataPropertyName = "Article";
                dgv.Columns["Article"].ReadOnly = true;

                dgv.Columns.Add("NameProduct", "Название");
                dgv.Columns["NameProduct"].DataPropertyName = "NameProduct";

                var comboCol = new DataGridViewComboBoxColumn
                {
                    Name = "Category",
                    HeaderText = "Категория",
                    DataSource = categoriesList,
                    DisplayMember = "NameCategory",
                    ValueMember = "IdCategories",
                    DataPropertyName = "IdCategories",
                    DisplayStyleForCurrentCellOnly = true,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                };
                dgv.Columns.Add(comboCol);

                var comboUnit = new DataGridViewComboBoxColumn
                {
                    Name = "UnitOfMeasure",
                    HeaderText = "Ед. измерений",
                    DataSource = unitsList,
                    DisplayMember = "NameUnit",
                    ValueMember = "IdUnit",
                    DataPropertyName = "IdUnitOfMeasure",
                    DisplayStyleForCurrentCellOnly = true
                };
                dgv.Columns.Add(comboUnit);

                dgv.Columns.Add("Price", "Цена закупки");
                dgv.Columns["Price"].DataPropertyName = "Price";

                dgv.Columns.Add("Stock", "Остаток");
                dgv.Columns["Stock"].DataPropertyName = "Stock";

                dgv.CellFormatting += dgv_CellFormatting;
                dgv.DataError += dgv_DataError;
                dgv.CellValidating += dgv_CellValidating;
                dgv.CellClick += dgv_CellClick;
                LoadData();
                dgv.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запуска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void LoadData()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    allProducts = new BindingList<Products>(db.Products
                        .Include("Category")
                        .Include("UnitOfMeasure")
                        .ToList());
                }
                dgv.DataSource = allProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonForEdit_Click(object sender, EventArgs e)
        {
            if (buttonForEdit.Text == "Редактировать")
            {
                dgv.ReadOnly = false;
                buttonForEdit.Text = "Сохранить";
                if (dgv.Rows.Count > 0 && dgv.Columns.Contains("NameProduct"))
                {
                    dgv.CurrentCell = dgv.Rows[0].Cells["NameProduct"];
                }
            }
            else
            {
                dgv.EndEdit();
                try
                {
                    using (var db = new WarehouseContext())
                    {
                        foreach (var item in allProducts)
                        {
                            var existing = db.Products.Find(item.IdProducts);

                            if (existing == null)
                            {
                                db.Products.Add(new Products
                                {
                                    IdProducts = item.IdProducts,
                                    Article = item.Article,
                                    NameProduct = item.NameProduct,
                                    Price = item.Price,
                                    Stock = item.Stock,
                                    IdCategories = item.Category?.IdCategories ?? Guid.Empty,
                                    IdUnitOfMeasure = item.UnitOfMeasure?.IdUnit ?? Guid.Empty
                                });
                            }
                            else
                            {
                                existing.NameProduct = item.NameProduct;
                                existing.Price = item.Price;
                                existing.Stock = item.Stock;
                                existing.IdCategories = item.Category?.IdCategories ?? existing.IdCategories;
                                existing.IdUnitOfMeasure = item.UnitOfMeasure?.IdUnit ?? existing.IdUnitOfMeasure;
                            }
                        }
                        db.SaveChanges();
                    }
                    MessageBox.Show("Сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}\n{ex.InnerException?.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dgv.ReadOnly = true;
                    buttonForEdit.Text = "Редактировать";
                }
            }
        }

        private void buttonToAddGood_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var cat = db.Categories.FirstOrDefault();
                    var unit = db.UnitOfMeasure.FirstOrDefault();

                    if (cat == null || unit == null)
                    {
                        MessageBox.Show("Нет категорий или единиц измерения в базе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string newArticle = db.GenerateNextArticle();
                    var newProd = new Products
                    {
                        IdProducts = Guid.NewGuid(),
                        Article = newArticle,
                        NameProduct = "Новый товар",
                        Price = 0,
                        Stock = 0,
                        IdCategories = cat.IdCategories,
                        IdUnitOfMeasure = unit.IdUnit
                    };

                    db.Products.Add(newProd);
                    db.SaveChanges();
                }
                LoadData();
                dgv.ReadOnly = false;
                buttonForEdit.Text = "Сохранить";
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.DataBoundItem is Products p && p.NameProduct == "Новый товар")
                    {
                        dgv.CurrentCell = row.Cells["NameProduct"];
                        dgv.BeginEdit(true);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonForDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var prod = dgv.CurrentRow.DataBoundItem as Products;
            if (prod == null) return;

            if (MessageBox.Show($"Удалить '{prod.NameProduct}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new WarehouseContext())
                    {
                        var dbProd = db.Products.Find(prod.IdProducts);
                        if (dbProd != null)
                        {
                            db.Products.Remove(dbProd);
                            db.SaveChanges();
                        }
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["Price"].Index || e.ColumnIndex == dgv.Columns["Stock"].Index)
            {
                string input = e.FormattedValue?.ToString()?.Trim();
                if (string.IsNullOrEmpty(input)) return;

                if (e.ColumnIndex == dgv.Columns["Price"].Index)
                {
                    if (!decimal.TryParse(input, out decimal val) || val < 0)
                    {
                        MessageBox.Show("Цена должна быть неотрицательным числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (!int.TryParse(input, out int val) || val < 0)
                    {
                        MessageBox.Show("Остаток должен быть целым неотрицательным числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var col = dgv.Columns[e.ColumnIndex];
                if (col is DataGridViewComboBoxColumn && !dgv.ReadOnly)
                {
                    if (dgv.CurrentCell == dgv.Rows[e.RowIndex].Cells[e.ColumnIndex])
                        dgv.BeginEdit(true);
                    else
                        dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e) { e.Cancel = true; }
        private void buttonForBack_Click(object sender, EventArgs e)
        {
            if (!dgv.ReadOnly)
            {
                if (MessageBox.Show("Есть несохраненные изменения. Сохранить?", "Выход", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    buttonForEdit.PerformClick();
                    if (dgv.ReadOnly) this.Close();
                }
                else if (MessageBox.Show("Выйти без сохранения?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (allProducts == null) return;
            string txt = textBoxSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(txt))
            {
                dgv.DataSource = allProducts;
            }
            else
            {
                dgv.DataSource = allProducts.Where(p =>
                    (p.NameProduct?.ToLower().Contains(txt) ?? false) ||
                    (p.Article.ToString().ToLower().Contains(txt))
                ).ToList();
            }
        }
        private void RefreshCategoryComboSource()
        {
            var comboCol = dgv.Columns["Category"] as DataGridViewComboBoxColumn;
            if (comboCol != null)
            {
                using (var db = new WarehouseContext())
                {
                    var currentValues = new Dictionary<int, object>();
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["Category"].Value != null)
                            currentValues[row.Index] = row.Cells["Category"].Value;
                    }
                    comboCol.DataSource = db.Categories.ToList();
                    foreach (var kvp in currentValues)
                    {
                        if (kvp.Key < dgv.Rows.Count)
                            dgv.Rows[kvp.Key].Cells["Category"].Value = kvp.Value;
                    }
                }
            }
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var inputForm = new InputCategoryForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string newName = inputForm.txtName.Text.Trim();

                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        try
                        {
                            using (var db = new WarehouseContext())
                            {
                                if (db.Categories.Any(c => c.NameCategory.ToLower() == newName.ToLower()))
                                {
                                    MessageBox.Show("Такая категория уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                var newCat = new Categories
                                {
                                    IdCategories = Guid.NewGuid(),
                                    NameCategory = newName
                                };

                                db.Categories.Add(newCat);
                                db.SaveChanges();
                            }
                            MessageBox.Show($"Категория '{newName}' успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshCategoryComboSource();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}

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
    /// <summary>
    /// Форма для администратора для управления каталогом товаров.
    /// </summary>
    public partial class CatalogAdminForm : Form
    {
        private BindingList<Products> allProducts;
        /// <summary>
        /// Конструктор для формы каталога товара.
        /// </summary>
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
                Logger.Error("System", "APP_STARTUP_ERROR", ex.Message);
                MessageBox.Show(Properties.Resources.StartupError);
                Close();
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
                Logger.Error("System", "LOAD_DATA", ex.Message);
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
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
                    Logger.Info("System", "SAVE_SUCCESS", "Данные успешно сохранены");
                    MessageBox.Show(Properties.Resources.SuccessMessage);
                    LoadData();
                }
                catch (Exception ex)
                {
                    Logger.Error("System", "SAVE_ERROR", ex.Message);
                    MessageBox.Show(Properties.Resources.SaveErrorText);
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
                        Logger.Warning("System", "MISSING_CATEGORIES", "Отсутствуют категории или единицы измерения в базе");
                        MessageBox.Show(Properties.Resources.NoCategoriesError);
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
                Logger.Error("System", "CREATE_ERROR", ex.Message);
                MessageBox.Show(Properties.Resources.CreateErrorText);
            }
        }
        private void buttonForDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var prod = dgv.CurrentRow.DataBoundItem as Products;
            if (prod == null) return;
            Logger.Warning("System", "DELETE_CONFIRM", $"Запрос удаления: {prod.NameProduct}");
            if (MessageBox.Show(string.Format(Properties.Resources.DeleteConfirmText, prod.NameProduct), Properties.Resources.ConfirmDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                    Logger.Error("System", "DELETE_ERROR", ex.Message);
                    MessageBox.Show(Properties.Resources.DeleteErrorText);
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
                        Logger.Warning("System", "NEGATIVE_STOCK", "Попытка ввода отрицательного значения");
                        MessageBox.Show(Properties.Resources.NegativeStockWarning);
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (!int.TryParse(input, out int val) || val < 0)
                    {
                        Logger.Warning("System", "NEGATIVE_STOCK", "Попытка ввода нецелого значения");
                        MessageBox.Show(Properties.Resources.NegativeStockWarning);
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
                Logger.Info("System", "EXIT_SAVE_PROMPT", "Запрос сохранения перед выходом");
                if (MessageBox.Show(Properties.Resources.UnsavedChangesQuestion, Properties.Resources.ExitTitle, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    buttonForEdit.PerformClick();
                    if (dgv.ReadOnly) this.Close();
                }
                else if (MessageBox.Show(Properties.Resources.ExitWithoutSavingQuestion, Properties.Resources.ExitTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
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
                                    Logger.Warning("System", "CATEGORY_EXISTS", "Попытка добавления существующей категории");
                                    MessageBox.Show(Properties.Resources.CategoryExistsWarning);
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
                            Logger.Info("System", "CATEGORY_ADDED", $"Добавлена категория: {newName}");
                            MessageBox.Show(Properties.Resources.CategoryAddedSuccess);
                            RefreshCategoryComboSource();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("System", "ADD_CATEGORY_ERROR", ex.Message);
                            MessageBox.Show(Properties.Resources.GenericErrorText);
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Каталог товаров Админа 
    /// </summary>
    public partial class CatalogAdminForm : Form
    {
        private BindingList<Products> _allProducts;
        private User _currentUser;
        /// <summary>
        /// Конструктор каталога товаров админа
        /// </summary>
        public CatalogAdminForm()
        {
            InitializeComponent();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            using (var db = new WarehouseContext())
            {
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv.RowTemplate.Height = 30;
                dgv.GridColor = Color.Black;
                // ниже только для админа 
                dgv.ReadOnly = false;
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;

                dgv.AutoGenerateColumns = false;
                dgv.AllowUserToAddRows = false;
                dgv.Columns.Add("Article", "Артикул");
                dgv.Columns["Article"].DataPropertyName = "Article";

                dgv.Columns.Add("NameProduct", "Название");
                dgv.Columns["NameProduct"].DataPropertyName = "NameProduct"; 
                var comboCol = new DataGridViewComboBoxColumn();
                comboCol.Name = "Category";
                comboCol.HeaderText = "Категория";
                comboCol.DataSource = db.Categories.ToList(); 
                comboCol.DisplayMember = "NameCategory";   
                comboCol.ValueMember = "IdCategories";        
                comboCol.DataPropertyName = "IdCategories";   
                dgv.Columns.Add(comboCol);
                comboCol.DisplayStyleForCurrentCellOnly = true;
                var comboUnit = new DataGridViewComboBoxColumn();
                comboUnit.Name = "UnitOfMeasure"; 
                comboUnit.HeaderText = "Ед. измерений";
                comboUnit.DataSource = db.UnitOfMeasure.ToList(); 
                comboUnit.DisplayMember = "NameUnit"; 
                comboUnit.ValueMember = "IdUnit"; 
                comboUnit.DataPropertyName = "IdUnitOfMeasure"; 
                comboUnit.DisplayStyleForCurrentCellOnly = true;
                dgv.Columns.Add(comboUnit);
                dgv.Columns.Add("Price", "Цена закупки");
                dgv.Columns["Price"].DataPropertyName = "Price";

                dgv.Columns.Add("Stock", "Остаток");
                dgv.Columns["Stock"].DataPropertyName = "Stock";
                dgv.CellFormatting += dgv_CellFormatting;
                
                dgv.DataError += dgv_DataError;
                dgv.Columns["Price"].ReadOnly = false;
                dgv.Columns["Stock"].ReadOnly = false; 
                LoadData();
            }

        }
        private void LoadData()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    _allProducts = new BindingList<Products>(db.Products
                .Include("Category")
                .Include("UnitOfMeasure")
                .ToList());
                }
                dgv.DataSource = _allProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void buttonForDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var productToDelete = dgv.CurrentRow.DataBoundItem as Products;

            if (productToDelete != null)
            {
                var result
                    = MessageBox.Show($"Вы точно хотите удалить {productToDelete.NameProduct}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var db = new WarehouseContext())
                    {
                        db.Entry(productToDelete).State = System.Data.Entity.EntityState.Deleted;

                        db.SaveChanges(); 
                    }
                    LoadData(); 
                }
            }
        }

        private void buttonForBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
 
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (_allProducts == null) return;

            var searchText = textBoxSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                dgv.DataSource = _allProducts;
            }
            else
            {
                var filteredList = _allProducts.Where(p =>
                    (p.NameProduct != null && p.NameProduct.ToLower().Contains(searchText)) ||
                    (p.Article.ToString().ToLower().Contains(searchText)) |
                    (p.Category != null &&
                     p.Category.NameCategory != null &&
                     p.Category.NameCategory.ToLower().Contains(searchText)) ||
                    (p.UnitOfMeasure != null &&
                     p.UnitOfMeasure.NameUnit != null &&
                     p.UnitOfMeasure.NameUnit.ToLower().Contains(searchText))

                ).ToList();

                dgv.DataSource = filteredList;
            }
        }

        private void buttonForEdit_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            dgv.BeginEdit(true);
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            dgv.EndEdit(); 

            try
            {
                using (var db = new WarehouseContext())
                {
                    foreach (var item in _allProducts)
                    {
                        item.Category = null;
                        item.UnitOfMeasure = null;
                        if (item.IdProducts == Guid.Empty)
                        {
                            item.IdProducts = Guid.NewGuid();
                            if (item.Article == Guid.Empty) item.Article = Guid.NewGuid();

                            db.Products.Add(item);
                        }
                        else
                        {
                            var existing = db.Products.Find(item.IdProducts);

                            if (existing == null)
                            {
                                db.Products.Add(item);
                            }
                            else
                            {
                                db.Entry(existing).CurrentValues.SetValues(item);
                            }
                        }
                    }
                    db.SaveChanges();
                    MessageBox.Show("Изменения сохранены!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null) msg += "\n" + ex.InnerException.Message;
                MessageBox.Show("Ошибка сохранения: " + msg);
            }
        }

        private void buttonToAddGood_Click(object sender, EventArgs e)
        {

            var newProduct = new Products
            {
                IdProducts = Guid.Empty, 
                Article = Guid.NewGuid(),
                NameProduct = "Новый товар",
                Price = 0,
                Stock = 0,
            };
            _allProducts.Add(newProduct);
            int lastRowIndex = dgv.Rows.Count - 1;
            dgv.CurrentCell = dgv.Rows[lastRowIndex].Cells[1]; 
            dgv.BeginEdit(true);
        }
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
            e.ThrowException = false;
        }

        
    }
}

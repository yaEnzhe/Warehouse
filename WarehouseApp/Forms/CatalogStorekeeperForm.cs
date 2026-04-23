using NLog;
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
    /// Форма кладовщика для работы с каталогом товаров склада
    /// </summary>
    public partial class CatalogStorekeeperForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private BindingList<Products> _allProducts;
        /// <summary>
        /// Конструктор для формы каталога товаров
        /// </summary>
        public CatalogStorekeeperForm()
        {
            InitializeComponent();
        }

        private void CatalogStorekeeperForm_Load(object sender, EventArgs e)
        {
            using (var db = new WarehouseContext())
            {
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv.RowTemplate.Height = 30;
                dgv.GridColor = Color.Black;
                dgv.ReadOnly = true; 
                dgv.AllowUserToAddRows = false; 
                dgv.AllowUserToDeleteRows = false; 
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
                dgv.AutoGenerateColumns = false;
                dgv.Columns.Add("Article", "Артикул");
                dgv.Columns["Article"].DataPropertyName = "Article";
                dgv.Columns.Add("NameProduct", "Название");
                dgv.Columns["NameProduct"].DataPropertyName = "NameProduct";
                dgv.Columns["NameProduct"].Width = 200; 
                var comboCol = new DataGridViewComboBoxColumn();
                comboCol.Name = "Category";
                comboCol.HeaderText = "Категория";
                comboCol.DataSource = db.Categories.ToList();
                comboCol.DisplayMember = "NameCategory";
                comboCol.ValueMember = "IdCategories";
                comboCol.DataPropertyName = "IdCategories";
                comboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; 
                dgv.Columns.Add(comboCol);
                var comboUnit = new DataGridViewComboBoxColumn();
                comboUnit.Name = "UnitOfMeasure";
                comboUnit.HeaderText = "Ед. изм.";
                comboUnit.DataSource = db.UnitOfMeasure.ToList();
                comboUnit.DisplayMember = "NameUnit";
                comboUnit.ValueMember = "IdUnit"; 
                comboUnit.DataPropertyName = "IdUnit";
                comboUnit.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; 
                dgv.Columns.Add(comboUnit);
                dgv.Columns.Add("Price", "Цена");
                dgv.Columns["Price"].DataPropertyName = "Price";
                dgv.Columns.Add("Stock", "Остаток");
                dgv.Columns["Stock"].DataPropertyName = "Stock";
                dgv.DataError += dgv_DataError;
                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var data = db.Products
                        .AsNoTracking()
                        .Include("Category")
                        .Include("UnitOfMeasure")
                        .ToList();

                    _allProducts = new BindingList<Products>(data);
                }
                dgv.DataSource = _allProducts;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "LOAD_DATA_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
            }
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
                    (p.Article.ToString().ToLower().Contains(searchText)) ||
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

        private void buttonForBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
            e.ThrowException = false;
        }
    }
}


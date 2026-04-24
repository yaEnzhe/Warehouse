using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using NLog;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма для администратора для управления каталогом товаров.
    /// </summary>
    public partial class CatalogAdminForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private bool isReadOnlyMode;
        private BindingList<ProductRow> allProducts;
        /// <summary>
        /// Конструктор для формы каталога товара.
        /// </summary>
        public CatalogAdminForm(bool readOnly = false)
        {
            InitializeComponent();
            isReadOnlyMode = readOnly;
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
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
                dgv.Columns.Clear();
                dgv.AutoGenerateColumns = false;
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colArticle",
                    HeaderText = "Артикул",
                    DataPropertyName = "Article",
                    Width = 80,
                    ReadOnly = true
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colName",
                    HeaderText = "Название",
                    DataPropertyName = "Name",
                    Width = 150,
                    ReadOnly = true
                });
                var comboCategory = new DataGridViewComboBoxColumn
                {
                    Name = "colCategory",
                    HeaderText = "Категория",
                    DataPropertyName = "CategoryId",
                    DisplayMember = "Name",
                    ValueMember = "Id",
                    DataSource = GetCategoriesForCombo(),
                    Width = 120,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    DisplayStyleForCurrentCellOnly = true
                };
                dgv.Columns.Add(comboCategory);
                var comboUnit = new DataGridViewComboBoxColumn
                {
                    Name = "colUnit",
                    HeaderText = "Ед. изм.",
                    DataPropertyName = "Unit",
                    DisplayMember = "Name",
                    ValueMember = "Name",
                    DataSource = GetUnitsForCombo(),
                    Width = 90,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                    DisplayStyleForCurrentCellOnly = true
                };
                dgv.Columns.Add(comboUnit);
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colPrice",
                    HeaderText = "Цена",
                    DataPropertyName = "Price",
                    Width = 90,
                    DefaultCellStyle = { Format = "0.00 ₽"},
                    ReadOnly = true
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colStock",
                    HeaderText = "Остаток",
                    DataPropertyName = "Stock",
                    Width = 70,
                    ReadOnly = true
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colExp",
                    HeaderText = "Срок годности",
                    DataPropertyName = "ExpirationDate",
                    Width = 110,
                    DefaultCellStyle = { Format = "dd.MM.yyyy" },
                    ReadOnly = true
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Статус",
                    DataPropertyName = "Status",
                    Width = 100,
                    ReadOnly = true
                });

                dgv.CellFormatting += dgv_CellFormatting;
                dgv.DataError += dgv_DataError;
                dgv.CellValidating += dgv_CellValidating;
                dgv.CellClick += dgv_CellClick;
                dgv.CellBeginEdit += dgv_CellBeginEdit;
                LoadData();
                dgv.ReadOnly = true;
                LoadFilterControls();
                ApplyFilters();
                var currentUser = UserContext.Current;
                if (currentUser != null)
                {
                    string roleName = currentUser.Role.ToString();
                    lblUserRole.Text = $"Ваша роль: {roleName}";
                    if (currentUser.Role == Enums.Roles.Storekeeper)
                    {
                        buttonForEdit.Visible = false;
                        buttonToAddGood.Visible = false;
                        buttonForDelete.Visible = false;
                        btnAddCategory.Visible = false;
                        dgv.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "APP_STARTUP_ERROR. Category: {Category}", "System");
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
                    var products = db.Products
                        .Include("Category")
                        .Include("UnitOfMeasure")
                        .ToList();

                    allProducts = new BindingList<ProductRow>();
                    foreach (var p in products)
                    {
                        allProducts.Add(new ProductRow
                        {
                            Id = p.IdProducts,
                            Article = p.Article,
                            Name = p.NameProduct,
                            CategoryId = p.IdCategories,
                            CategoryName = p.Category?.NameCategory ?? "—",
                            Unit = p.UnitOfMeasure?.NameUnit ?? "шт",
                            Price = Options.ConvertFromBase(p.Price),
                            Stock = (int)p.Stock,
                            ExpirationDate = p.ExpirationDate,
                            ProductionDate = p.ProductionDate,
                            Status = ""
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "LOAD_DATA. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
            }
        }
        private void buttonForEdit_Click(object sender, EventArgs e)
        { 
            if (buttonForEdit.Text == "Редактировать")
            {
                dgv.ReadOnly = false;
                buttonForEdit.Text = "Сохранить";
                if (dgv.Rows.Count > 0)
                {
                    dgv.CurrentCell = dgv.Rows[0].Cells["colName"];
                }
                return;
            }
            dgv.EndEdit();

            try
            {
                using (var db = new WarehouseContext())
                {
                    foreach (var row in allProducts)
                    {
                        var existing = db.Products.Find(row.Id);

                        if (existing == null)
                        {
                            db.Products.Add(new Products
                            {
                                IdProducts = row.Id,
                                Article = row.Article,
                                NameProduct = row.Name,
                                Price = row.Price,
                                Stock = row.Stock,
                                IdCategories = row.CategoryId,
                                IdUnitOfMeasure = Guid.Empty,
                                ExpirationDate = row.ExpirationDate,
                                ProductionDate = row.ProductionDate
                            });
                        }
                        else
                        {
                            existing.NameProduct = row.Name;
                            existing.Price = Options.ConvertToBase(row.Price);
                            existing.Stock = row.Stock;
                            existing.ExpirationDate = row.ExpirationDate;
                            existing.ProductionDate = row.ProductionDate;
                            existing.IdCategories = row.CategoryId;
                        }
                    }
                    db.SaveChanges();
                }
                logger.Info("SAVE_SUCCESS. Category: {Category}. Message: {Message}", "System", "Данные успешно сохранены");
                MessageBox.Show(Properties.Resources.SuccessMessage);
                LoadData();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "SAVE_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.SaveErrorText);
            }
            finally
            {
                dgv.ReadOnly = true;
                buttonForEdit.Text = "Редактировать";
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
                        logger.Warn("MISSING_CATEGORIES", "Отсутствуют категории или единицы измерения");
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
                        IdUnitOfMeasure = unit.IdUnit,
                        ExpirationDate = null,
                        ProductionDate = null
                    };

                    db.Products.Add(newProd);
                    db.SaveChanges();
                }
                LoadData();
                ApplyFilters();
                dgv.ReadOnly = false;
                buttonForEdit.Text = "Сохранить";
                if (dgv.Columns["colName"] != null)
                    dgv.Columns["colName"].ReadOnly = false;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.DataBoundItem is ProductRow p && p.Name == "Новый товар")
                    {
                        dgv.CurrentCell = row.Cells["colName"];
                        dgv.FirstDisplayedScrollingRowIndex = row.Index;
                        dgv.BeginEdit(true);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "CREATE_ERROR", "System");
                MessageBox.Show(Properties.Resources.CreateErrorText);
            }
        }
        private void buttonForDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var productRow = dgv.CurrentRow.DataBoundItem as ProductRow;
            if (productRow == null) return;
            logger.Warn("DELETE_CONFIRM. Category: {Category}", "System", $"Запрос удаления: {productRow.Name}");

            if (MessageBox.Show(string.Format(Properties.Resources.DeleteConfirmText, productRow.Name),
                Properties.Resources.ConfirmDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new WarehouseContext())
                    {
                        var dbProduct = db.Products.Find(productRow.Id);

                        if (dbProduct != null)
                        {
                            var isUsed = db.ShipmentContents.Any(sc => sc.IdProducts == dbProduct.IdProducts);
                            if (isUsed)
                            {
                                MessageBox.Show(Properties.Resources.CannotDeleteUsedProduct);
                                return;
                            }
                            db.Products.Remove(dbProduct);
                            db.SaveChanges();
                            logger.Info("DELETE_SUCCESS", $"Товар '{productRow.Name}' удалён");
                        }
                    }
                    LoadData();
                    ApplyFilters();
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "DELETE_ERROR. Category: {Category}", "System");
                    MessageBox.Show(Properties.Resources.DeleteErrorText);
                }
            }
        }
        private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["colPrice"].Index || e.ColumnIndex == dgv.Columns["colStock"].Index)
            {
                string input = e.FormattedValue?.ToString()?.Trim();
                if (string.IsNullOrEmpty(input)) return;

                if (e.ColumnIndex == dgv.Columns["colPrice"].Index)
                {
                    if (!decimal.TryParse(input, out decimal val) || val < 0)
                    {
                        logger.Warn("NEGATIVE_PRICE. Category: {Category}", "System", "Попытка ввода отрицательной цены");
                        MessageBox.Show(Properties.Resources.NegativeStockWarning);
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (!int.TryParse(input, out int val) || val < 0)
                    {
                        logger.Warn("NEGATIVE_STOCK. Category: {Category}", "System", "Попытка ввода отрицательного остатка");
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
                logger.Info("EXIT_SAVE_PROMPT. Category: {Category}", "System", "Запрос сохранения перед выходом");
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
            ApplyFilters();
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
                                    logger.Warn("CATEGORY_EXISTS. Category: {Category}", "System", "Попытка добавления существующей категории");
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
                            logger.Info("CATEGORY_ADDED. Category: {Category}", "System", $"Добавлена категория: {newName}");
                            MessageBox.Show(Properties.Resources.CategoryAddedSuccess);
                            RefreshCategoryComboSource();
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex, "ADD_CATEGORY_ERROR. Category: {Category}", "System");
                            MessageBox.Show(Properties.Resources.GenericErrorText);
                        }
                    }
                }
            }
        }
        private string CalculateStatus(ProductRow row)
        {
            if (row.Stock <= 0 || (row.ExpirationDate.HasValue && row.ExpirationDate.Value < DateTime.Today))
                return "Списан";
            if (!row.ExpirationDate.HasValue)
                return "Активен";
            bool isDiscountActive = false;
            if (row.ProductionDate.HasValue && row.ProductionDate.Value < row.ExpirationDate.Value)
            {
                TimeSpan total = row.ExpirationDate.Value - row.ProductionDate.Value;
                DateTime discountStart = row.ExpirationDate.Value.Subtract(TimeSpan.FromDays(total.Days / 3));
                isDiscountActive = DateTime.Today >= discountStart;
            }
            else
            {
                DateTime discountStart = row.ExpirationDate.Value.AddDays(-30);
                isDiscountActive = DateTime.Today >= discountStart;
            }
            return isDiscountActive ? "Скидка 30%" : "Активен";
        }
        private void LoadFilterControls()
        {
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("Все");
            using (var db = new WarehouseContext())
            {
                foreach (var cat in db.Categories.ToList())
                    cmbFilterCategory.Items.Add(cat.NameCategory);
            }
            cmbFilterCategory.SelectedIndex = 0;
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.AddRange(new string[] { "Все", "Активен", "Скидка 30%", "Списан" });
            cmbFilterStatus.SelectedIndex = 0;
        }
        private void ApplyFilters()
        {
            if (allProducts == null) return;

            string searchText = textBoxSearch.Text.ToLower().Trim();
            string categoryFilter = cmbFilterCategory.SelectedItem?.ToString();
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString();

            var filtered = new List<ProductRow>();

            foreach (var row in allProducts)
            {
                row.Status = CalculateStatus(row);

                bool matchSearch = string.IsNullOrEmpty(searchText) ||
                    row.Name.ToLower().Contains(searchText) ||
                    row.Article.ToLower().Contains(searchText);
                if (!matchSearch) continue;

                bool matchCategory = categoryFilter == "Все" || row.CategoryName == categoryFilter;
                if (!matchCategory) continue;

                bool matchStatus = statusFilter == "Все" || row.Status == statusFilter;
                if (!matchStatus) continue;

                filtered.Add(row);
            }
            string symbol = Options.GetCurrencySymbol(Options.CurrentCurrency);
            if (dgv.Columns["colPrice"] != null)
            {
                dgv.Columns["colPrice"].HeaderText = $"Цена ({symbol})";
                dgv.Columns["colPrice"].DefaultCellStyle.Format = "0.00";
            }

            dgv.DataSource = null;
            dgv.DataSource = filtered;
        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private List<CategoryItem> GetCategoriesForCombo()
        {
            using (var db = new WarehouseContext())
            {
                return db.Categories.Select(c => new CategoryItem
                {
                    Id = c.IdCategories,
                    Name = c.NameCategory
                }).ToList();
            }
        }
        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName == "colStock" || colName == "colExp")
            {
                e.Cancel = true;
            }
            if (colName == "colStatus" || colName == "colArticle")
            {
                e.Cancel = true;
            }
        }
        private List<UnitItem> GetUnitsForCombo()
        {
            using (var db = new WarehouseContext())
            {
                return db.UnitOfMeasure.Select(u => new UnitItem
                {
                    Id = u.IdUnit,
                    Name = u.NameUnit
                }).ToList();
            }
        }
        /// <summary>
        /// Метод для перезагрузки данных
        /// </summary>
        public void ReloadData()
        {
            LoadData();
            ApplyFilters();
        }
    }
    /// <summary>
    /// Класс с значениями для таблицы
    /// </summary>
    public class ProductRow
    {
        /// <summary>
        /// Значения, которые хранятся в таблице
        /// </summary>
        public Guid Id { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string Status { get; set; }
    }

    /// <summary>
    /// Класс для категорий
    /// </summary>
    public class CategoryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// Класс для привязки единиц измерения
    /// </summary>
    public class UnitItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

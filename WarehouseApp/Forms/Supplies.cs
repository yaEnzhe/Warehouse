using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма управления поставками
    /// </summary>
    public partial class Supplies : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<SupplyRow> currentSupply = new List<SupplyRow>();
        /// <summary>
        /// Класс для отражения в таблице данных перед сохранением в БД
        /// </summary>
        public class SupplyRow
        {
            /// <summary>
            /// Идентификатор товара 
            /// </summary>
            public Guid ProductId { get; set; }
            /// <summary>
            /// Артикул товара 
            /// </summary>
            public string Article { get; set; }

            /// <summary>
            /// Наименование товара
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// Количество товара
            /// </summary>
            public int Quantity { get; set; }

            /// <summary>
            /// Цена закупки
            /// </summary>
            public decimal Price { get; set; }
            /// <summary>
            /// Дата окончания срока годности
            /// </summary>
            public DateTime Expiration { get; set; }
        }
        private readonly WarehouseContext context = new WarehouseContext();
        private List<Products> productsList = new List<Products>();
        /// <summary>
        /// Конструктор для формы управления поставками
        /// </summary>
        public Supplies()
        {
            InitializeComponent();
            SetupGridColumns();
            var currentUser = UserContext.Current;
            if (currentUser == null)
            {
                logger.Warn("SESSION_NOT_FOUND. Category: {Category}", "System", "Попытка входа в отчет не администратора");
                MessageBox.Show(Properties.Resources.StartupError);
                Close();
                return;
            }
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
            LoadProducts();
        }
        private void LoadProducts()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var products = db.Products
                        .OrderBy(p => p.NameProduct)
                        .ToList();

                    cmbProduct.DataSource = products;
                    cmbProduct.DisplayMember = "NameProduct";
                    cmbProduct.ValueMember = "IdProducts";
                    cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "LOAD_PRODUCTS_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
            }
        }
        public void LoadData()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var supplies = db.ShipmentContents.ToList();
                    var list = new List<SupplyRow>();

                    foreach (var item in supplies)
                    {
                        var product = db.Products.Find(item.IdProducts);
                        if (product == null) continue;

                        list.Add(new SupplyRow
                        {
                            ProductId = product.IdProducts,
                            Article = product.Article,
                            ProductName = product.NameProduct,
                            Quantity = item.QuantityShipmentContents,
                            Price = Options.ConvertFromBase(product.Price),
                            Expiration = product.ExpirationDate ?? DateTime.MaxValue
                        });
                    }
                    dgvSupply.DataSource = null;
                    dgvSupply.DataSource = list;
                    string symbol = Options.GetCurrencySymbol(Options.CurrentCurrency);
                    if (dgvSupply.Columns["colPrice"] != null)
                    {
                        dgvSupply.Columns["colPrice"].HeaderText = $"Цена ({symbol})";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "LOAD_SUPPLIES_ERROR", "System");
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
            }
        }

        /// <summary>
        /// Метод для обновления данных
        /// </summary>
        public void ReloadData()
        {
            LoadData();
        }
        private void SetupGridColumns()
        {
            dgvSupply.AutoGenerateColumns = false;
            dgvSupply.Columns.Clear();

            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colArticle",
                HeaderText = Properties.Resources.ColumnArticle,
                DataPropertyName = "Article",
                ReadOnly = true
            });
            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = Properties.Resources.ColumnName,
                DataPropertyName = "ProductName",
                ReadOnly = true
            });
            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQty",
                HeaderText = Properties.Resources.ColumnQuantity,
                DataPropertyName = "Quantity",
                ReadOnly = true
            });
            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = Properties.Resources.ColumnPrice,
                DataPropertyName = "Price",
                ReadOnly = true
            });
            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colExp",
                HeaderText = Properties.Resources.ColumnTerm,
                DataPropertyName = "Expiration",
                ReadOnly = true
            });
        }
        private void btnhistori_Click(object sender, EventArgs e)
        {
            DeliveryHistory deliveryHistory = new DeliveryHistory();
            deliveryHistory.Show();
            Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            var currentUser = UserContext.Current;
            if (currentUser == null)
            {
                Application.Exit();
                return;
            }
            var userRole = currentUser.Role;
            Form nextForm = null;
            switch (userRole)
            {
                case Roles.Administrator:
                    nextForm = new MainMenuAdminForm();
                    break;
                case Roles.Storekeeper:
                    nextForm = new MainMenuStorekeeperForm();
                    break;
                default:
                    logger.Warn("NAVIGATE_UNKNOWN_ROLE. Category: {Category}", currentUser.Login, $"{userRole}");
                    Application.Exit();
                    return;
            }
            Close();
        }
        private void btnAddToSupply_Click(object sender, EventArgs e)
        {
            var qtyText = txtboxcolichestvo.Text.Replace('.', ',');
            var priceText = txtboxPrice.Text.Replace('.', ',');
            if (cmbProduct.SelectedItem == null)
            {
                logger.Warn("PRODUCT_NOT_SELECTED. Category: {Category}", "System", "Пользователь не выбрал товар");
                MessageBox.Show(Properties.Resources.ProductNotFound);
                cmbProduct.Focus();
                return;
            }
            if (dtpExpirationDate.Value.Date < DateTime.Now.Date)
            {
                logger.Warn("EXPIRATION_DATE_PAST. Category: {Category}", "System", "Указана прошедшая дата срока годности");
                MessageBox.Show(Properties.Resources.ShipmentDatePastError);
                dtpExpirationDate.Focus();
                return;
            }
            if (!decimal.TryParse(qtyText, out decimal qty) || qty <= 0)
            {
                logger.Warn("INVALID_QUANTITY. Category: {Category}", "System", "Количество должно быть больше 0");
                MessageBox.Show(Properties.Resources.InvalidQuantity);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
            {
                logger.Warn("INVALID_PRICE. Category: {Category}", "System", "Цена закупки должна быть больше 0");
                MessageBox.Show(Properties.Resources.InvalidPrice);
                return;
            }
            var selectedProduct = cmbProduct.SelectedItem as Products;
            Guid productId = selectedProduct?.IdProducts ?? Guid.Empty;
            string productName = selectedProduct?.NameProduct ?? cmbProduct.Text;
            var newRow = new SupplyRow
            {
                ProductId = selectedProduct?.IdProducts ?? Guid.Empty,
                Article = selectedProduct?.Article ?? "",
                ProductName = selectedProduct?.NameProduct ?? cmbProduct.Text,
                Quantity = (int)qty,
                Price = price,
                Expiration = dtpExpirationDate.Value.Date
            };
            currentSupply.Add(newRow);
            dgvSupply.DataSource = null;
            dgvSupply.DataSource = currentSupply.ToList();
            cmbProduct.SelectedIndex = -1;
            txtboxcolichestvo.Clear();
            txtboxPrice.Clear();
            dtpExpirationDate.Value = DateTime.Now;
            logger.Info("ITEM_ADDED. Category: {Category}", "System", $"Добавлено: {productName}, {qty} шт.");
        }
        private void txtboxcolichestvo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void txtboxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            System.Diagnostics.Debug.WriteLine($"[Цена] Нажато: '{e.KeyChar}' | Код: {(int)e.KeyChar}");
            bool isDigit = (e.KeyChar >= '0' && e.KeyChar <= '9');
            bool isSeparator = (e.KeyChar == '.' || e.KeyChar == ',');
            bool isControl = char.IsControl(e.KeyChar);
            if (!isControl && !isDigit && !isSeparator)
            {
                e.Handled = true;
                return;
            }
            if (isSeparator && (tb.Text.Contains('.') || tb.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }
        private void btnProcessSupply_Click(object sender, EventArgs e)
        {
            if (currentSupply.Count == 0)
            {
                MessageBox.Show(Properties.Resources.EmptyProductList);
                return;
            }
            var currentUser = UserContext.Current;
            if (currentUser == null)
            {
                MessageBox.Show(Properties.Resources.UserNotAuthorized);
                return;
            }
            try
            {
                using (var db = new WarehouseContext())
                {
                    var supply = new Supply
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Now,
                        UserId = currentUser.Id,
                        SupplyItems = new List<SupplyItem>()
                    };

                    foreach (var item in currentSupply)
                    {
                        var supplyItem = new SupplyItem
                        {
                            Id = Guid.NewGuid(),
                            SupplyId = supply.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            ExpirationDate = item.Expiration
                        };
                        supply.SupplyItems.Add(supplyItem);
                        var product = db.Products.Find(item.ProductId);
                        if (product != null)
                        {
                            product.Stock += item.Quantity;
                            product.Price = item.Price;
                            if (item.Expiration > DateTime.MinValue)
                            {
                                product.ExpirationDate = item.Expiration;
                            }
                        }
                    }

                    db.Supplies.Add(supply);
                    db.SaveChanges();
                }
                currentSupply.Clear();
                dgvSupply.DataSource = null;
                logger.Info("SUPPLY_PROCESSED. Category: {Category}", currentUser.Login, $"Товаров: {currentSupply.Count}");
                MessageBox.Show(Properties.Resources.ShipmentSucces);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "SUPPLY_SAVE_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.SaveErrorText);
            }
        }
        private void btnImportFromFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Filter = "JSON файлы|*.json|Все файлы|*.*",
                Title = "Выберите файл для импорта (JSON)"
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    string json = File.ReadAllText(ofd.FileName);
                    var importItems = JsonSerializer.Deserialize<List<ImportDto>>(json);
                    if (importItems == null || importItems.Count == 0)
                    {
                        MessageBox.Show(Properties.Resources.EmptyOrInvalidFileFormat);
                        return;
                    }
                    int successCount = 0;
                    int errorCount = 0;
                    using (var db = new WarehouseContext())
                    {
                        var products = db.Products.ToList();
                        foreach (var item in importItems)
                        {
                            Products foundProduct = null;
                            foreach (var p in products)
                            {
                                string articleFromDb = p.Article.Trim().ToLower();
                                string articleFromFile = item.Article.Trim().ToLower();
                                if (articleFromDb == articleFromFile)
                                {
                                    foundProduct = p;
                                    break;
                                }
                            }
                            if (foundProduct == null)
                            {
                                errorCount = errorCount + 1;
                            }
                            else
                            {
                                bool quantityOk = item.Quantity > 0;
                                bool priceOk = item.Price > 0;

                                if (quantityOk && priceOk)
                                {
                                    DateTime expDate = item.ExpirationDate.Date;
                                    DateTime today = DateTime.Now.Date;
                                    if (expDate >= today)
                                    {
                                        SupplyRow newRow = new SupplyRow();
                                        newRow.ProductId = foundProduct.IdProducts;
                                        newRow.Article = foundProduct.Article;
                                        newRow.ProductName = foundProduct.NameProduct;
                                        newRow.Quantity = item.Quantity;
                                        newRow.Price = item.Price;
                                        newRow.Expiration = expDate;
                                        currentSupply.Add(newRow);
                                        successCount = successCount + 1;
                                    }
                                    else
                                    {
                                        errorCount++; ;
                                    }
                                }
                                else
                                {
                                    errorCount++; ;
                                }
                            }
                        }
                        dgvSupply.DataSource = null;
                        dgvSupply.DataSource = currentSupply.ToList();
                        MessageBox.Show(Properties.Resources.ImportCompleted);
                    } 
                } 
                catch (Exception ex)
                {
                    logger.Error(ex, "IMPORT_ERROR. Category: {Category}", "System");
                    MessageBox.Show(Properties.Resources.EmptyOrInvalidFileFormat);
                }
            } 
        }
    }
    /// <summary>
    /// Данные для десериализации данных из JSON-файла
    /// </summary>
    public class ImportDto
    {
        /// <summary>
        /// Артикул товара
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дата окончания срока годности товара
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}
      

            
        
        

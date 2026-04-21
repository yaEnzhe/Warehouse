using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;
using System.IO;
using System.Text.Json;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма управления поставками
    /// </summary>
    public partial class Supplies : Form
    {
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
                Logger.Warning("System", "SESSION_NOT_FOUND", "Попытка открытия формы поставок без авторизации");
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
                Logger.Error("System", "LOAD_PRODUCTS_ERROR", ex.Message);
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
            }
        }
        private void SetupGridColumns()
        {
            dgvSupply.AutoGenerateColumns = false;
            dgvSupply.Columns.Clear();

            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colArticle",
                HeaderText = "Артикул",
                DataPropertyName = "Article",
                ReadOnly = true
            });
            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Название",
                DataPropertyName = "ProductName",
                ReadOnly = true
            });
            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQty",
                HeaderText = "Кол-во",
                DataPropertyName = "Quantity",
                ReadOnly = true
            });
            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Цена",
                DataPropertyName = "Price",
                ReadOnly = true
            });
            dgvSupply.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colExp",
                HeaderText = "Срок",
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
                Logger.Error("System", "NAVIGATE_ERROR", "Попытка навигации без авторизованного пользователя");
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
                    Logger.Warning(currentUser.Login, "NAVIGATE_UNKNOWN_ROLE", $"Неизвестная роль: {userRole}");
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
                Logger.Warning("System", "PRODUCT_NOT_SELECTED", "Пользователь не выбрал товар");
                MessageBox.Show(Properties.Resources.ProductNotFound);
                cmbProduct.Focus();
                return;
            }
            if (dtpExpirationDate.Value.Date < DateTime.Now.Date)
            {
                Logger.Warning("System", "EXPIRATION_DATE_PAST", "Указана прошедшая дата срока годности");
                MessageBox.Show(Properties.Resources.ShipmentDatePastError);
                dtpExpirationDate.Focus();
                return;
            }
            if (!decimal.TryParse(qtyText, out decimal qty) || qty <= 0)
            {
                Logger.Warning("System", "INVALID_QUANTITY", "Количество должно быть больше 0");
                MessageBox.Show(Properties.Resources.InvalidQuantity);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price <= 0)
            {
                Logger.Warning("System", "INVALID_PRICE", "Цена закупки должна быть больше 0");
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
            Logger.Info("System", "ITEM_ADDED", $"Добавлено: {productName}, {qty} шт.");
        }
        private void txtboxcolichestvo_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"[Кол-во] Нажато: '{e.KeyChar}' | Код: {(int)e.KeyChar}");
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
                        }
                    }
                    db.Supplies.Add(supply);
                    db.SaveChanges();
                }
                currentSupply.Clear();
                dgvSupply.DataSource = null;
                Logger.Info(currentUser.Login, "SUPPLY_PROCESSED", $"Проведена поставка. Товаров: {currentSupply.Count}");
                MessageBox.Show(Properties.Resources.ShipmentSucces);
            }
            catch (Exception ex)
            {
                Logger.Error("System", "SUPPLY_SAVE_ERROR", ex.Message);
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
                    Logger.Error("System", "IMPORT_ERROR", ex.Message);
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
      

            
        
        

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма администратора для поставок
    /// </summary>
    public partial class ShipmentFormAdmin : Form
    {

        private class ShipmentViewItem
        {
            /// <summary>
            /// Уникальный идентификатор товара
            /// </summary>
            public Guid ProductId { get; set; }
            /// <summary>
            /// Наименование товара
            /// </summary>
            public string ProductName { get; set; }
            /// <summary>
            /// Количество товара, добавляемого в поставку
            /// </summary>
            public int Quantity { get; set; }
            /// <summary>
            /// Закупочная цена за единицу товара.
            /// </summary>
            public decimal PricePerUnit { get; set; }
            /// <summary>
            /// Остаток товара на складе
            /// </summary>
            public decimal CurrentStock { get; set; }
            /// <summary>
            /// Общая сумма позиции (цена × количество)
            /// </summary>
            public decimal TotalSum => PricePerUnit * Quantity;
        }
        private BindingList<ShipmentViewItem> cartList;

        /// <summary>
        /// Конструктор для формы поставок
        /// </summary>
        public ShipmentFormAdmin()
        {
            InitializeComponent();
            cartList = new BindingList<ShipmentViewItem>();
        }

        private void Shipment_Load(object sender, EventArgs e)
        {

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = cartList;

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Название",
                DataPropertyName = "ProductName",
                Width = 200
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Кол-во",
                DataPropertyName = "Quantity"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Цена за шт.",
                DataPropertyName = "PricePerUnit",
                DefaultCellStyle = { Format = "C2" }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Общая сумма",
                DataPropertyName = "TotalSum",
                ReadOnly = true,
                DefaultCellStyle = { Format = "C2" }
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Наличие",
                DataPropertyName = "CurrentStock",
                ReadOnly = true,
                DefaultCellStyle = { ForeColor = Color.Gray }
            });
            SetupAutoComplete();
        }
        private void SetupAutoComplete()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var names = db.Products.Select(p => p.NameProduct).ToArray();
                    var source = new AutoCompleteStringCollection();
                    source.AddRange(names);

                    txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtSearch.AutoCompleteCustomSource = source;
                }
            }
            catch { }
        }
        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is ShipmentViewItem item)
            {
                cartList.Remove(item);
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e) { }

        private void buttonToAddInTable_Click(object sender, EventArgs e)
        {
            string productName = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(productName)) return;

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                Logger.Warning("System", "NEGATIVE_STOCK", "Попытка установки отрицательный остаток");
                MessageBox.Show(Properties.Resources.NegativeStockWarning);
                return;
            }

            using (var db = new WarehouseContext())
            {
                var product = db.Products.FirstOrDefault(p => p.NameProduct == productName);
                if (product == null)
                {
                    Logger.Warning("System", "PRODUCT_NOT_FOUND", "Товар не найден в базе данных");
                    MessageBox.Show(Properties.Resources.ProductNotFound);
                    return;
                }

                int alreadyInCart = cartList.Where(x => x.ProductId == product.IdProducts).Sum(x => x.Quantity);
                if (product.Stock < (qty + alreadyInCart))
                {
                    Logger.Warning("System", "INSUFFICIENT_STOCK", "Недостаточное количество товара на складе");
                    MessageBox.Show(Properties.Resources.InsufficientStock);
                    return;
                }
                var existingItem = cartList.FirstOrDefault(x => x.ProductId == product.IdProducts);

                if (existingItem != null)
                {
                    existingItem.Quantity += qty;
                    cartList.ResetBindings();
                }
                else
                {
                    cartList.Add(new ShipmentViewItem
                    {
                        ProductId = product.IdProducts,
                        ProductName = product.NameProduct,
                        PricePerUnit = product.Price,
                        Quantity = qty,
                        CurrentStock = product.Stock
                    });
                }

                txtSearch.Text = "";
                txtQuantity.Text = "";
                txtSearch.Focus();
            }

        }

        private void buttonToHold_Click(object sender, EventArgs e)
        {
            if (cartList.Count == 0)
            {
                Logger.Warning("System", "EMPTY_PRODUCT_LIST", "Список товаров пуст");
                MessageBox.Show(Properties.Resources.EmptyProductList);
                return;
            }

            string clientName = txtCustomer.Text.Trim();
            if (string.IsNullOrEmpty(clientName))
            {
                Logger.Warning("System", "EMPTY_PRODUCT_LIST", "Список товаров пуст");
                MessageBox.Show(Properties.Resources.EmptyProductList);
                return;
            }

            try
            {
                using (var db = new WarehouseContext())
                {
                    var client = db.Clients.FirstOrDefault(c => c.NameClients == clientName);

                    if (client == null)
                    {
                        client = new Clients
                        {
                            IdClients = Guid.NewGuid(),
                            NameClients = clientName
                        };
                        db.Clients.Add(client);
                    }

                    var newShipment = new Shipment
                    {
                        IdShipment = Guid.NewGuid(),
                        DateOfShipment = datePicker.Value,
                        IdClients = client.IdClients,

                        PriceShipment = cartList.Sum(x => x.TotalSum),
                        Status = ShipmentStatus.Shipped
                    };

                    db.Shipments.Add(newShipment);
                    foreach (var item in cartList)
                    {
                        var productDb = db.Products.Find(item.ProductId);
                        if (productDb != null)
                        {
                            productDb.Stock -= item.Quantity;
                            var content = new ShipmentContents
                            {
                                IdShipmentContents = Guid.NewGuid(),
                                IdShipment = newShipment.IdShipment,
                                IdProducts = productDb.IdProducts,

                                QuantityShipmentContents = item.Quantity,
                                PriceShipmentContents = item.TotalSum
                            };

                            db.ShipmentContents.Add(content);
                        }
                    }
                    db.SaveChanges();
                    Logger.Info("System", "SHIPMENT_SUCCESS", "Отгрузка успешно проведена");
                    MessageBox.Show(Properties.Resources.ShipmentSucces);
                    cartList.Clear();
                    txtCustomer.Text = "";
                }
            }
            catch
            {
                Logger.Error("System", "SAVE_ERROR", "Ошибка сохранения данных");
                MessageBox.Show(Properties.Resources.SaveErrorText);
            }
        }
        private void buttonToDeleteShipment_Click(object sender, EventArgs e)
        {
            if (cartList.Count > 0)
            {
                Logger.Info("System", "CLEAR_LIST_PROMPT", "Запрос подтверждения очистки списка");
                var result = MessageBox.Show(Properties.Resources.ClearListTitle, Properties.Resources.ClearListTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cartList.Clear();
                    txtCustomer.Text = "";
                    txtSearch.Focus();
                }
            }
        }
        private void buttonToBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

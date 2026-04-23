using NLog;
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
    /// Форма кладовщика для управления поставками
    /// </summary>
    public partial class ShipmentFormStorekeeper : Form
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
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private BindingList<ShipmentViewItem> cartList;
        /// <summary>
        /// Конструктор для формы отгрузок
        /// </summary>
        public ShipmentFormStorekeeper()
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
                HeaderText = Properties.Resources.ColumnName,
                DataPropertyName = "ProductName",
                Width = 200
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Properties.Resources.ColumnQuantity,
                DataPropertyName = "Quantity"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Properties.Resources.ColumnPricePerUnit,
                DataPropertyName = "PricePerUnit",
                DefaultCellStyle = { Format = "C2" }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Properties.Resources.ColumnTotalAmount,
                DataPropertyName = "TotalSum",
                ReadOnly = true,
                DefaultCellStyle = { Format = "C2" }
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = Properties.Resources.ColumnAvailability,
                DataPropertyName = "CurrentStock",
                ReadOnly = true,
                DefaultCellStyle = { ForeColor = Color.Gray }
            });
            dgv.ReadOnly = true;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.HeaderText == "Цена за шт.")
                {
                    col.ReadOnly = true;
                    col.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
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
                logger.Warn("NEGATIVE_STOCK. Category: {Category}", "System", "Попытка установки отрицательный остаток");
                MessageBox.Show(Properties.Resources.NegativeStockWarning);
                return;
            }

            using (var db = new WarehouseContext())
            {
                var product = db.Products.FirstOrDefault(p => p.NameProduct == productName);
                if (product == null)
                {
                    logger.Warn("PRODUCT_NOT_FOUND. Category: {Category}", "System", "Товар не найден");
                    MessageBox.Show(Properties.Resources.ProductNotFound);
                    return;
                }

                int alreadyInCart = cartList.Where(x => x.ProductId == product.IdProducts).Sum(x => x.Quantity);
                if (product.Stock < (qty + alreadyInCart))
                {
                    logger.Warn("INSUFFICIENT_STOCK. Category: {Category}", "System", "Недостаточное количество товара на складе");
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
            DateTime shipmentDate = datePicker.Value;

            if (shipmentDate < DateTime.Today)
            {
                logger.Warn("SHIPMENT_DATE_PAST. Category: {Category}", "System", "Попытка указать дату отгрузки в прошлом");
                MessageBox.Show(Properties.Resources.ShipmentDatePastError);
                return;
            }
            if (shipmentDate > DateTime.Today.AddYears(1))
            {
                logger.Warn("SHIPMENT_DATE_FUTURE. Category: {Category}", "System", "Попытка указать дату отгрузки в будущем");
                MessageBox.Show(Properties.Resources.ShipmentDateFutureError);
                return;
            }
            if (cartList.Count == 0)
            {
                logger.Warn("EMPTY_PRODUCT_LIST. Category: {Category}", "System", "Список товаров пуст");
                MessageBox.Show(Properties.Resources.EmptyProductList);
                return;
            }
            string clientName = txtCustomer.Text.Trim();
            if (string.IsNullOrEmpty(clientName))
            {
                logger.Warn("EMPTY_PRODUCT_LIST. Category: {Category}", "System", "Список товаров пуст");
                MessageBox.Show(Properties.Resources.EmptyProductList);
                return;
            }
            try
            {
                using (var db = new WarehouseContext())
                {
                    foreach (var item in cartList)
                    {
                        var productExists = db.Products.Any(p => p.IdProducts == item.ProductId);
                        if (!productExists)
                        {
                            logger.Warn("PRODUCT_NOT_FOUND. Category: {Category}", "System", "Товар не найден");
                            MessageBox.Show(Properties.Resources.ProductNotFound);
                            return;
                        }
                    }
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
                    logger.Info("SHIPMENT_SUCCESS. Category: {Category}", "System", "Отгрузка успешно проведена");
                    MessageBox.Show(Properties.Resources.ShipmentSucces);
                    cartList.Clear();
                    txtCustomer.Text = "";
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex, "SAVE_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.SaveErrorText);
            }
        }
            
        private void buttonToDeleteShipment_Click(object sender, EventArgs e)
        {
            if (cartList.Count > 0)
            {
                logger.Info("CLEAR_LIST_PROMPT. Category: {Category}", "System", "Подтверждение очистки списка");
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
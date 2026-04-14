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
    public partial class ShipmentFormStorekeeper : Form
    {

        private class ShipmentViewItem
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal PricePerUnit { get; set; }
            public decimal CurrentStock { get; set; }

            public decimal TotalSum => PricePerUnit * Quantity;
        }
        private BindingList<ShipmentViewItem> _cartList;

        public ShipmentFormStorekeeper()
        {
            InitializeComponent();
            _cartList = new BindingList<ShipmentViewItem>();
        }

        private void Shipment_Load(object sender, EventArgs e)
        {

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _cartList;

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
                _cartList.Remove(item);
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e) { }

        private void buttonToAddInTable_Click(object sender, EventArgs e)
        {
            string productName = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(productName)) return;

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Введите корректное целое количество!");
                return;
            }

            using (var db = new WarehouseContext())
            {
                var product = db.Products.FirstOrDefault(p => p.NameProduct == productName);
                if (product == null)
                {
                    MessageBox.Show("Товар не найден!");
                    return;
                }

                int alreadyInCart = _cartList.Where(x => x.ProductId == product.IdProducts).Sum(x => x.Quantity);
                if (product.Stock < (qty + alreadyInCart))
                {
                    MessageBox.Show($"Недостаточно товара! На складе: {product.Stock}");
                    return;
                }
                var existingItem = _cartList.FirstOrDefault(x => x.ProductId == product.IdProducts);

                if (existingItem != null)
                {
                    existingItem.Quantity += qty;
                    _cartList.ResetBindings();
                }
                else
                {
                    _cartList.Add(new ShipmentViewItem
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
                MessageBox.Show("Дата отгрузки не может быть в прошлом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (shipmentDate > DateTime.Today.AddYears(1))
            {
                MessageBox.Show("Дата отгрузки не может быть так нескоро!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_cartList.Count == 0)
            {
                MessageBox.Show("Список товаров пуст!");
                return;
            }
            string clientName = txtCustomer.Text.Trim();
            if (string.IsNullOrEmpty(clientName))
            {
                MessageBox.Show("Заполните поле 'Кому'!");
                return;
            }
            try
            {
                using (var db = new WarehouseContext())
                {
                    foreach (var item in _cartList)
                    {
                        var productExists = db.Products.Any(p => p.IdProducts == item.ProductId);
                        if (!productExists)
                        {
                            MessageBox.Show($"Ошибка: Товар '{item.ProductName}' отсутствует в каталоге!\nОтгрузка невозможна.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        PriceShipment = _cartList.Sum(x => x.TotalSum),
                        Status = ShipmentStatus.Shipped
                    };

                    db.Shipments.Add(newShipment);

                    foreach (var item in _cartList)
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
                    MessageBox.Show("Отгрузка успешно проведена!");
                    _cartList.Clear();
                    txtCustomer.Text = "";
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null) msg += "\n" + ex.InnerException.Message;
                MessageBox.Show("Ошибка сохранения: " + msg);
            }
        }
            
        private void buttonToDeleteShipment_Click(object sender, EventArgs e)
        {
            if (_cartList.Count > 0)
            {
                var result = MessageBox.Show("Очистить весь список товаров?", "Очистка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _cartList.Clear();
                    txtCustomer.Text = "";
                    txtSearch.Focus();
                }
            }
        }

        private void buttonToBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
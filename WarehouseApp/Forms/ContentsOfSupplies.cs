using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.ClassesContext;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма для просмотра и управления поставками
    /// </summary>
    public partial class ContentsOfSupplies : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Guid supplyId;
        /// <summary>
        /// Конструктор для формы поставок 
        /// </summary>
        public ContentsOfSupplies(Guid supplyId)
        {
            InitializeComponent();
            this.supplyId = supplyId;
            SetupGrid();
            LoadSupplyData();
        }
        private void SetupGrid()
        {
            dgvItems.AutoGenerateColumns = false;
            dgvItems.Columns.Clear();

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProduct",
                HeaderText = Properties.Resources.ColumnProduct,
                DataPropertyName = "ProductName",
                Width = 200,
                ReadOnly = true
            });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQty",
                HeaderText = Properties.Resources.ColumnQuantity,
                DataPropertyName = "Quantity",
                Width = 100,
                ReadOnly = true
            });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = Properties.Resources.ColumnPurchasePrice,
                DataPropertyName = "Price",
                Width = 120,
                DefaultCellStyle = { Format = "0.00 ₽", Alignment = DataGridViewContentAlignment.MiddleRight },
                ReadOnly = true
            });
            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colExp",
                HeaderText = Properties.Resources.ColumnExpirationDate,
                DataPropertyName = "ExpirationDisplay",
                Width = 120,
                ReadOnly = true
            });
        }
        private void LoadSupplyData()
        {
            using (var db = new WarehouseContext())
            {
                var supply = db.Supplies.Where(s => s.Id == supplyId).FirstOrDefault();

                if (supply == null)
                {
                    logger.Warn("SUPPLY_NOT_FOUND. Category: {Category}", "System", $"Поставка с ID {supplyId} не найдена в базе данных");
                    MessageBox.Show(Properties.Resources.SupplyNotFound);
                    Close();
                    return;
                }
                txtDate.Text = supply.Date.ToString("dd.MM.yyyy");
                txtDocNumber.Text = $"П-{supply.Id.ToString().Substring(0, 3).ToUpper()}";
                var dbItems = db.SupplyItems.Where(si => si.SupplyId == supplyId).ToList();
                List<SupplyItemRow> items = new List<SupplyItemRow>();
                foreach (var si in dbItems)
                {
                    SupplyItemRow row = new SupplyItemRow();
                    if (si.Product != null)
                    {
                        row.ProductName = si.Product.NameProduct;
                    }
                    else
                    {
                        row.ProductName = "Товар удалён";
                    }
                    row.Quantity = si.Quantity;
                    row.Price = si.Price;
                    if (si.ExpirationDate.Year > 2000)
                    {
                        row.ExpirationDisplay = si.ExpirationDate.ToString("dd.MM.yyyy");
                    }
                    else
                    {
                        row.ExpirationDisplay = "—";
                    }

                    items.Add(row);
                }
                dgvItems.DataSource = items;
            }
        }
        private void buttonToBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    /// <summary>
    /// Таблица состава поставки
    /// </summary>
    public class SupplyItemRow
    {
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Цена закупки
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Срок годности (строка для отображения "—" если даты нет)
        /// </summary>
        public string ExpirationDisplay { get; set; }
    }
}

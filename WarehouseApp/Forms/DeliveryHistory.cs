using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.ClassesContext;
using NLog;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма для просмотра истории поставок
    /// </summary>
    public partial class DeliveryHistory : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<SupplyHistoryRow> allHistoryRows = new List<SupplyHistoryRow>();  //Кэш поставок для фильтрации
        /// <summary>
        ///Конструктор для истории поставок
        /// </summary>
        public DeliveryHistory()
        {
            InitializeComponent();
            SetupHistoryGrid();
            LoadHistory();
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
        }
        private void buttonToAddInTable_Click(object sender, EventArgs e)
        {
            Supplies supplies = new Supplies();
            supplies.Show();
            Close();
        }
        private void buttonToBack_Click(object sender, EventArgs e)
        {
            Supplies supplies = new Supplies();
            supplies.Show();
            Close();
        }
        private void SetupHistoryGrid()
        {
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = Properties.Resources.ColumnDate,
                DataPropertyName = "Date",
                Width = 100,
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDocNum",
                HeaderText = Properties.Resources.ColumnDocumentNumber,
                DataPropertyName = "DocumentNumber",
                Width = 100
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSum",
                HeaderText = Properties.Resources.ColumnAmount,
                DataPropertyName = "TotalSum",
                Width = 100,
                DefaultCellStyle = { Format = "0.00 ₽", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            var btnColumn = new DataGridViewButtonColumn
            {
                Name = "colAction",
                HeaderText = Properties.Resources.ColumnContents,
                Text = "Открыть",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvHistory.Columns.Add(btnColumn);
        }
        private void LoadHistory()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var supplies = db.Supplies
                        .OrderByDescending(s => s.Date)
                        .ToList();
                    allHistoryRows.Clear();

                    foreach (var supply in supplies)
                    {
                        var items = db.SupplyItems.Where(si => si.SupplyId == supply.Id).ToList();
                        decimal totalSum = 0;
                        foreach (var item in items)
                            totalSum += item.Quantity * item.Price;

                        string docNumber = $"П-{supply.Id.ToString().Substring(0, 4).ToUpper()}";

                        allHistoryRows.Add(new SupplyHistoryRow
                        {
                            SupplyId = supply.Id,
                            Date = supply.Date,
                            DocumentNumber = docNumber,
                            TotalSum = totalSum
                        });
                    }
                }
                ApplyFilters();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "HISTORY_LOAD_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
            }
        }
        private void ApplyFilters()
        {
            IEnumerable<SupplyHistoryRow> query = allHistoryRows;
            string search = txtSearch.Text.Trim();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(row =>
                    row.DocumentNumber.ToLower().Contains(search.ToLower()));
            }
            if (dtpFrom.Checked)
            {
                DateTime from = dtpFrom.Value.Date;
                query = query.Where(row => row.Date.Date >= from);
            }
            if (dtpTo.Checked)
            {
                DateTime to = dtpTo.Value.Date;
                query = query.Where(row => row.Date.Date <= to);
            }
            dgvHistory.DataSource = query.ToList();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHistory.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                var selectedRow = dgvHistory.Rows[e.RowIndex].DataBoundItem as SupplyHistoryRow;

                if (selectedRow != null)
                {
                    Guid supplyId = selectedRow.SupplyId;
                    ContentsOfSupplies detailsForm = new ContentsOfSupplies(supplyId);
                    detailsForm.ShowDialog();
                }
            }
        }
    }
    /// <summary>
    /// Таблицы истории поставок
    /// </summary>
    public class SupplyHistoryRow
    {
        /// <summary>
        /// ID поставки
        /// </summary>
        public Guid SupplyId { get; set; }

        /// <summary>
        /// Дата проведения поставки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Общая сумма поставки
        /// </summary>
        public decimal TotalSum { get; set; }
    }
}

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
        private bool updatingDateLimits;
        /// <summary>
        ///Конструктор для истории поставок
        /// </summary>
        public DeliveryHistory()
        {
            InitializeComponent();
            WarehouseApp.ResponsiveFormHelper.Enable(this);
            if (UserContext.Current != null)
                labelAdmin.Text = UserDisplayHelper.GetRoleName(UserContext.Current.Role);
            ConfigureDatePickers();
            SetupHistoryGrid();
            LoadHistory();
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
        }
        private void buttonToAddInTable_Click(object sender, EventArgs e)
        {
            var supplies = AppServices.Get<Supplies>();
            FormNavigationHelper.Show(this, supplies);
            Close();
        }
        private void buttonToBack_Click(object sender, EventArgs e)
        {
            var supplies = AppServices.Get<Supplies>();
            FormNavigationHelper.Show(this, supplies);
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
                        var totalSum = 0m;
                        foreach (var item in items)
                            totalSum += item.Quantity * item.Price;

                        var docNumber = $"П-{supply.Id.ToString().Substring(0, 4).ToUpper()}";

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
            var search = txtSearch.Text.Trim();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(row =>
                    row.DocumentNumber.ToLower().Contains(search.ToLower()));
            }
            if (dtpFrom.Checked)
            {
                var from = dtpFrom.Value.Date;
                query = query.Where(row => row.Date.Date >= from);
            }
            if (dtpTo.Checked)
            {
                var to = dtpTo.Value.Date;
                query = query.Where(row => row.Date.Date <= to);
            }
            dgvHistory.DataSource = query.ToList();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ConfigureDatePickers()
        {
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            dtpFrom.MaxDate = DateTime.Today.AddDays(1).AddTicks(-1);
            dtpTo.MaxDate = DateTime.Today.AddDays(1).AddTicks(-1);
            UpdateDateLimits();
        }

        private void UpdateDateLimits()
        {
            if (updatingDateLimits)
                return;

            try
            {
                updatingDateLimits = true;

                var todayEnd = DateTime.Today.AddDays(1).AddTicks(-1);

                dtpFrom.MaxDate = dtpTo.Checked && dtpTo.Value.Date < DateTime.Today
                    ? dtpTo.Value.Date
                    : todayEnd;

                dtpTo.MinDate = dtpFrom.Checked
                    ? dtpFrom.Value.Date
                    : DateTimePicker.MinimumDateTime;

                dtpTo.MaxDate = todayEnd;

                if (dtpFrom.Checked && dtpTo.Checked && dtpFrom.Value.Date > dtpTo.Value.Date)
                    dtpTo.Value = dtpFrom.Value.Date;
            }
            finally
            {
                updatingDateLimits = false;
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLimits();
            ApplyFilters();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLimits();
            ApplyFilters();
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHistory.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                var selectedRow = dgvHistory.Rows[e.RowIndex].DataBoundItem as SupplyHistoryRow;

                if (selectedRow != null)
                {
                    var supplyId = selectedRow.SupplyId;
                    var detailsForm = AppServices.Get<Func<Guid, ContentsOfSupplies>>()(supplyId);
                    FormNavigationHelper.ShowDialog(this, detailsForm);
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

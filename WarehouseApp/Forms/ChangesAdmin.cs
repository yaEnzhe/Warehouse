using System;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using NLog;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма администратора для просмотра отчетов
    /// </summary>
    public partial class ChangesAdmin : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Конструктор для отчетов
        /// </summary>
        public ChangesAdmin()
        {
            InitializeComponent();
        }

        private void Changes_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = $"Дата: {DateTime.Now:dd.MM.yyyy}";
                DateTime end = DateTime.Today;
                DateTime start = end.AddDays(-30);
                dtpFrom.Value = start;
                dtpTo.Value = end;
                LoadCustomers();
                LoadCategories();
                SetupGrid();
                LoadReportData(start, end);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "REPORTS_LOAD_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.StartupError);
                Close();
            }
        }
        private void LoadCustomers()
        {
            using (var db = new WarehouseContext())
            {
                var customers = db.Clients.ToList();
                cmbCustomer.Items.Clear();
                cmbCustomer.Items.Add("Все");
                foreach (var c in customers)
                {
                    cmbCustomer.Items.Add(c.NameClients);
                }
                cmbCustomer.SelectedIndex = 0;
            }
        }
        private void LoadCategories()
        {
            using (var db = new WarehouseContext())
            {
                var categories = db.Categories.ToList();
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("Все");
                foreach (var c in categories)
                {
                    cmbCategory.Items.Add(c.NameCategory);
                }
                cmbCategory.SelectedIndex = 0;
            }
        }
        private void SetupGrid()
        {
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = Properties.Resources.ReportColDate,
                Width = 120,
                DataPropertyName = "Date",
                DefaultCellStyle = { Format = "dd.MM.yyyy" }
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCustomer",
                HeaderText = Properties.Resources.ReportColCustomer,
                Width = 200,
                DataPropertyName = "Customer"
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAmount",
                HeaderText = Properties.Resources.ReportColAmount,
                Width = 150,
                DataPropertyName = "Amount",
                DefaultCellStyle = { Format = "0.00 ₽", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProfit",
                HeaderText = Properties.Resources.ReportColProfit,
                Width = 150,
                DataPropertyName = "Profit",
                DefaultCellStyle = { Format = "0.00 ₽", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void LoadReportData(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    string selectedCustomer = cmbCustomer.SelectedItem?.ToString();
                    string selectedCategory = cmbCategory.SelectedItem?.ToString();
                    DateTime start = startDate.Date;
                    DateTime end = endDate.Date.AddDays(1).AddTicks(-1);
                    var query = db.Shipments
                        .Include("Clients")
                        .Include("ShipmentContents.Product.Category")
                        .Where(s => s.DateOfShipment >= start && s.DateOfShipment <= end);
                    if (selectedCustomer != "Все")
                    {
                        query = query.Where(s => s.Clients != null && s.Clients.NameClients == selectedCustomer);
                    }
                    if (selectedCategory != "Все")
                    {
                        query = query.Where(s => s.ShipmentContents.Any(sc =>
                            sc.Product != null &&
                            sc.Product.Category != null &&
                            sc.Product.Category.NameCategory == selectedCategory));
                    }
                    var shipments = query.OrderByDescending(s => s.DateOfShipment).ToList();
                    var reportData = shipments.Select(s => new
                    {
                        Date = s.DateOfShipment,
                        Customer = (s.Clients != null ? s.Clients.NameClients : "Не указан"),
                        Amount = s.PriceShipment,
                        Profit = CalculateProfit(s)
                    }).ToList();

                    dgvHistory.DataSource = reportData;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "REPORTS_LOAD_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
            }
        }
        private decimal CalculateProfit(Shipment shipment)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var contents = db.ShipmentContents
                        .Where(sc => sc.IdShipment == shipment.IdShipment)
                        .ToList();

                    decimal totalProfit = 0;

                    foreach (var content in contents)
                    {
                        var product = db.Products.Find(content.IdProducts);

                        if (product != null)
                        {
                            decimal revenue = content.PriceShipmentContents;
                            decimal cost = product.Price * content.QuantityShipmentContents;
                            decimal itemProfit = revenue - cost;
                            totalProfit += itemProfit;
                        }
                    }
                    return totalProfit;
                }
            }
            catch
            {
                return 0;
            }
        }

        private void DatePickers_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = dtpFrom.Value.Date;
            DateTime end = dtpTo.Value.Date;

            if (!ValidatePeriod(start, end, out string error))
            {
                logger.Warn("DATE_VALIDATION_ERROR. Category: {Category}", "System", error);
                MessageBox.Show(Properties.Resources.DataLoadErrorText);

                dtpTo.ValueChanged -= DatePickers_ValueChanged;
                dtpFrom.ValueChanged -= DatePickers_ValueChanged;

                dtpTo.Value = DateTime.Today;
                dtpFrom.Value = DateTime.Today.AddDays(-30);

                dtpTo.ValueChanged += DatePickers_ValueChanged;
                dtpFrom.ValueChanged += DatePickers_ValueChanged;
                return;
            }

            LoadReportData(start, end);
        }
        private void Filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime start = dtpFrom.Value.Date;
            DateTime end = dtpTo.Value.Date;
            LoadReportData(start, end);
        }

        private bool ValidatePeriod(DateTime start, DateTime end, out string errorMessage)
        {
            errorMessage = "";

            if (start > end)
            {
                errorMessage = Properties.Resources.ErrorDateStartAfterEnd;
                return false;
            }

            if (start > DateTime.Today || end > DateTime.Today)
            {
                errorMessage = Properties.Resources.ErrorDateFutureNotAllowed;
                return false;
            }

            return true;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count == 0)
            {
                logger.Info("EXPORT_ATTEMPT_EMPTY. Category: {Category}", "System", "Попытка экспорта отчёта без данных");
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV файл|*.csv|Все файлы|*.*";
                saveFileDialog.Title = "Экспорт отчёта в CSV";
                saveFileDialog.FileName = $"Отчёт_{DateTime.Now:yyyy-MM-dd}.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToCsv(saveFileDialog.FileName);
                        logger.Info("EXPORT_SUCCESS. Category: {Category}", "System", $"Экспорт выполнен: {saveFileDialog.FileName}");
                        MessageBox.Show(Properties.Resources.SuccessMessage);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "EXPORT_ERROR. Category: {Category}", "System");
                        MessageBox.Show(Properties.Resources.SaveErrorText);
                    }
                }
            }
        }
        private void ExportToCsv(string filePath)
        {
            using (var writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                var headers = new System.Collections.Generic.List<string>();
                foreach (DataGridViewColumn column in dgvHistory.Columns)
                {
                    if (column.Visible)
                        headers.Add(column.HeaderText);
                }
                writer.WriteLine(string.Join(";", headers));
                foreach (DataGridViewRow row in dgvHistory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cells = new System.Collections.Generic.List<string>();
                        foreach (DataGridViewColumn column in dgvHistory.Columns)
                        {
                            if (column.Visible)
                            {
                                var value = row.Cells[column.Index].Value;
                                string cellValue = value?.ToString()?.Replace(";", ",") ?? "";
                                cells.Add(cellValue);
                            }
                        }
                        writer.WriteLine(string.Join(";", cells));
                    }
                }
            }
        }

        private void buttonForBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
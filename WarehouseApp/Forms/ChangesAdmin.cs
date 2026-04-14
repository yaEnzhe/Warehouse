using System;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.ClassesContext;

namespace WarehouseApp.Forms
{
    public partial class ChangesAdmin : Form
    {
        public ChangesAdmin()
        {
            InitializeComponent();
        }

        private void Changes_Load(object sender, EventArgs e)
        {
            DateTime end = DateTime.Today;
            DateTime start = end.AddDays(-30);

            dtpFrom.Value = start;
            dtpTo.Value = end;

            LoadShipmentHistory(start, end);

            dtpFrom.ValueChanged += DatePickers_ValueChanged;
            dtpTo.ValueChanged += DatePickers_ValueChanged;

            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void DatePickers_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = dtpFrom.Value;
            DateTime end = dtpTo.Value;

            if (!ValidatePeriod(start, end, out string error))
            {
                MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dtpTo.ValueChanged -= DatePickers_ValueChanged;
                dtpFrom.ValueChanged -= DatePickers_ValueChanged;

                dtpTo.Value = DateTime.Today;
                dtpFrom.Value = DateTime.Today.AddDays(-30);

                dtpTo.ValueChanged += DatePickers_ValueChanged;
                dtpFrom.ValueChanged += DatePickers_ValueChanged;

                return;
            }

            LoadShipmentHistory(start, end);
        }

        private bool ValidatePeriod(DateTime start, DateTime end, out string errorMessage)
        {
            errorMessage = "";

            if (start > end)
            {
                errorMessage = "Дата начала не может быть позже даты окончания!";
                return false;
            }

            if (start > DateTime.Today || end > DateTime.Today)
            {
                errorMessage = "Нельзя выбирать будущие даты!";
                return false;
            }

            return true;
        }

        private void LoadShipmentHistory(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var shipments = db.Shipments
                        .Where(s => s.DateOfShipment >= startDate && s.DateOfShipment <= endDate)
                        .OrderByDescending(s => s.DateOfShipment)
                        .ToList();

                    dgvHistory.DataSource = shipments;

                    if (dgvHistory.Columns.Contains("DateOfShipment"))
                        dgvHistory.Columns["DateOfShipment"].HeaderText = "Дата отгрузки";

                    if (dgvHistory.Columns.Contains("PriceShipment"))
                        dgvHistory.Columns["PriceShipment"].HeaderText = "Сумма";

                    if (dgvHistory.Columns.Contains("IdClients"))
                        dgvHistory.Columns["IdClients"].HeaderText = "ID Клиента";

                    if (dgvHistory.Columns.Contains("Status"))
                        dgvHistory.Columns["Status"].HeaderText = "Статус";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки истории: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonForBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
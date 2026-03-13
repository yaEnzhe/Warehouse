using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class Changes : Form
    {
        private BindingSource changeLogBindingSource;
        public Changes()
        {
            InitializeComponent();
            changeLogBindingSource = new BindingSource();
            dgv.DataSource = changeLogBindingSource;
        }

        private void Changes_Load(object sender, EventArgs e)
        {
            ConfigureChangeLogGrid();
            dateTimePickerTo.Value = DateTime.Today;
            dateTimePickerFrom.Value = DateTime.Today.AddDays(-30);
            dateTimePickerFrom.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePickerTo.ValueChanged += DateTimePicker_ValueChanged;
            ApplyDateFilter();
        }
        private void ConfigureChangeLogGrid()
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;

            dgv.BackgroundColor = Color.Gainsboro;
            dgv.BorderStyle = BorderStyle.None;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 45;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgv.DefaultCellStyle.BackColor = Color.Gainsboro;
            dgv.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.GridColor = Color.Black;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.Columns.Clear();

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.DataPropertyName = "Date";
            dateColumn.HeaderText = "Дата";
            dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
            dateColumn.FillWeight = 20;
            dgv.Columns.Add(dateColumn);

            DataGridViewTextBoxColumn userColumn = new DataGridViewTextBoxColumn();
            userColumn.DataPropertyName = "User";
            userColumn.HeaderText = "Пользователь";
            userColumn.FillWeight = 25;
            dgv.Columns.Add(userColumn);

            DataGridViewTextBoxColumn actionColumn = new DataGridViewTextBoxColumn();
            actionColumn.DataPropertyName = "Action";
            actionColumn.HeaderText = "Действие";
            actionColumn.FillWeight = 25;
            dgv.Columns.Add(actionColumn);

            DataGridViewTextBoxColumn detailsColumn = new DataGridViewTextBoxColumn();
            detailsColumn.DataPropertyName = "Details";
            detailsColumn.HeaderText = "Детали";
            detailsColumn.FillWeight = 30;
            dgv.Columns.Add(detailsColumn);
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ApplyDateFilter();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelForPeriod_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ApplyDateFilter()
        {
            DateTime startDate = dateTimePickerFrom.Value.Date;
            DateTime endDate = dateTimePickerTo.Value.Date.AddDays(1).AddTicks(-1);

            List<ChangeLogEntry> filteredEntries = new List<ChangeLogEntry>();

            int index;
            for (index = 0; index < ChangeLogStore.Entries.Count; index++)
            {
                ChangeLogEntry entry = ChangeLogStore.Entries[index];

                if (entry.Date >= startDate && entry.Date <= endDate)
                {
                    filteredEntries.Add(entry);
                }
            }

            filteredEntries.Sort(CompareByDateDescending);

            changeLogBindingSource.DataSource = filteredEntries;
            changeLogBindingSource.ResetBindings(false);
        }
        private static int CompareByDateDescending(ChangeLogEntry firstEntry, ChangeLogEntry secondEntry)
        {
            return secondEntry.Date.CompareTo(firstEntry.Date);
        }
    }
}

using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LoadData();
            SetupDatagrid();
            LoadHistoryData();
        }
        private void SetupDatagrid()
        {
            dgvHistory
            .AutoGenerateColumns = false;
            dgvHistory
            .Columns.Clear();

            dgvHistory
            .Columns.Add("ColDate", "Дата");
            dgvHistory
            .Columns.Add("ColUser", "Пользователь");
            dgvHistory
            .Columns.Add("ColAction", "Действие");
            dgvHistory
            .Columns.Add("ColDetails", "Детали");
            dgvHistory
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory
            .RowHeadersVisible = false;
            dgvHistory
            .EnableHeadersVisualStyles = false;
            dgvHistory
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvHistory
           .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistory
            .ColumnHeadersHeight = 30; 
            dgvHistory
            .AllowUserToAddRows = false;
            dgvHistory
            .BorderStyle = BorderStyle.None;
            dgvHistory
            .BackgroundColor = Color.White;
        }
        private void LoadData()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    var historyList = db.ActionHistory
                                        .Include("User")
                                        .OrderByDescending(h => h.EventData)
                                        .ToList();

                    dgvHistory
                    .Rows.Clear();
                    foreach (var item in historyList)
                    {
                        string userName = "Неизвестно";
                        if (item.User != null)
                        {
                            string n = string.IsNullOrEmpty(item.User.Name) ? "" : item.User.Name.Substring(0, 1) + ".";
                            string p = string.IsNullOrEmpty(item.User.Patronymic) ? "" : item.User.Patronymic.Substring(0, 1) + ".";
                            userName = $"{item.User.Surname} {n}{p}";
                        }

                    dgvHistory
                        .Rows.Add(
                            item.EventData.ToString("dd.MM.yyyy HH:mm"),
                            userName,
                            item.Action,
                            item.Details
                        );
                    }

                    if (historyList.Any())
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

        }
        private void LoadHistoryData()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    
                    var historyList = db.ActionHistory
                                        .Include("User")
                                        .OrderByDescending(h => h.EventData) 
                                        .ToList();
                    dgvHistory.Rows.Clear();
                    foreach (var item in historyList)
                    {
                        string userFIO = "Неизвестно";
                        if (item.User != null)
                        {
                            string name = string.IsNullOrEmpty(item.User.Name) ? "" : item.User.Name.Substring(0, 1) + ".";
                            string patronynic = string.IsNullOrEmpty(item.User.Patronymic) ? "" : item.User.Patronymic.Substring(0, 1) + ".";
                            userFIO = $"{item.User.Surname} {name}{patronynic}";
                        }
                        dgvHistory.Rows.Add(
                            item.EventData.ToString("dd.MM.yyyy HH:mm"), 
                            userFIO,
                            item.Action,
                            item.Details
                        );
                    }

                    if (historyList.Count > 0)
                    {
                        var minDate = historyList.Min(x => x.EventData);
                        var maxDate = historyList.Max(x => x.EventData);


                        labelPeriod.Text = $"{minDate:dd.MM.yyyy} по {maxDate:dd.MM.yyyy}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonForBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
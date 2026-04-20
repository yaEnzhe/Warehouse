using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;
using static WarehouseApp.Classes.User;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма управления поставками
    /// </summary>
    public partial class Supplies : Form
    {
        private readonly WarehouseContext context = new WarehouseContext();
        private List<Products> productsList = new List<Products>();
        /// <summary>
        /// Конструктор для формы управления поставками
        /// </summary>
        public Supplies()
        {
            InitializeComponent();
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
        }
        private void btnhistori_Click(object sender, EventArgs e)
        {
            DeliveryHistory deliveryHistory = new DeliveryHistory();
            deliveryHistory.Show();
            Close();
        }
    }
}

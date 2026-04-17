using System;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class DeliveryHistory : Form
    {
        public DeliveryHistory()
        {
            InitializeComponent();
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
        }
        private void buttonToAddInTable_Click(object sender, EventArgs e)
        {
            Supplies supplies = new Supplies();
            supplies.Show();
            Close();
        }

    }
}

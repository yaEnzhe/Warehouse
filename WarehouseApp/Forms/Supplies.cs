using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;
using WarehouseApp.Enums;

namespace WarehouseApp.Forms
{
    public partial class Supplies : Form
    {
        private readonly WarehouseContext context = new WarehouseContext();
        private List<Products> productsList = new List<Products>();
        public Supplies()
        {
            InitializeComponent();
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void buttonToBack_Click(object sender, EventArgs e)
        {
            string fullName = $"{User.CurrentUser.Surname} {User.CurrentUser.Name[0]}.{User.CurrentUser.Patronymic?[0] + "."}";

            if (User.CurrentUser.Role == Roles.Administrator)
            {
                MainMenuAdminForm adminMenu = new MainMenuAdminForm(fullName);
                adminMenu.Show();
                this.Close();
            }
            else if (User.CurrentUser.Role == Roles.Storekeeper)
            {
                MainMenuStorekeeperForm storekeeperMenu = new MainMenuStorekeeperForm(fullName);
                storekeeperMenu.Show();
                Close();
            }
        }
        private void btnhistori_Click(object sender, EventArgs e)
        {
            DeliveryHistory deliveryHistory = new DeliveryHistory();
            deliveryHistory.Show();
            Close();
        }
    }
}

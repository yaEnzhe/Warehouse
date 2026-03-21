using System;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class MainMenuStorekeeperForm : Form
    {
        public string UserName { get; set; }
        public MainMenuStorekeeperForm(string userName)
        {
            InitializeComponent();
            UserName = userName;
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
            txtWelcome.Text = $"Добро пожаловать, {UserName} ";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

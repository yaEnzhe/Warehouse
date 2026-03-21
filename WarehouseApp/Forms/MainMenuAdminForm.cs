using System;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public partial class MainMenuAdminForm : Form
    {
        public string UserName { get; set; }
        public MainMenuAdminForm(string userName)
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


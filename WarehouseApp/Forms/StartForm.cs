using System;

using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}

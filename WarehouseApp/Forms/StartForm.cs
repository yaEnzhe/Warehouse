using System;

using System.Windows.Forms;

namespace WarehouseApp
{
    /// <summary>
    /// Класс стартовой формы
    /// </summary>
    public partial class StartForm : Form
    {
        /// <summary>
        /// конструктор класса стартовой формы
        /// </summary>
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

using System;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// класс главной формы администратора
    /// </summary>
    public partial class MainMenuAdminForm : Form
    {
        /// <summary>
        /// ФИО либо ФИ пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// конструктор класса главной формы кладовщика
        /// </summary>
        /// <param name="userName"> ФИО либо ФИ пользователя</param>
        public MainMenuAdminForm(string userName)
        {
            InitializeComponent();
            UserName = userName;
            txtDate.Text = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy");
            txtWelcome.Text = $"{Properties.Resources.Welcome}{UserName}";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


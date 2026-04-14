using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseApp.Forms
{
    public static class LoginFormManager
    {
        private static LoginForm loginForm = null;

        /// <summary>
        /// открывает форму логина, если форма уже открыта снова открывает её.
        /// </summary>
        public static void ShowLoginForm()
        {
            if (loginForm != null && !loginForm.IsDisposed)
            {
                loginForm.Activate();
                loginForm.WindowState = FormWindowState.Normal;
                return;
            }
            loginForm = new LoginForm();
            loginForm.FormClosed += new FormClosedEventHandler(OnLoginFormClosed);
            loginForm.Show();
        }
        /// <summary>
        /// вызывается при закрытии формы, чтобы можно было создать новую форму
        /// </summary>
        private static void OnLoginFormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm = null;
        }
        /// <summary>
        /// закрывает форму логина, если она открыта.
        /// </summary>
        public static void CloseLoginForm()
        {
            if (loginForm != null && !loginForm.IsDisposed)
            {
                loginForm.Close();
            }
        }
    }
}

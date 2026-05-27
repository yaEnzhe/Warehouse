

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
            ResponsiveFormHelper.Enable(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var loginForm = AppServices.Get<LoginForm>();
            FormNavigationHelper.Show(this, loginForm);
        }


    }
}

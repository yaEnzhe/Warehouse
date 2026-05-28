
using NLog;

namespace WarehouseApp
{
    /// <summary>
    /// Класс стартовой формы
    /// </summary>
    public partial class StartForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// конструктор класса стартовой формы
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
            ResponsiveFormHelper.Enable(this);
            LanguageManager.ApplyControls(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            logger.Info("START_BUTTON_CLICKED. Category: {Category}", "System");
            var loginForm = AppServices.Get<LoginForm>();
            FormNavigationHelper.Show(this, loginForm);
        }


    }
}

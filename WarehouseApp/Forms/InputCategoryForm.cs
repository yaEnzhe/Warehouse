using NLog;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма для ввода новой категории товаров
    /// </summary>
    public partial class InputCategoryForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Конструктор для добавления категорий
        /// </summary>
        public InputCategoryForm()
        {
            InitializeComponent();
            WarehouseApp.ResponsiveFormHelper.Enable(this);
            LanguageManager.ApplyControls(this);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

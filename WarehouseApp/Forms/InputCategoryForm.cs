using NLog;
using System;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;

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
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

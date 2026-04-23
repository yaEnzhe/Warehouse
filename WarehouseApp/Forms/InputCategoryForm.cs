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
        }
        private void ManageCategoriesForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesToList();
        }
        private void LoadCategoriesToList()
        {
            using (var db = new WarehouseContext())
            {
                var names = db.Categories.OrderBy(c => c.NameCategory).Select(c => c.NameCategory).ToList();
                lbCategories.Items.Clear();
                foreach (var name in names)
                {
                    lbCategories.Items.Add(name);
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var inputForm = new InputCategoryForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string newName = inputForm.txtName.Text.Trim();

                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        try
                        {
                            using (var db = new WarehouseContext())
                            {
                                if (db.Categories.Any(c => c.NameCategory.ToLower() == newName.ToLower()))
                                {
                                    logger.Error("CATEGORY_EXISTS_ERROR. Category: {Category}", "System", "Категория уже есть");
                                    MessageBox.Show(Properties.Resources.CategoryExistsWarning);
                                    return;
                                }
                                var newCat = new Categories
                                {
                                    IdCategories = Guid.NewGuid(),
                                    NameCategory = newName
                                };

                                db.Categories.Add(newCat);
                                db.SaveChanges();
                            }
                            logger.Info("CATEGORY_ADDED_SUCCESS. Category: {Category}", "System", "Категория успешно добавлена");
                            MessageBox.Show(Properties.Resources.CategoryAddedSuccess);
                            LoadCategoriesToList();
                        }
                        catch(Exception ex)
                        {
                            logger.Error(ex,"ERROR_MESSAGE_DISPLAY. Category: {Category}", "System");
                            MessageBox.Show(Properties.Resources.ErrorTitle);
                        }
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

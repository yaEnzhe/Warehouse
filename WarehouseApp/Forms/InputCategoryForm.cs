using System;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.ClassesContext;
using WarehouseApp.Classes;

namespace WarehouseApp.Forms
{
    public partial class InputCategoryForm : Form
    {
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
                                    MessageBox.Show("Такая категория уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            MessageBox.Show($"Категория '{newName}' добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCategoriesToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

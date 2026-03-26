using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;

namespace WarehouseApp.Forms
{
    public partial class CatalogStorekeeperForm : Form
    {
        private BindingList<Products> _allProducts;
        public CatalogStorekeeperForm()
        {
            InitializeComponent();
        }

        private void labelSearch_Click(object sender, EventArgs e)
        {

        }

        private void CatalogStorekeeperForm_Load(object sender, EventArgs e)
        {
            using (var db = new WarehouseContext())
            {
                // Настройка внешнего вида таблицы
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv.RowTemplate.Height = 30;
                dgv.GridColor = Color.Black;

                // === ГЛАВНЫЕ НАСТРОЙКИ ДЛЯ КЛАДОВЩИКА ===
                dgv.ReadOnly = true; // Запрещаем редактирование любых ячеек
                dgv.AllowUserToAddRows = false; // Запрещаем пустую строку снизу
                dgv.AllowUserToDeleteRows = false; // Запрещаем удаление кнопкой Del
                dgv.RowHeadersVisible = false; // Можно скрыть боковой заголовок строки
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Выделять всю строку сразу
                // ==========================================

                dgv.AutoGenerateColumns = false;

                // 1. Артикул
                dgv.Columns.Add("Article", "Артикул");
                dgv.Columns["Article"].DataPropertyName = "Article";

                // 2. Название
                dgv.Columns.Add("NameProduct", "Название");
                dgv.Columns["NameProduct"].DataPropertyName = "NameProduct";
                dgv.Columns["NameProduct"].Width = 200; // Можно задать ширину

                // 3. Категория (ComboBox используется для подстановки имени вместо ID)
                var comboCol = new DataGridViewComboBoxColumn();
                comboCol.Name = "Category";
                comboCol.HeaderText = "Категория";
                comboCol.DataSource = db.Categories.ToList();
                comboCol.DisplayMember = "NameCategory";
                comboCol.ValueMember = "IdCategories";
                comboCol.DataPropertyName = "IdCategories";
                comboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; // Выглядит как текст, без стрелочки
                dgv.Columns.Add(comboCol);

                // 4. Ед. измерения
                var comboUnit = new DataGridViewComboBoxColumn();
                comboUnit.Name = "UnitOfMeasure";
                comboUnit.HeaderText = "Ед. изм.";
                comboUnit.DataSource = db.UnitOfMeasure.ToList();
                comboUnit.DisplayMember = "NameUnit";
                comboUnit.ValueMember = "IdUnit"; // ID в таблице справочника

                // ! ВНИМАНИЕ: Убедись, что поле в Products называется именно так (IdUnit или IdUnitOfMeasure)
                comboUnit.DataPropertyName = "IdUnit";

                comboUnit.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; // Выглядит как текст
                dgv.Columns.Add(comboUnit);

                // 5. Цена (можно скрыть от кладовщика, если нужно, закомментировав эти строки)
                dgv.Columns.Add("Price", "Цена");
                dgv.Columns["Price"].DataPropertyName = "Price";

                // 6. Остаток
                dgv.Columns.Add("Stock", "Остаток");
                dgv.Columns["Stock"].DataPropertyName = "Stock";

                // Обработчик ошибок данных (чтобы не вылетали исключения при отрисовке ComboBox)
                dgv.DataError += dgv_DataError;

                LoadData();
            }
        }
        private void LoadData()
        {
                try
                {
                    using (var db = new WarehouseContext())
                    {
                        // AsNoTracking() ускоряет загрузку, так как нам не нужно отслеживать изменения для сохранения
                        var data = db.Products
                            .AsNoTracking()
                            .Include("Category")
                            .Include("UnitOfMeasure")
                            .ToList();

                        _allProducts = new BindingList<Products>(data);
                    }
                    dgv.DataSource = _allProducts;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }

        }
}

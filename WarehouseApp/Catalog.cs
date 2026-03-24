using System;
using System.Data;
using System.Drawing;


using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class Catalog : Form
    {
        private DataTable table;
        public Catalog()
        {
            InitializeComponent();
        }

        private void dgvForTableOfGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            dgvForTableOfGoods.BorderStyle = BorderStyle.None;
            dgvForTableOfGoods.EnableHeadersVisualStyles = false;
            dgvForTableOfGoods.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvForTableOfGoods.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvForTableOfGoods.RowTemplate.Height = 30;
            dgvForTableOfGoods.GridColor = Color.Black;

            dgvForTableOfGoods.AutoGenerateColumns = false;
            dgvForTableOfGoods.AllowUserToAddRows = false; // ✅ Убирает последнюю пустую строку

            dgvForTableOfGoods.Columns.Add("Article", "Артикул");
            dgvForTableOfGoods.Columns["Article"].DataPropertyName = "Артикул";

            dgvForTableOfGoods.Columns.Add("Name", "Название");
            dgvForTableOfGoods.Columns["Name"].DataPropertyName = "Название";

            dgvForTableOfGoods.Columns.Add("Category", "Категория");
            dgvForTableOfGoods.Columns["Category"].DataPropertyName = "Категория";

            dgvForTableOfGoods.Columns.Add("Unit", "Ед. измерений");
            dgvForTableOfGoods.Columns["Unit"].DataPropertyName = "Ед. измерений";

            dgvForTableOfGoods.Columns.Add("Price", "Цена закупки");
            dgvForTableOfGoods.Columns["Price"].DataPropertyName = "Цена закупки";

            dgvForTableOfGoods.Columns.Add("Stock", "Остаток");
            dgvForTableOfGoods.Columns["Stock"].DataPropertyName = "Остаток";
            LoadData();
        }
        private void LoadData()
        {
            // ❗ ПОКА БАЗЫ НЕТ — создаём тестовые данные
            table = new DataTable();

            table.Columns.Add("Артикул");
            table.Columns.Add("Название");
            table.Columns.Add("Категория");
            table.Columns.Add("Ед. измерений");
            table.Columns.Add("Цена закупки");
            table.Columns.Add("Остаток");
            // delete 
            table.Rows.Add("001", "Ручка", "Письменные", "шт", "10", "100");
            table.Rows.Add("002", "Тетрадь", "Бумага", "шт", "50", "200");

            dgvForTableOfGoods.DataSource = table;

            // ============================
            // ❗ ПОТОМ (КОГДА БУДЕТ БД):
            // ============================

            // 1. Создать подключение:
            // SqlConnection connection = new SqlConnection("строка подключения");

            // 2. Создать запрос:
            // string query = "SELECT * FROM Products";

            // 3. Создать адаптер:
            // SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            // 4. Заполнить таблицу:
            // DataTable dt = new DataTable();
            // adapter.Fill(dt);

            // 5. Привязать к DataGridView:
            // dgvForTableOfGoods.DataSource = dt;

            // ❗ ВАЖНО:
            // Названия колонок в БД должны совпадать с DataPropertyName
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (table == null) return;

            DataView dv = table.DefaultView;

            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                dv.RowFilter = ""; // ✅ СБРОС ФИЛЬТРА
            }
            else
            {
                dv.RowFilter = $"Название LIKE '%{textBoxSearch.Text.Replace("'", "''")}%'";
            }

            dgvForTableOfGoods.DataSource = dv;
            
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // ❗ Пока просто заглушка
            MessageBox.Show("Редактирование");

            // ❗ ПОТОМ:
            // Открывать форму редактирования и передавать ID товара
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ❗ Пока удаление только из таблицы
            if (dgvForTableOfGoods.CurrentRow != null)
            {
                dgvForTableOfGoods.Rows.Remove(dgvForTableOfGoods.CurrentRow);
            }

            // ❗ ПОТОМ:
            // DELETE FROM Products WHERE Id = ...
        }

        private void labelOfSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonToAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добавить товар");
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonForBack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь будет возврат на предыдущую форму");
        }
    }
}

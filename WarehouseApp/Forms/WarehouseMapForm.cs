using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarehouseApp.Classes;
using WarehouseApp.ClassesContext;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма тепловой карты склада.
    /// </summary>
    public partial class WarehouseMapForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<Products> products = new List<Products>();

        public WarehouseMapForm()
        {
            InitializeComponent();
            WarehouseApp.ResponsiveFormHelper.Enable(this);
            cmbSort.SelectedIndex = 0;
            LoadProducts();
            DrawMap();
        }

        private void LoadProducts()
        {
            try
            {
                using (var db = new WarehouseContext())
                {
                    products = db.Products
                        .OrderBy(p => p.NameProduct)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WAREHOUSE_MAP_LOAD_ERROR. Category: {Category}", "System");
                MessageBox.Show(Properties.Resources.DataLoadErrorText);
                products = new List<Products>();
            }
        }

        private void DrawMap()
        {
            tableMap.SuspendLayout();
            tableMap.Controls.Clear();

            var sortedProducts = GetSortedProducts();
            int cellCount = tableMap.RowCount * tableMap.ColumnCount;

            for (int i = 0; i < cellCount; i++)
            {
                Control cell = i < sortedProducts.Count
                    ? CreateProductCell(sortedProducts[i])
                    : CreateEmptyCell();

                tableMap.Controls.Add(cell, i % tableMap.ColumnCount, i / tableMap.ColumnCount);
            }

            tableMap.ResumeLayout();
        }

        private List<Products> GetSortedProducts()
        {
            if (cmbSort.SelectedItem?.ToString() == "Остаток")
                return products.OrderBy(p => p.Stock).ThenBy(p => p.NameProduct).ToList();

            return products
                .OrderBy(p => p.ExpirationDate ?? DateTime.MaxValue)
                .ThenBy(p => p.NameProduct)
                .ToList();
        }

        private Control CreateProductCell(Products product)
        {
            return new Label
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                BackColor = GetProductColor(product),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 7F),
                Text = BuildCellText(product)
            };
        }

        private Control CreateEmptyCell()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                BackColor = Color.FromArgb(180, 180, 180)
            };
        }

        private string BuildCellText(Products product)
        {
            string expiration = product.ExpirationDate.HasValue
                ? product.ExpirationDate.Value.ToString("dd.MM.yyyy")
                : "нет срока";

            return $"{product.NameProduct}\n{expiration}\n{product.Stock:0} шт.";
        }

        private Color GetProductColor(Products product)
        {
            if (cmbSort.SelectedItem?.ToString() == "Остаток")
                return GetStockColor(product.Stock);

            return product.ExpirationDate.HasValue
                ? GetExpirationColor(product.ExpirationDate)
                : GetStockColor(product.Stock);
        }

        private Color GetExpirationColor(DateTime? expirationDate)
        {
            if (!expirationDate.HasValue)
                return Color.FromArgb(180, 180, 180);

            int daysLeft = (expirationDate.Value.Date - DateTime.Today).Days;

            if (daysLeft <= 30)
                return Color.FromArgb(246, 65, 35);

            if (daysLeft <= 365)
                return Color.FromArgb(255, 205, 70);

            return Color.FromArgb(94, 205, 113);
        }

        private Color GetStockColor(decimal stock)
        {
            if (stock <= 0)
                return Color.FromArgb(180, 180, 180);

            if (stock <= 10)
                return Color.FromArgb(246, 65, 35);

            if (stock <= 30)
                return Color.FromArgb(255, 205, 70);

            return Color.FromArgb(94, 205, 113);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawMap();
        }

        private void lblSort_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}

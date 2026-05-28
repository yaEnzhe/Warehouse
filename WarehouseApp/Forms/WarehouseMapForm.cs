using NLog;

namespace WarehouseApp.Forms
{
    /// <summary>
    /// Форма тепловой карты склада.
    /// </summary>
    public partial class WarehouseMapForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<Products> products = new List<Products>();
        private Timer refreshTimer;
        private ToolTip cellToolTip;

        public WarehouseMapForm()
        {
            InitializeComponent();
            WarehouseApp.ResponsiveFormHelper.Enable(this);
            cmbSort.SelectedIndex = 0;
            cellToolTip = new ToolTip();
            StartRefreshTimer();
            LoadProducts();
            DrawMap();
        }

        private void StartRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 60 * 60 * 1000;
            refreshTimer.Tick += refreshTimer_Tick;
            refreshTimer.Start();
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
            string[] columns = { "A", "B", "C", "D", "E", "F", "G" };
            var dataRows = 4;
            var dataColumns = columns.Length;

            tableMap.Controls.Add(CreateHeaderCell(string.Empty), 0, 0);

            for (int i = 0; i < columns.Length; i++)
                tableMap.Controls.Add(CreateHeaderCell(columns[i]), i + 1, 0);

            for (int row = 0; row < dataRows; row++)
            {
                tableMap.Controls.Add(CreateHeaderCell((row + 1).ToString()), 0, row + 1);

                for (int column = 0; column < dataColumns; column++)
                {
                    var productIndex = row * dataColumns + column;
                    var cell = productIndex < sortedProducts.Count
                        ? CreateProductCell(sortedProducts[productIndex])
                        : CreateEmptyCell();

                    tableMap.Controls.Add(cell, column + 1, row + 1);
                }
            }

            tableMap.ResumeLayout();
            UpdateLegend();
        }

        private List<Products> GetSortedProducts()
        {
            if (cmbSort.SelectedItem?.ToString() == "остаткам")
                return products.OrderBy(p => p.Stock).ThenBy(p => p.NameProduct).ToList();

            return products
                .OrderBy(p => p.ExpirationDate ?? DateTime.MaxValue)
                .ThenBy(p => p.NameProduct)
                .ToList();
        }

        private Control CreateProductCell(Products product)
        {
            var cell = new Label
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                BackColor = GetProductColor(product),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 7F)
            };

            cellToolTip.SetToolTip(cell, BuildCellText(product));
            return cell;
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

        private Control CreateHeaderCell(string text)
        {
            return new Label
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                BackColor = Color.White,
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 9F)
            };
        }

        private string BuildCellText(Products product)
        {
            var expiration = product.ExpirationDate.HasValue
                ? product.ExpirationDate.Value.ToString("dd.MM.yyyy")
                : "нет срока";

            var daysLeft = "нет срока";
            if (product.ExpirationDate.HasValue)
                daysLeft = (product.ExpirationDate.Value.Date - DateTime.Today).Days.ToString();

            return $"Товар: {product.NameProduct}\nКоличество: {product.Stock:0}\nСрок годности: {expiration}\nОсталось дней: {daysLeft}";
        }

        private Color GetProductColor(Products product)
        {
            if (cmbSort.SelectedItem?.ToString() == "остаткам")
                return GetStockColor(product.Stock);

            return GetExpirationColor(product);
        }

        private Color GetExpirationColor(Products product)
        {
            if (product.Stock <= 0)
                return Color.FromArgb(180, 180, 180);

            if (!product.ExpirationDate.HasValue)
                return Color.FromArgb(94, 205, 113);

            var daysLeft = (product.ExpirationDate.Value.Date - DateTime.Today).Days;

            if (daysLeft < 0)
                return Color.FromArgb(246, 65, 35);

            if (daysLeft <= 7)
                return Color.FromArgb(255, 156, 61);

            if (daysLeft <= 30)
                return Color.FromArgb(255, 205, 70);

            return Color.FromArgb(94, 205, 113);
        }

        private Color GetStockColor(decimal stock)
        {
            if (stock <= 0)
                return Color.FromArgb(246, 65, 35);

            if (stock <= 10)
                return Color.FromArgb(255, 156, 61);

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

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            LoadProducts();
            DrawMap();
        }

        private void UpdateLegend()
        {
            if (cmbSort.SelectedItem?.ToString() == "остаткам")
            {
                lblLegend.Text = "• Красный: товара не осталось\n"
                    + "• Оранжевый: товара ≤ 10\n"
                    + "• Жёлтый: 11 ≤ товара ≤ 30\n"
                    + "• Зелёный: 31 ≤ товара ≤ 100";
                return;
            }

            lblLegend.Text = "• Красный: просрочено\n"
                + "• Оранжевый: 0 ≤ дней осталось ≤ 7\n"
                + "• Жёлтый: 7 ≤ дней осталось ≤ 30\n"
                + "• Зелёный: > 30 дней\n"
                + "• Серый: Нет в наличии";
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            LoadProducts();
            DrawMap();
        }

        private void WarehouseMapForm_Load(object sender, EventArgs e)
        {

        }
    }
}

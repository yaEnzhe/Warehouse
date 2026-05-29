
namespace WarehouseApp
{
    /// <summary>
    /// Добавляет простое масштабирование элементов формы.
    /// </summary>
    internal static class ResponsiveFormHelper
    {
        private sealed class ControlLayout
        {
            /// <summary>
            /// Начальные размеры и положение элемента.
            /// </summary>
            public Rectangle Bounds { get; set; }

            /// <summary>
            /// Начальный размер шрифта.
            /// </summary>
            public float FontSize { get; set; }

            /// <summary>
            /// Начальные ширины колонок таблицы.
            /// </summary>
            public List<int> GridColumnWidths { get; set; }
        }

        /// <summary>
        /// Включает изменение размеров элементов при изменении окна.
        /// </summary>
        public static void Enable(Form form)
        {
            var baseSize = form.ClientSize;
            var layouts = new Dictionary<Control, ControlLayout>();

            SaveLayout(form, layouts);

            form.MinimumSize = form.Size;
            form.MaximizeBox = true;

            form.Resize += (sender, args) =>
            {
                if (form.WindowState == FormWindowState.Minimized || baseSize.Width == 0 || baseSize.Height == 0)
                    return;

                float scaleX = (float)form.ClientSize.Width / baseSize.Width;
                float scaleY = (float)form.ClientSize.Height / baseSize.Height;
                float fontScale = Math.Min(scaleX, scaleY);

                ApplyLayout(form, layouts, scaleX, scaleY, fontScale);
            };
        }

        private static void SaveLayout(Control parent, Dictionary<Control, ControlLayout> layouts)
        {
            foreach (Control control in parent.Controls)
            {
                var layout = new ControlLayout
                {
                    Bounds = control.Bounds,
                    FontSize = control.Font.Size
                };

                if (control is DataGridView grid)
                {
                    layout.GridColumnWidths = new List<int>();
                    foreach (DataGridViewColumn column in grid.Columns)
                        layout.GridColumnWidths.Add(column.Width);
                }

                layouts[control] = layout;

                if (control.Controls.Count > 0)
                    SaveLayout(control, layouts);
            }
        }

        private static void ApplyLayout(Control parent, Dictionary<Control, ControlLayout> layouts, float scaleX, float scaleY, float fontScale)
        {
            foreach (Control control in parent.Controls)
            {
                if (!layouts.TryGetValue(control, out var layout))
                    continue;

                control.Bounds = new Rectangle(
                    (int)(layout.Bounds.X * scaleX),
                    (int)(layout.Bounds.Y * scaleY),
                    (int)(layout.Bounds.Width * scaleX),
                    (int)(layout.Bounds.Height * scaleY));

                float newFontSize = Math.Max(6f, layout.FontSize * fontScale);
                control.Font = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);

                if (control is DataGridView grid && layout.GridColumnWidths != null)
                {
                    if (layout.GridColumnWidths.Count != grid.Columns.Count)
                    {
                        layout.GridColumnWidths.Clear();
                        foreach (DataGridViewColumn column in grid.Columns)
                            layout.GridColumnWidths.Add(column.Width);
                    }

                    for (int i = 0; i < grid.Columns.Count && i < layout.GridColumnWidths.Count; i++)
                        grid.Columns[i].Width = Math.Max(30, (int)(layout.GridColumnWidths[i] * scaleX));
                }

                if (control.Controls.Count > 0)
                    ApplyLayout(control, layouts, scaleX, scaleY, fontScale);
            }
        }
    }
}

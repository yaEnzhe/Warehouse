using System.Windows.Forms;

namespace WarehouseApp
{
    internal static class FormNavigationHelper
    {
        public static void ApplyWindowState(Form source, Form target)
        {
            if (source == null || target == null)
                return;

            target.StartPosition = FormStartPosition.Manual;

            if (source.WindowState == FormWindowState.Normal)
                target.Bounds = source.Bounds;
            else
                target.Bounds = source.RestoreBounds;

            target.WindowState = source.WindowState;
        }

        public static void Show(Form source, Form target)
        {
            ApplyWindowState(source, target);
            target.Show();
        }

        public static DialogResult ShowDialog(Form source, Form target)
        {
            ApplyWindowState(source, target);
            return target.ShowDialog();
        }
    }
}

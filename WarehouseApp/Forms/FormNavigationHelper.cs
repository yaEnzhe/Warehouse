
namespace WarehouseApp
{
    /// <summary>
    /// Помогает открывать формы с размером текущего окна.
    /// </summary>
    internal static class FormNavigationHelper
    {
        /// <summary>
        /// Переносит размер и состояние окна на новую форму.
        /// </summary>
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

        /// <summary>
        /// Открывает форму без блокировки текущего окна.
        /// </summary>
        public static void Show(Form source, Form target)
        {
            ApplyWindowState(source, target);
            target.Show();
            target.BringToFront();
            target.Activate();
        }

        /// <summary>
        /// Открывает форму как диалоговое окно.
        /// </summary>
        public static DialogResult ShowDialog(Form source, Form target)
        {
            ApplyWindowState(source, target);
            return target.ShowDialog();
        }
    }
}

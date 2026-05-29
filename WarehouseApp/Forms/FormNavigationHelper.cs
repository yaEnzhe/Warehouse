
using NLog;

namespace WarehouseApp
{
    /// <summary>
    /// Помогает открывать формы с размером текущего окна.
    /// </summary>
    internal static class FormNavigationHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

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
            ApplyLanguage(target);
            logger.Info("FORM_OPENED. Category: {Category}. From: {FromForm}. To: {ToForm}", "Navigation", source?.GetType().Name, target?.GetType().Name);
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
            ApplyLanguage(target);
            logger.Info("FORM_DIALOG_OPENED. Category: {Category}. From: {FromForm}. To: {ToForm}", "Navigation", source?.GetType().Name, target?.GetType().Name);
            return target.ShowDialog();
        }

        private static void ApplyLanguage(Form target)
        {
            if (target is ILocalizableForm localizableForm)
                localizableForm.ApplyLocalization();
            else
                LanguageManager.ApplyControls(target);
        }
    }
}

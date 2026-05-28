
namespace WarehouseApp.Classes
{
    /// <summary>
    /// Формирует отображаемые имя пользователя и роль.
    /// </summary>
    internal static class UserDisplayHelper
    {
        /// <summary>
        /// Возвращает фамилию и инициалы пользователя.
        /// </summary>
        public static string GetShortName(User user)
        {
            if (user == null)
                return string.Empty;

            var surname = user.Surname?.Trim();
            var name = user.Name?.Trim();
            var patronymic = user.Patronymic?.Trim();

            if (string.IsNullOrWhiteSpace(surname) && string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(patronymic))
                return user.Login;

            var initials = string.Empty;
            if (!string.IsNullOrWhiteSpace(name))
                initials += $"{name[0]}.";

            if (!string.IsNullOrWhiteSpace(patronymic))
                initials += $" {patronymic[0]}.";

            if (string.IsNullOrWhiteSpace(surname))
                return initials;

            return string.IsNullOrWhiteSpace(initials)
                ? surname
                : $"{surname} {initials}";
        }

        /// <summary>
        /// Возвращает русское название роли.
        /// </summary>
        public static string GetRoleName(Roles role)
        {
            switch (role)
            {
                case Roles.Administrator:
                    return LanguageManager.Text("Administrator");
                case Roles.Storekeeper:
                    return LanguageManager.Text("Storekeeper");
                default:
                    return string.Empty;
            }
        }
    }
}

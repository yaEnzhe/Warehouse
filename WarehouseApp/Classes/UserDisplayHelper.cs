using WarehouseApp.Enums;

namespace WarehouseApp.Classes
{
    internal static class UserDisplayHelper
    {
        public static string GetShortName(User user)
        {
            if (user == null)
                return string.Empty;

            string surname = user.Surname?.Trim();
            string name = user.Name?.Trim();
            string patronymic = user.Patronymic?.Trim();

            if (string.IsNullOrWhiteSpace(surname) && string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(patronymic))
                return user.Login;

            string initials = string.Empty;
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

        public static string GetRoleName(Roles role)
        {
            switch (role)
            {
                case Roles.Administrator:
                    return "Администратор";
                case Roles.Storekeeper:
                    return "Кладовщик";
                default:
                    return string.Empty;
            }
        }
    }
}

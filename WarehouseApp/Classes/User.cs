using WarehouseApp.Enums;
using System;

namespace WarehouseApp.Classes
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; private set; }
        public Roles Role { get; set; }
        public DateTime DateOfRegistration { get; set; }

        public void SetPassword(User user, string text)
        {
           user.Password = text;
        }

        public bool CheckPassword(User user, string text)
        {
            return user.Password == text;
        }
    }
}

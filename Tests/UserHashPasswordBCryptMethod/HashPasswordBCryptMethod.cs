using System;

namespace UserHashPasswordBCryptMethod
{
    public class HashPasswordBCryptMethod
    {
        public Guid Id { get; set; }

        public string HashPassword { get; private set; }

        public void HashPasswordBCrypt(HashPasswordBCryptMethod user, string text)
        {
            user.HashPassword = BCrypt.Net.BCrypt.HashPassword(text);
        }
    }
}

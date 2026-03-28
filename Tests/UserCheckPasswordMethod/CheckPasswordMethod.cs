namespace UserCheckPasswordMethod
{
    public class CheckPasswordMethod
    {
        public string HashPassword { get; set; }

        public bool CheckPassword(CheckPasswordMethod user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.HashPassword);
        }
    }
}

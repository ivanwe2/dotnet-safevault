namespace SafeVault.src.SafeVault.Services
{
    public class RegisterService
    {
        private readonly ApplicationDbContext _context;

        public RegisterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool RegisterUser(string username, string email, string password, string role)
        {
            if (_context.Users.Any(u => u.Username == username || u.Email == email))
                return false;

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return false;

            return true;
        }
    }
}
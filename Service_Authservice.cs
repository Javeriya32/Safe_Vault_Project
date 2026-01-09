using SafeVault.Data;
using SafeVault.Models;

namespace SafeVault.Services
{
    public class AuthService
    {
        private readonly Database _db;

        public AuthService(Database db)
        {
            _db = db;
        }

        public bool Login(string username, string password, out User? user)
        {
            user = _db.GetUser(username);
            if (user == null) return false;

            return PasswordHasher.Verify(password, user.PasswordHash);
        }
    }
}

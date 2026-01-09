using Microsoft.Data.Sqlite;
using SafeVault.Models;

namespace SafeVault.Data
{
    public class Database
    {
        private readonly string _connectionString = "Data Source=safevault.db";

        public User? GetUser(string username)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText =
            """
            SELECT UserID, Username, Email, PasswordHash, Role
            FROM Users
            WHERE Username = @username
            """;

            cmd.Parameters.AddWithValue("@username", username);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return new User
            {
                UserID = reader.GetInt32(0),
                Username = reader.GetString(1),
                Email = reader.GetString(2),
                PasswordHash = reader.GetString(3),
                Role = reader.GetString(4)
            };
        }
    }
}

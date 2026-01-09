using Microsoft.AspNetCore.Mvc;
using SafeVault.Data;
using SafeVault.Models;
using SafeVault.Services;

namespace SafeVault.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly Database _database;

        public UserController(Database database)
        {
            _database = database;
        }

        // Retrieve basic user profile (non-sensitive data)
        [HttpGet("{username}")]
        public IActionResult GetUserProfile(string username)
        {
            username = InputSanitizer.Sanitize(username);

            var user = _database.GetUser(username);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Do NOT expose sensitive fields
            return Ok(new
            {
                user.UserID,
                user.Username,
                user.Email,
                user.Role
            });
        }

        // Example endpoint demonstrating safe output handling
        [HttpGet("welcome/{username}")]
        public IActionResult GetWelcomeMessage(string username)
        {
            username = InputSanitizer.Sanitize(username);

            return Ok(new
            {
                Message = $"Welcome to SafeVault, {username}"
            });
        }
    }
}

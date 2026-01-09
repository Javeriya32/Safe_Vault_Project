using Microsoft.AspNetCore.Mvc;
using SafeVault.Services;
using SafeVault.Data;
using SafeVault.Models;

namespace SafeVault.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly SafeVaultContext _context;
        private readonly JwtTokenService _jwt;

        public AuthController(SafeVaultContext context, JwtTokenService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            request.Username = InputSanitizer.Sanitize(request.Username);
            request.Email = InputSanitizer.Sanitize(request.Email);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered securely.");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user == null || !PasswordHasher.Verify(request.Password, user.PasswordHash))
                return Unauthorized();

            var token = _jwt.GenerateToken(user);
            return Ok(token);
        }
    }
}

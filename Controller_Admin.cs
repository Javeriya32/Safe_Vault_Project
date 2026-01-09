using Microsoft.AspNetCore.Mvc;

namespace SafeVault.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        // Simulated RBAC check for demonstration
        private bool IsAdmin(string role)
        {
            return role == "Admin";
        }

        [HttpGet("dashboard")]
        public IActionResult GetAdminDashboard([FromHeader] string role)
        {
            if (!IsAdmin(role))
            {
                return Unauthorized("Access denied. Admin role required.");
            }

            return Ok(new
            {
                Message = "Welcome to the Admin Dashboard",
                Timestamp = DateTime.UtcNow,
                SystemStatus = "All systems operational"
            });
        }

        [HttpGet("audit")]
        public IActionResult GetAuditLogs([FromHeader] string role)
        {
            if (!IsAdmin(role))
            {
                return Unauthorized("Access denied. Admin role required.");
            }

            return Ok(new[]
            {
                "User login audit successful",
                "No suspicious activity detected",
                "Database integrity verified"
            });
        }
    }
}

using Microsoft.AspNetCore.Http;

namespace SafeVault.Middleware
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Prevent clickjacking
            context.Response.Headers.Add("X-Frame-Options", "DENY");

            // Prevent MIME sniffing
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

            // Enable basic XSS protection
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");

            // Enforce HTTPS usage
            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");

            // Content Security Policy
            context.Response.Headers.Add(
                "Content-Security-Policy",
                "default-src 'self'; script-src 'self'; object-src 'none';");

            await _next(context);
        }
    }
}

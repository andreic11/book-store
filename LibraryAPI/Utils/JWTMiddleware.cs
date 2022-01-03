using LibraryAPI.Services;
using LibraryAPI.Utils.JWTUtils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Utils
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJWTUtils jWTUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();

            var userId = jWTUtils.ValidateJWTToken(token);

            if (userId != System.Guid.Empty)
            {
                httpContext.Items["User"] = userService.GetById(userId);
            }

            await _next(httpContext);
        }
    }
}

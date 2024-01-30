using System.Security.Claims;

namespace WebChat.Services
{
    public class AuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetCurrentUserId()
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;

            if (claimsPrincipal != null)
            {
                var claims = claimsPrincipal.Claims;

                if (claims.Any(c => c.Type == ClaimTypes.NameIdentifier))
                {
                    return int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                }
            }

            return -1;
        }
    }

}

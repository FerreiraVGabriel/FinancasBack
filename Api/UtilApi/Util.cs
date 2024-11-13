using System.Security.Claims;

namespace Api.UtilApi
{
    public static class Util
    {
        public static int GetUserIdFromToken(HttpContext httpContext)
        {
            // Verifica se o usuário está autenticado e se a claim "userId" existe
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    return Convert.ToInt32(userIdClaim.Value);
                }
            }

            return 0; // Retorna null se o usuário não estiver autenticado ou a claim não existir
        }
    }
}

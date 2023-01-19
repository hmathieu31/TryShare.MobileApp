using INSAT._4I4U.TryShare.MobileApp.Model;
using Microsoft.Identity.Client;

namespace INSAT._4I4U.TryShare.MobileApp.Infrastructure.Mappers
{
    public static class UserIdentityMapper
    {

        

        public static UserIdentity ToModel(this AuthenticationResult authResult)
        {
            var accessToken = ReturnAccessToken(authResult);
            if (accessToken == null)
                throw new InvalidOperationException("Access Token can not be null");

            return new UserIdentity
            {
                Email = ReturnTypeFromIndex("emails", authResult),
                DisplayName = ReturnTypeFromIndex("name", authResult),
                FirstName = ReturnTypeFromIndex("given_name", authResult),
                LastName = ReturnTypeFromIndex("family_name", authResult),
                //City = ReturnTypeFromIndex("city", authResult)
                AccessToken = accessToken
            };
        }

        private static string? ReturnTypeFromIndex(string type, AuthenticationResult authResult)
        {
            var claim = authResult.ClaimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals(type));
            return claim?.Value;
        }

        private static string? ReturnAccessToken(AuthenticationResult authResult)
        {
            return authResult.AccessToken;
        }

    }
}

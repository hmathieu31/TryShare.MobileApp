using INSAT._4I4U.TryShare.MobileApp.Model;
using Microsoft.Identity.Client;

namespace INSAT._4I4U.TryShare.MobileApp.Infrastructure.Mappers
{
    public static class UserIdentityMapper
    {

        

        public static UserIdentity ToModel(this AuthenticationResult authResult)
        {
            var accessToken = ReturnAccessToken(authResult);
            if (accessToken is null)
                throw new InvalidOperationException("Access Token can not be null");

            var email = ReturnTypeFromIndex("emails", authResult);
            if (email is null)
                throw new InvalidOperationException("Email claim not found in the token");

            return new UserIdentity
            {
                Email = email,
                DisplayName = ReturnTypeFromIndex("name", authResult),
                FirstName = ReturnTypeFromIndex("given_name", authResult),
                LastName = ReturnTypeFromIndex("family_name", authResult),
                City = ReturnTypeFromIndex("city", authResult),
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

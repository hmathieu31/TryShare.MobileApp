using INSAT._4I4U.TryShare.MobileApp.Model;
using Microsoft.Identity.Client;

namespace INSAT._4I4U.TryShare.MobileApp.Infrastructure.Mappers
{
    public static class UserIdentityMapper
    {

        public static UserIdentity ToModel(this AuthenticationResult authResult)
        {
            return new UserIdentity
            {
                Email = ReturnTypeFromIndex("emails", authResult),
                DisplayName = ReturnTypeFromIndex("name", authResult),
                FirstName = ReturnTypeFromIndex("givename", authResult),
                LastName = ReturnTypeFromIndex("lastname", authResult),
                City = ReturnTypeFromIndex("city", authResult)
            };
        }

        private static string ReturnTypeFromIndex(string type, AuthenticationResult authResult)
        {
            var claim = authResult.ClaimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals(type));
            return claim.Value;
        }

    }
}

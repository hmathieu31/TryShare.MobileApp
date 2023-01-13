using INSAT._4I4U.TryShare.MobileApp.Settings;

namespace INSAT._4I4U.TryShare.MobileApp
{
    public class GlobalSettings
    {
        public static readonly string AzureTag = "Azure";
        public static readonly string MockTag = "Mock";

        public static readonly string DefaultEndpoint = "https://insat-tryshare.azurewebsites.net";

        private string _baseIdentityEndpoint;
        private string _baseGatewayShoppingEndpoint;

        public GlobalSettings()
        {
            AuthToken = "INSERT AUTHENTICATION TOKEN";

            BaseIdentityEndpoint = DefaultEndpoint;
            BaseGatewayShoppingEndpoint = DefaultEndpoint;
        }

        public static GlobalSettings Instance { get; } = new GlobalSettings();

        public static AzureAdB2C AzureB2CSettings { get; } = new AzureAdB2C
        {
            CacheDir = "C:/temp",
            CacheFileName = "netcore_winui_cache.txt",
            ClientId = "5e36f510-a31b-4ff3-9aa5-b254d8f63505",
            Domain = "insatryshare.onmicrosoft.com",
            EditProfilePolicyId = "b2c_1_edit_profile",
            Instance = "https =//insatryshare.b2clogin.com",
            ResetPasswordPolicyId = "b2c_1_reset",
            SignUpSignInPolicyId = "B2C_1_SignupSignin1",
            TenantId = "8e77bc5e-3720-4cf3-a728-757a7ba5d100"
        };

        public static string[] Scopes { get; } =
        {
            "https://insatryshare.onmicrosoft.com/de4639ac-b011-4071-ad70-cd4dcba3bc40/access_as_user"
        };

        public string BaseIdentityEndpoint
        {
            get => _baseIdentityEndpoint;
            set
            {
                _baseIdentityEndpoint = value;
                UpdateEndpoint(_baseIdentityEndpoint);
            }
        }

        public string BaseGatewayShoppingEndpoint
        {
            get => _baseGatewayShoppingEndpoint;
            set
            {
                _baseGatewayShoppingEndpoint = value;
                UpdateGatewayShoppingEndpoint(_baseGatewayShoppingEndpoint);
            }
        }

        public string ClientId { get; } = "xamarin";

        public string ClientSecret { get; } = "secret";

        public string AuthToken { get; set; }

        public string RegisterWebsite { get; set; }

        public string AuthorizeEndpoint { get; set; }

        public string UserInfoEndpoint { get; set; }

        public string TokenEndpoint { get; set; }

        public string LogoutEndpoint { get; set; }

        public string Callback { get; set; }

        public string LogoutCallback { get; set; }

        public string GatewayShoppingEndpoint { get; set; }

        public string GatewayMarketingEndpoint { get; set; }

        private void UpdateEndpoint(string endpoint)
        {
            RegisterWebsite = $"{endpoint}/Account/Register";
            LogoutCallback = $"{endpoint}/Account/Redirecting";

            var connectBaseEndpoint = $"{endpoint}/connect";
            AuthorizeEndpoint = $"{connectBaseEndpoint}/authorize";
            UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
            TokenEndpoint = $"{connectBaseEndpoint}/token";
            LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

            var baseUri = GlobalSettings.ExtractBaseUri(endpoint);
            Callback = $"{baseUri}/xamarincallback";
        }

        private void UpdateGatewayShoppingEndpoint(string endpoint)
        {
            GatewayShoppingEndpoint = endpoint;
        }

        private void UpdateGatewayMarketingEndpoint(string endpoint)
        {
            GatewayMarketingEndpoint = endpoint;
        }

        private static string ExtractBaseUri(string endpoint)
        {
            try
            {
                var uri = new Uri(endpoint);
                var baseUri = uri.GetLeftPart(UriPartial.Authority);

                return baseUri;
            }
            catch (Exception ex)
            {
                _ = ex;
                return DefaultEndpoint;
            }
        }
    }
}

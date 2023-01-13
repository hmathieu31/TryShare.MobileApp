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

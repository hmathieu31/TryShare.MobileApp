using INSAT._4I4U.TryShare.MobileApp.Exceptions;
using INSAT._4I4U.TryShare.MobileApp.Loggers;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Abstractions;

namespace INSAT._4I4U.TryShare.MobileApp.Helpers
{
    public class MsalHelper
    {
        public IPublicClientApplication PublicClientApplication { get; }
        public AuthenticationResult? AuthResult { get; private set; }

        public MsalHelper()
        {
            var b2cConfig = GlobalSettings.AzureB2CSettings;

            this.PublicClientApplication = PublicClientApplicationBuilder
                .Create(b2cConfig.ClientId)
                .WithB2CAuthority($"{b2cConfig.Instance}/tfp/{b2cConfig.Domain}/{b2cConfig.SignUpSignInPolicyId}")
                .WithLogging(new IdentityLogger(EventLogLevel.Warning), enablePiiLogging: false)
                // This is the currently recommended way to log MSAL message. For more info refer to https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/logging. Set Identity Logging level to Warning which is a middle ground
                .WithRedirectUri($"msal{b2cConfig.ClientId}://auth")
#if ANDROID
                .WithParentActivityOrWindow(() => Platform.CurrentActivity)
#endif
                .Build();
        }

        /// <summary>
        /// Signs in the user and obtains an Access token for a provided set of scopes
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns> Access Token</returns>
        public async Task<AuthenticationResult> SignInUserAndAcquireAccessTokenAsync(string[] scopes)
        {

            if (this.PublicClientApplication is null)
                throw new MsalClientApplicationException("MSAL PCA is null");

            var existingUser = (await this.PublicClientApplication.GetAccountsAsync())
                                        .FirstOrDefault();

            try
            {
                // 1. Try to sign-in the previously signed-in account
                if (existingUser is not null)
                {
                    this.AuthResult = await this.PublicClientApplication
                        .AcquireTokenSilent(scopes, existingUser)
                        .ExecuteAsync()
                        .ConfigureAwait(false);
                }
                else
                {
                    this.AuthResult = await SignInUserInteractivelyAsync(scopes);
                }
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilentAsync. This indicates you need to call AcquireTokenInteractive to acquire a token interactively
                Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

                this.AuthResult = await this.PublicClientApplication
                    .AcquireTokenInteractive(scopes)
                    .ExecuteAsync()
                    .ConfigureAwait(false);
            }
            catch (MsalException msalEx)
            {
                Debug.WriteLine($"Error Acquiring Token interactively:{Environment.NewLine}{msalEx}");
            }

            if (this.AuthResult is null)
                throw new MsalClientApplicationException("Authentication Result is null");

            return AuthResult;
        }

        /// <summary>
        /// Shows a pattern to sign-in a user interactively in applications that are input constrained and would need to fall-back on device code flow.
        /// </summary>
        /// <param name="scopes">The scopes.</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> SignInUserInteractivelyAsync(string[] scopes)
        {
            if (this.PublicClientApplication is null)
                throw new MsalClientApplicationException("Public Client application not initialized");

            if (this.PublicClientApplication.IsUserInteractive())
            {
                return await this.PublicClientApplication.AcquireTokenInteractive(scopes)
                    .ExecuteAsync()
                    .ConfigureAwait(false);
            }

            // If the device does not support UI
            throw new NotSupportedException("Device needs to support UI to acquire token interactively");
        }
    }
}

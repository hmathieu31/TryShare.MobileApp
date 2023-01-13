using Microsoft.Identity.Client;
using static INSAT._4I4U.TryShare.MobileApp.GlobalSettings;

namespace INSAT._4I4U.TryShare.MobileApp.Helpers
{
    public class MSALHelper
    {
        public  IPublicClientApplication PublicClientApplication { get; }
        public AuthenticationResult AuthResult { get; private set; }
        private static readonly AzureADb2c b2cConfig;

        public MSALHelper()
        {
            

            var builder = PublicClientApplicationBuilder
                .Create();
        }

        /// <summary>
        /// Signs in the user and obtains an Access token for a provided set of scopes
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns> Access Token</returns>
        public async Task<string> SignInUserAndAcquireAccessToken(string[] scopes)
        {
            
            if (this.PublicClientApplication is null) 
            {
                throw new NullReferenceException("Public Client application not initialized");
            }

            IAccount existingUser = null;

            try
            {
                // 1. Try to sign-in the previously signed-in account
                if (existingUser != null)
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

            return this.AuthResult.AccessToken;
        }

        /// <summary>
        /// Shows a pattern to sign-in a user interactively in applications that are input constrained and would need to fall-back on device code flow.
        /// </summary>
        /// <param name="scopes">The scopes.</param>
        /// <param name="existingAccount">The existing account.</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> SignInUserInteractivelyAsync(string[] scopes, IAccount existingAccount = null)
        {
            if (this.PublicClientApplication is null)
            {
                throw new NullReferenceException("Public Client application not initialized");
            }

            if (this.PublicClientApplication.IsUserInteractive())
            {
                return await this.PublicClientApplication.AcquireTokenInteractive(scopes)
                    .ExecuteAsync()
                    .ConfigureAwait(false);
            }

            // If the operating system does not have UI (e.g. SSH into Linux), you can fallback to device code, however this
            // flow will not satisfy the "device is managed" CA policy.
            return await this.PublicClientApplication.AcquireTokenWithDeviceCode(scopes, (dcr) =>
            {
                Console.WriteLine(dcr.Message);
                return Task.CompletedTask;
            }).ExecuteAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Removes the first signed-in user's record from token cache
        /// </summary>
        public async Task SignOutUserAsync()
        {
            var existingUser = await FetchSignedInUserFromCache().ConfigureAwait(false);
            await this.SignOutUserAsync(existingUser).ConfigureAwait(false);
        }
    }
}

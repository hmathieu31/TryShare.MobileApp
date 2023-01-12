using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace INSAT._4I4U.TryShare.MobileApp.Platforms.Android
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msal5e36f510-a31b-4ff3-9aa5-b254d8f63505")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}

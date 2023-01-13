using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Settings
{
    public class AzureAdB2C
    {
        public string CacheDir { get; set; }
        public string CacheFileName { get; set; }
        public string ClientId { get; set; }
        public string Domain { get; set; }
        public string EditProfilePolicyId { get; set; }
        public string Instance { get; set; }
        public string ResetPasswordPolicyId { get; set; }
        public string SignUpSignInPolicyId { get; set; }
        public string TenantId { get; set; }
        public string[] Scopes { get; set; }
    }
}

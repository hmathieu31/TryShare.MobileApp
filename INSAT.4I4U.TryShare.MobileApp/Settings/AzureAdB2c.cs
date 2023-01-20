using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Settings
{
    public class AzureAdB2C
    {
        public required string CacheDir { get; set; }
        public required string CacheFileName { get; set; }
        public required string ClientId { get; set; }
        public required string Domain { get; set; }
        public required string EditProfilePolicyId { get; set; }
        public required string Instance { get; set; }
        public required string ResetPasswordPolicyId { get; set; }
        public required string SignUpSignInPolicyId { get; set; }
        public required string TenantId { get; set; }
    }
}

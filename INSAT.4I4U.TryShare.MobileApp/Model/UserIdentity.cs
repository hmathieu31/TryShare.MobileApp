namespace INSAT._4I4U.TryShare.MobileApp.Model
{
    public class UserIdentity
    {
        public required string Email { get; set; }
        public required string AccessToken { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }
        public string? City { get; set; }
        public Tricycle? BookedTricycle { get; set; }
        
    }
}

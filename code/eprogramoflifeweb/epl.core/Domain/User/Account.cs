namespace epl.core.Domain
{
    public class Account
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ProviderName { get; set; }
        public string[] ClientSecrets { get; set; }
        public string[] AllowedScopes { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Person Person { get; set; }

        public Account(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

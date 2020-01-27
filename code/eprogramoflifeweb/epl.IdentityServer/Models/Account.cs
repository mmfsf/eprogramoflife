using epl.core.Interfaces;

namespace epl.IdentityServer.Models
{
    public class Account : IEntity
    {
        public int ID { get; set; }
        public string ClientID { get; set; }
        public string[] ClientSecrets { get; set; }
        public string[] AllowedScopes { get; set; }
    }
}

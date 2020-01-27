using epl.core.Interfaces;

namespace epl.IdentityServer.Models
{
    public class User : IEntity
    {
        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProviderName { get; set; }
        public bool IsActive { get; set; }
        public int ID { get; set; }
    }
}

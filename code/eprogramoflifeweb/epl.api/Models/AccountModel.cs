using System.ComponentModel.DataAnnotations;

namespace epl.api.Models
{
    public class AccountModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace epl.api.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        [Required]
        public int AccountID { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}

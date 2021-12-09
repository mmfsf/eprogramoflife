using System;
using System.ComponentModel.DataAnnotations;

namespace epl.api.Models
{
    public class PersonModel
    {
        public string Id { get; set; }
        [StringLength(300, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string FirstName { get; set; }
        [StringLength(300, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

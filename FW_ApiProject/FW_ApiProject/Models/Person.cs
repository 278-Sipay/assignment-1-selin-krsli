using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FW_ApiProject.Models

{
    public class Person
    {
        [DisplayName("Staff person name: ")]
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Name { get; set; }

        [DisplayName("Staff person lastname: ")]
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string LastName { get; set; }

        [DisplayName("Staff person phone number")]
        [Required]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("Staff person access level to system")]
        [Required]
        [Range(minimum: 1, maximum: 5)]
        public int AccessLevel { get; set; }

        [DisplayName("Staff person Status: ")]
        [Required]
        public string Status { get; set; }

        [DisplayName("Staff person salary")]
        [Required]
        [Range(minimum: 5000, maximum: 50000)]
        public decimal Salary { get; set; }
    }
}

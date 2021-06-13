using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Nuevo.Admin.Models.AccountModels
{
    public class AccountSettingsModel
    {
        [Required]
        [DisplayName("First Name: ")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name: ")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("E-Mail: ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password: ")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }
    }
}
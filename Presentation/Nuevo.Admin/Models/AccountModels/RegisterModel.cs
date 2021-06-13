using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nuevo.Admin.Models.AccountModels
{
    public class RegisterModel
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

        public string Password { get; set; }
        
        public string UserName { get; set; }
    }
}
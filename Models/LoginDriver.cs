using System.ComponentModel.DataAnnotations;

namespace Truber_Project.Models
{
    public class LoginDriver
    {
        [Required(ErrorMessage="Email is required.")]
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string LoginDriverEmail {get; set; }

        [Required(ErrorMessage="Password is required.")]
        [DataType(DataType.Password)]
        public string LoginDriverPassword {get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Truber_Project.Models
{
    public class User
    {
         [Key]
        public int UserId {get; set; }


        [Required(ErrorMessage="First name is required.")]
        [MinLength(3, ErrorMessage="First name must be at least 3 characters.")]
        [Display(Name="First Name: ")]
        public string FirstName {get; set; }


        [Required(ErrorMessage="Last name is required.")]
        [MinLength(3, ErrorMessage="Last name must be at least 3 characters.")]
        [Display(Name="Last Name: ")]
        
        public string LastName {get; set; }

        [Required(ErrorMessage="Email is required.")]
        [EmailAddress]
        [Display(Name="Email: ")]

        public string Email {get; set; }

        [Required(ErrorMessage="Password is required.")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        [Display(Name="Password: ")]
        public string Password {get; set; }
        [Required(ErrorMessage="Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="The password didn't match.")]
        [Display(Name="Confirm Password: ")]
        public string ConfirmPassword {get; set; }
        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;

        // one to many with jobs for users
        public List<Truber> Jobs {get; set; }
    }
}
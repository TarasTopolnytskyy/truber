using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Truber_Project.Models
{
    public class Driver
    {
        [Key]
        public int DriverId {get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string Email {get; set; }
        public DateTime DateOfBirth {get; set; }
        public string CarMake {get; set; }
        public string CarModel {get; set; }
        public int Year {get; set; }
        public string Plates {get; set; }
        [DataType(DataType.Password)]
        public string Password {get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="The password didn't match.")]
        public string ConfirmPassword {get; set; }
        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;

        public List<Truber> Jobs {get; set; }
    }
}
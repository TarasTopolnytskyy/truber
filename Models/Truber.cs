using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Truber_Project.Models
{
    public class Truber
    {
        [Key]
        public int TruberId {get; set; }

        [Display(Name="PickUp Address: ")]
        [Required(ErrorMessage="PickUp Address is required.")]
        public string AddressPickUp {get; set; }

        [Required(ErrorMessage="PickUp Date and Time is required.")]
        [Display(Name="PickUp Date and Time: ")]
        [FutureData]
        public DateTime PickUpTime {get; set; }

        [Display(Name="DropOff Address: ")]
        [Required(ErrorMessage="DropOff Addres is required.")]
        public string AddressDropOff {get; set; }

        [Display(Name="DropOff Date and Time: ")]
        [Required(ErrorMessage="DropOff Date and Time is required.")]
        [FutureData]
        public DateTime DropOffTime {get; set; }

        [Display(Name="Weight: ")]
        [Required(ErrorMessage="The weight is required.")]
        public int Weight {get; set; }

        [Display(Name="Height(in): ")]
        [Required(ErrorMessage="The Height is required.")]
        public int Height {get; set; }

        [Display(Name="Width(in): ")]
        [Required(ErrorMessage="The Width is required.")]
        public int Width {get; set; }

        [Display(Name="Length(in): ")]
        [Required(ErrorMessage="The Length is required.")]
        public int Length {get; set; }

        [Display(Name="Total Amouunt Of Miles(mi): ")]
        [Required(ErrorMessage="The Total Amouunt Of Miles is required.")]
        public int TotalAmoutOfMiles {get;set; }

        [Display(Name="Phone Number:")]
        [Required(ErrorMessage="The Phone Number is required.")]
        public int PhoneNumber {get; set; }

        [Display(Name="Price($): ")]
        [Required(ErrorMessage="The Price is required.")]
        public int Price {get; set; }
        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;

        // one to many with Users
        public int UserId {get; set; }
        public User Poster {get; set; }

        // one to many with driver

        public int? DriverId {get; set; }
        public int? Completed {get; set;}
        public Driver Taker {get; set; }
    }

    public class FutureDataAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime check;
                if(value is DateTime)
                {
                    check = (DateTime)value;
                    if(check < DateTime.Now)
                    {
                        return new ValidationResult("Event must be in future");
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return new ValidationResult("Event must be in valid date");
                }
        }
    }
}
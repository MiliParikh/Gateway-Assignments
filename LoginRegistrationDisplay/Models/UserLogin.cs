using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegistrationDisplay.Models
{
    public class UserLogin
    {
        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email ID is required")]
        [CustomEmailValidator]
        public string EmailID { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Minimum 8 and Maximum 15 characters required. Atleast one special character, one uppercase letter, one lowercase letter and one number required.")]
        public string Password { get; set; }
    }
}
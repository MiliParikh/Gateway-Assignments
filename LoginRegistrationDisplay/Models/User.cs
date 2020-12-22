using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LoginRegistrationDisplay.Models
{
    public class User
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }


        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }


        [Display(Name = "Email ID")]
        [Required]
        [CustomEmailValidator]
        public string EmailID { get; set; }


        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{4})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid Phone number (Enter in format : 91-1234-567-890")]
        public string PhoneNumber { get; set; }


        [Required]
        [Range(18, 50, ErrorMessage = "Age must be between 18 - 50 years")]
        public int Age { get; set; }


        [Display(Name = "Date Of Birth")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }


        [Required]
        [FileExtensions(Extensions = ".pdf, .jpg", ErrorMessage = "Please attach .pdf or .jpg file")]
        public string Image { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Minimum 8 and Maximum 15 characters required. Atleast one special character, one uppercase letter, one lowercase letter and one number required.")]
        public string Password { get; set; }


        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do no match")]
        public string ConfirmPassword { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z \-\']+$",
            ErrorMessage = "Please enter a valid first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z \-\']+$",
            ErrorMessage = "Please enter a valid middle name")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z \-\']+$",
            ErrorMessage = "Please enter a valid last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$",
            ErrorMessage = "Please enter a valid password. " +
            "Match all alphanumeric character and predefined wild characters (@ * #). " +
            "Password must consists of at least 8 characters and not more than 15 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$",
            ErrorMessage = "Please enter a valid password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}
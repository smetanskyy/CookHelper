using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookerHelper.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email not enter")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not enter")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

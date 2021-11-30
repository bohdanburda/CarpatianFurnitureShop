using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpathianFurniture.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please, enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords is not equal")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please, enter your Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter Surname")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please, enter Address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }
    }
}

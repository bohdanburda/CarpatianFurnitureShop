using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpathianFurniture.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please, enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

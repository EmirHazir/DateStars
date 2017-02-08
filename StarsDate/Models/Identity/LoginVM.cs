using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarsDate.Models.Identity
{
    public class LoginVM
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Email Adesiniz")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

    }
}

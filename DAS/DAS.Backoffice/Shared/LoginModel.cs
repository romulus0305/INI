using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAS.Backoffice.Shared
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username requried")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string RedirectURL { get; set; }
    }
}
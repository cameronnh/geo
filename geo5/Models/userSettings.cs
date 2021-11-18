using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace geo5.Models
{
    public class userSettings
    {
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must have an email address.")]        
        public string email { get; set; }

        [Display(Name = "Confirm Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("email", ErrorMessage = "The emails do not match.")]
        public string confirmEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must have a password.")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The passwords do not match.")]
        public string confirmPassword { get; set; }
    }
}
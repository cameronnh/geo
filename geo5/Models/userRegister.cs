using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace geo5.Models
{
    public class userRegister
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must have a username.")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Password must be above 10 characters.")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The passwords do not match.")]
        public string confirmPassword { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You must have an email address.")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}
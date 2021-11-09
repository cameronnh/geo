using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace geo5.Models
{
    public class userLogin
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must have a username.")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password.")]
        [DataType(DataType.Password)]
        public string password { get; set; }       
    }
}
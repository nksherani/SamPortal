using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModels.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage ="Password length must be greater than or equal to 4")]
        public string Password { get; set; }
    }
}
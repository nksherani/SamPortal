using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class AddUserViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Username is required")]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        [MinLength(6,ErrorMessage ="")]
        public string Password { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Active Flag is required")]
        [Range(0,1)]
        public int Active { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        public System.DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public Nullable<System.DateTime> LastUpdated_Date { get; set; }

        [MaxLength(100)]
        public string LastUpdated_By { get; set; }

        public Nullable<System.DateTime> DateOfBirth { get; set; }

    }
}
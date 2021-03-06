﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModels.Models
{
    public class AddUserViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Username is required")]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email Address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        [MinLength(6,ErrorMessage ="Password length must be greater than or equal to 6")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Both passwords must match")]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        [MinLength(6, ErrorMessage = "Password length must be greater than or equal to 6")]
        public string ConfirmPassword { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Active Flag is required")]
        [Range(0,1)]
        public int Active { get; set; }

        //[Required(ErrorMessage = "Created Date is required")]
        public System.DateTime CreatedDate { get; set; }

        //[Required(ErrorMessage = "Created By is required")]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public Nullable<System.DateTime> LastUpdatedDate { get; set; }

        [MaxLength(100)]
        public string LastUpdatedBy { get; set; }

        public Nullable<System.DateTime> DateOfBirth { get; set; }

    }
}
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace QrCodeManagementApi.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate => DateTime.Now;
    }
}
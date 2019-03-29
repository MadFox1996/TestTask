﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.WEB.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
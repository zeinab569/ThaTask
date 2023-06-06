﻿using System.ComponentModel.DataAnnotations;

namespace COREationsTask.Dto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool Rememberme { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace COREationsTask.Dto
{
    public class RegisterDto
    {
        [Required]

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full Name must be between 2,50 characters")]
        public string Fullname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Not Matched")]
        public string PasswordConfirmed { get; set; }


    }
}

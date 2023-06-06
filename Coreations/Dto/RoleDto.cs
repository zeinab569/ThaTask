using System.ComponentModel.DataAnnotations;

namespace COREationsTask.Dto
{
    public class RoleDto
    {
        [Required]
        public string RoleName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HR_Project.DTO
{
    public class loginUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

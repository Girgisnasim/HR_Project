using System.ComponentModel.DataAnnotations;

namespace HR_Project.DTO
{
    public class UserDto
    {
        public string ID { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //[Required]
        //public string FullName { get; set; }

        public List<string> Role { get; set; }
    }
}

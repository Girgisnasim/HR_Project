using System.ComponentModel.DataAnnotations;

namespace HR_Project.DTO
{
    public class RoleDTO
    {
        [Required, StringLength(250)]
        public string Name { get; set; }
    }
}

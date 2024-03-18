using System.ComponentModel.DataAnnotations;

namespace HR_Project.Models
{
    public class Department
    {

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        //relation with employee
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();

        //relation with Permissions_Department
        public virtual List<Permissions_Department> Permissions_Department { get; set; } = new List<Permissions_Department>();
    }
}

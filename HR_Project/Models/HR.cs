using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Project.Models
{
    public class HR
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string UseName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        //relation with Permissions_HR
        public List<Permissions_HR> permissions_HRs { get; set; } = new List<Permissions_HR>();


        //relation with Holiday
        public List<Holiday> Holiday { get; set; } = new List<Holiday>();


        //relation with Employee
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();


        //relation with Attend
        public virtual List<Attend> Attend { get; set; } = new List<Attend>();



        //relation with General_Rules


        public List<General_Rules> General_Rules =new List<General_Rules> ();



      
    }
}

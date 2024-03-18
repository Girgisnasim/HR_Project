using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Project.Models
{
    public class Permissions_Department
    {


        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }



        //relation with Department
        [ForeignKey("Department")]
        public int? Dept_id { get; set; }
        public Department? Department { get; set; }


    }
}

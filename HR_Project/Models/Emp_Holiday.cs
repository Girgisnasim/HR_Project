using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Project.Models
{
    public class Emp_Holiday
    {
        public int Id { get; set; }
        public int Duration { get; set; }

        //relation with employee
        [ForeignKey("Employee")]
        public int? Employee_id { get; set; }
        public Employee? Employee { get; set; }




        //relation with Holiday
        [ForeignKey("Holiday")]
        public int? Holiday_id { get; set; }
        public Holiday? Holiday { get; set; }


    }
}

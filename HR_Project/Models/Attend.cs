using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HR_Project.Models
{
    public class Attend
    {


        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateOnly Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}")]
        [Required]
        public TimeSpan LeaveTime { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}")]
        [Required]
        public TimeSpan AttendTime { get; set; }

      
        //relation with employee
        [ForeignKey("Employee")]
        public int? Emp_id { get; set; }
        public  Employee? Employee { get; set; }



        //relation with HR
        [ForeignKey("HRs")]
        public int? HR_id { get; set; }
        public  HR? HRs { get; set; }
    }
}

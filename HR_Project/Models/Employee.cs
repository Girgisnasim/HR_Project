using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Text.Json.Serialization;

namespace HR_Project.Models
{
    public class Employee
    {

        public int Id { get; set; }

        [MinLength(14)]
        [Required]
        public long SSN { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string Gender { get; set; }

        [MinLength(11)]
        [Required]
        public string phone { get; set; }


        [MinLength(3)]
        [Required]
        public string Address { get; set; }
       

        [Range(1000, 100000)]
        [Required]
        public int Salary { get; set; }

        [Required]
        public DateOnly HireDate { get; set; }

        public DateOnly BirthDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}")]
        [Required]
        public TimeSpan LeaveTime { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}")]
        [Required]
        public TimeSpan AttendTime { get; set; }
        [JsonIgnore]
        //relation with Department
        [ForeignKey("Department")]
        public int? Dept_id { get; set; }
        public  Department? Department { get; set; }
        //[NotMapped]
        //public string DeptName { get; set; }
       
        //relation with HR
        [ForeignKey("HRs")]
        public int? HR_id { get; set; }
        public  HR? HRs { get; set; }

       
        //relation with General_Rules
        [ForeignKey("General_Rules")]
        public int? Rules_id { get; set; }
        public  General_Rules? General_Rules { get; set; }


        //relation with Attend
       
        public List<Attend> Attend { get; set; }=new List<Attend>();



       

        //relation with Holiday
        public List<Emp_Holiday> EmpHolidays { get; set; } = new List<Emp_Holiday>();





    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Project.Models
{
    public class Holiday
    {

        public int Id { get; set; }



        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateOnly Date { get; set; }

        //relation with HR
        [ForeignKey("HR")]
        public int? HR_id { get; set; }
        public HR? HR { get; set; }


        //relation with Employee
        public List<Emp_Holiday> EmpHolidays { get; set; } = new List<Emp_Holiday>();

    }
}

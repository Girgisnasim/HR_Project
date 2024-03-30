using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HR_Project.DTO
{
    public class EmployeeWthDepartmentDTO
    {

            public int Id { get; set; }
            public long SSN { get; set; }
            public string Name { get; set; }
            public string Nationality { get; set; }
            public string Gender { get; set; }
            public string phone { get; set; }
            public string Address { get; set; }
            public int Salary { get; set; }
            public DateOnly HireDate { get; set; }
            public DateOnly BirthDate { get; set; }

            [DataType(DataType.Time)]
            [DisplayFormat(DataFormatString = "{0:hh-mm}")]
            public TimeSpan LeaveTime { get; set; }


            [DataType(DataType.Time)]
            [DisplayFormat(DataFormatString = "{0:hh-mm}")]
            public TimeSpan AttendTime { get; set; }
            public int? Dept_id { get; set; }
            public string DeptName { get; set; }
    }
    }


 

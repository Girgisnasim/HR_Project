using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HR_Project.DTO
{
    public class Emp_DTO
    {
        public string Name {  get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
        public int AbsenceDays { get; set;}
        public int AttendanceDays { get; set;}
        public int BounsHours { get; set;}
        public int LateHours { get; set;}
        public decimal TotalBouns { get; set;}
        public decimal TotalDiscount { get; set; }
        public decimal FinalSalary {  get; set; }
    }
}

namespace HR_Project.DTO
{
    public class AttendEmp_DTO
    {
        public string DepartmentName { get; set; }
        public string EmpName { get; set; }
        public List<TimeSpan> AttendTime  { get; set; } = new List<TimeSpan>();
        public List<TimeSpan>  LeaveTime { get; set; } = new List<TimeSpan>();
        public List<DateOnly> AttendDate { get; set; } = new List<DateOnly>();
    }
}

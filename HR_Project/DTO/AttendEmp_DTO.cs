namespace HR_Project.DTO
{
    public class AttendEmp_DTO
    {
        public string DepartmentName { get; set; }
        public string EmpName { get; set; }
        public TimeSpan AttendTime  { get; set; }
        public TimeSpan LeaveTime { get; set; }
        public DateTime AttendDate { get; set; }
    }
}

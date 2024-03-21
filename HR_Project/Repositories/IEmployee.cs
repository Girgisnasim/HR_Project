using HR_Project.DTO;
using HR_Project.Models;

namespace HR_Project.Repositories
{
    public interface IEmployee
    {
        //Get Employee
        public Emp_DTO GetEmployeeName(string Name,int month,int year);
        //Get Attend
        public List<AttendEmp_DTO> GetAttend(DateOnly  from, DateOnly to);
    }

}

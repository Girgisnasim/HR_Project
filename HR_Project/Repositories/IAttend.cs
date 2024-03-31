using HR_Project.DTO;
using HR_Project.Models;

namespace HR_Project.Repositories
{
    public interface IAttend
    {
        //Delete
        public void DeleteEmployeeAttend(int id);
        //update
        public void UpdateEmployeeAttend(AttendEmp_DTO attendance);
    }
}

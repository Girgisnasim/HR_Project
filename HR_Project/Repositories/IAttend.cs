using HR_Project.DTO;
using HR_Project.Models;

namespace HR_Project.Repositories
{
    public interface IAttend
    {
        //Delete
        public void DeleteEmployeeAttend(int id);
        //Get attend by id
        public Attend GetEmployeeAttend(int Id);
        //update
        public void UpdateEmployeeAttend(AttendDTO attendance);
    }
}

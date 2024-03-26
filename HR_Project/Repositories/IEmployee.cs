using HR_Project.DTO;
using HR_Project.Models;

namespace HR_Project.Repositories
{
    public interface IEmployee
    {
        //Get Employee
        public Emp_DTO GetEmployeeName(string Name,int month,int year);

        ///////////////////////////
        public List<Employee> GetAll();
        public Employee Add(EmployeeWthDepartmentDTO EmployeeDTO);
        public void Save();
        public Employee GetEmployee(int id);
        Employee GetEmployeeByName(string name);
        public Employee Edit(EmployeeWthDepartmentDTO EmployeeDTO, int id);
        public Employee Delete(int id);
    }
}

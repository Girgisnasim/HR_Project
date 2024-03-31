using HR_Project.DTO;
using HR_Project.Models;

namespace HR_Project.Repositories
{
    public interface IEmployee
    {
        //Get Employee
        public Emp_DTO GetEmployeeName(string Name,int month,int year);

        public int CountOccurrences(DateTime startDate, int month, string dayName);
        public List<Employee> GetAll();
        public Employee GetEmployee(int id);
        Employee GetEmployeeByName(string name);
        public Employee Add(EmployeeWthDepartmentDTO EmployeeDTO);
        public Employee Edit(EmployeeWthDepartmentDTO EmployeeDTO, int id);
        public Employee Delete(int id);
        public void Save();
        
      

        //Get Attend
        public List<AttendEmp_DTO> GetAttend(DateOnly  from, DateOnly to,string name);

    }

}

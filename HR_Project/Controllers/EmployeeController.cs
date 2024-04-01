using HR_Project.DTO;
using HR_Project.Models;
using HR_Project.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        HRContext context;
        IEmployee employeeRepository;
        public EmployeeController(HRContext context, IEmployee repository)
        {
            context = context;
            employeeRepository = repository;
        }




        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            var employees = employeeRepository.GetAll();


            List<EmployeeWthDepartmentDTO> EmployeesDTOs = new List<EmployeeWthDepartmentDTO>();

            foreach (var item in employees)
            {
                EmployeeWthDepartmentDTO EmployeeDTO = new EmployeeWthDepartmentDTO()
                {
                    Id = item.Id,
                    SSN = item.SSN,
                    Name = item.Name,
                    Nationality = item.Nationality,
                    Gender = item.Gender,
                    phone = item.phone,
                    Address = item.Address,
                    Salary = item.Salary,
                    HireDate = item.HireDate,
                    BirthDate = item.BirthDate,
                    LeaveTime = item.LeaveTime,
                    AttendTime = item.AttendTime,
                    Dept_id = item.Dept_id,
                    DeptName = item.Department.Name
            };
                EmployeesDTOs.Add(EmployeeDTO);
            }
            if (EmployeesDTOs == null)
            {
                return NotFound();

            }
            return Ok(EmployeesDTOs);
        }


        //[HttpGet("{name}")]
        //public ActionResult GetEmployeeByName(string name)
        //{
        //    var employees = employeeRepository.GetEmployeesStartingWith(name);


        //    List<GetEmployeeDTO> EmployeesDTOs = new List<GetEmployeeDTO>();

        //    foreach (var item in employees)
        //    {
        //        GetEmployeeDTO EmployeeDTO = new GetEmployeeDTO()
      
       


        [HttpGet("{id:int}")]
        public ActionResult GetByEmpID(int id)
        {
            if (id == null)
            {
                return NotFound();

            }
            else
            {
                var employee = employeeRepository.GetEmployee(id);
                EmployeeWthDepartmentDTO EmployeeDTO = new EmployeeWthDepartmentDTO()
                {
                    Id = employee.Id,
                    SSN = employee.SSN,
                    Name = employee.Name,
                    Nationality = employee.Nationality,
                    Gender = employee.Gender,
                    phone = employee.phone,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    HireDate = employee.HireDate,
                    BirthDate = employee.BirthDate,
                    LeaveTime = employee.LeaveTime,
                    AttendTime = employee.AttendTime,
                    Dept_id = employee.Dept_id,
                    DeptName = employee.Department.Name
                    //Dept_id = employee.Dept_id
                };
                return Ok(EmployeeDTO);
            }

        }
        [HttpGet("{name}")]
        public ActionResult GetEmployeeByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Invalid employee name");
            }

            var employee = employeeRepository.GetEmployeeByName(name);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            EmployeeWthDepartmentDTO employeeDTO = new EmployeeWthDepartmentDTO()
            {
                Id = employee.Id,
                SSN = employee.SSN,
                Name = employee.Name,
                Nationality = employee.Nationality,
                Gender = employee.Gender,
                phone = employee.phone,
                Address = employee.Address,
                Salary = employee.Salary,
                HireDate = employee.HireDate,
                BirthDate = employee.BirthDate,
                LeaveTime = employee.LeaveTime,
                AttendTime = employee.AttendTime,
                Dept_id = employee.Dept_id,
                DeptName = employee.Department.Name
            };

            return Ok(employeeDTO);
        }



        [HttpPost]
        public ActionResult AddEmployee(EmployeeWthDepartmentDTO EmployeeDTO)
        {
            if (EmployeeDTO == null)
            {
                return BadRequest("Invalid data. Please provide data for the new student.");
            }
            //if (EmployeeDTO == null) NotFound();
            Employee employee = new Employee();
            if (ModelState.IsValid)
            {
                employee = employeeRepository.Add(EmployeeDTO);
                employeeRepository.Save();
            }
            return Ok(employee);

        }




        //[HttpPut("{id}")]
        //public ActionResult EditEmployee(EmployeeWthDepartmentDTO EmployeeDTO, int id)
        //{
        //    if (EmployeeDTO == null) NotFound();
        //    if (id == null) BadRequest();
        //    Employee employee = employeeRepository.Edit(EmployeeDTO, id);
        //    employeeRepository.Save();
        //    return Ok(employee);
        //}



        [HttpPut("{id}")]
        public ActionResult<EmployeeWthDepartmentDTO> EditEmployee(EmployeeWthDepartmentDTO employeeDTO, int id)
        {
            if (employeeDTO == null) return NotFound();
            if (id == null) return BadRequest();

            // Map properties from EmployeeDTO to EmployeeWthDepartmentDTO or Employee entity
            var employeeWthDepartmentDTO = new EmployeeWthDepartmentDTO
            {
                // Map properties accordingly
                Name = employeeDTO.Name,
                Id = employeeDTO.Id,
                SSN = employeeDTO.SSN,
               
                Nationality = employeeDTO.Nationality,
                Gender = employeeDTO.Gender,
                phone = employeeDTO.phone,
                Address = employeeDTO.Address,
                Salary = employeeDTO.Salary,
                HireDate = employeeDTO.HireDate,
                BirthDate = employeeDTO.BirthDate,
                LeaveTime = employeeDTO.LeaveTime,
                AttendTime = employeeDTO.AttendTime,
                Dept_id = employeeDTO.Dept_id,
                DeptName = employeeDTO.DeptName
            };

            var employee = employeeRepository.Edit(employeeWthDepartmentDTO, id);
            employeeRepository.Save();

            // Map properties from Employee entity to EmployeeDTO
            var employeeDtoResult = new EmployeeWthDepartmentDTO
            {
                // Map properties accordingly
                Name = employeeDTO.Name,
                Id = employeeDTO.Id,
                SSN = employeeDTO.SSN,

                Nationality = employeeDTO.Nationality,
                Gender = employeeDTO.Gender,
                phone = employeeDTO.phone,
                Address = employeeDTO.Address,
                Salary = employeeDTO.Salary,
                HireDate = employeeDTO.HireDate,
                BirthDate = employeeDTO.BirthDate,
                LeaveTime = employeeDTO.LeaveTime,
                AttendTime = employeeDTO.AttendTime,
                Dept_id = employeeDTO.Dept_id,
                DeptName = employeeDTO.DeptName
                // Map other properties as needed
            };

            return Ok(employeeDtoResult);
        }


        [HttpDelete]
        public ActionResult DeleteEmployee(int id)
        {
            if (id == null) BadRequest();
            Employee employee = employeeRepository.Delete(id);
            employeeRepository.Save();
            return Ok(employee);
        }
    }
}

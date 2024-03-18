using HR_Project.DTO;
using HR_Project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendController : ControllerBase
    {
        private IEmployee EmployeeRepo;
        public EmployeeAttendController(IEmployee _EmployeeRepo)
        {
            this.EmployeeRepo = _EmployeeRepo;
        }

        [HttpGet("{name:alpha}")]
        public ActionResult GetEmp(string name) 
        { 
            Emp_DTO emp=EmployeeRepo.GetEmployeeName(name);
            return Ok(emp);
        }
    }
}

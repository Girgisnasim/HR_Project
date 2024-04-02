using HR_Project.DTO;
using HR_Project.Models;
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
        private IAttend attend;
        public EmployeeAttendController(IEmployee _EmployeeRepo,IAttend _attend)
        {
            this.EmployeeRepo = _EmployeeRepo;
            this.attend = _attend;
        }

        [HttpGet("{name:alpha}")]
        public ActionResult GetEmp(string name, int month, int year)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            if (currentYear >= year && currentMonth >= month && year > 2008 && month >= 1 && month <= 12)
            {
                Emp_DTO emp = EmployeeRepo.GetEmployeeName(name, month, year);
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("attend")]
        public ActionResult GetAttend([FromQuery] int fromYear, [FromQuery] int fromMonth, [FromQuery] int fromDay,
                                       [FromQuery] int toYear, [FromQuery] int toMonth, [FromQuery] int toDay, [FromQuery(Name = "name")] string? name)
        {

            // Create DateOnly instances from user-provided values
            DateOnly from = new DateOnly(fromYear, fromMonth, fromDay);
            DateOnly to = new DateOnly(toYear, toMonth, toDay);

            if (from > to || from.Year < 2008 || to > DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest();
            }

            else
            {
                List<AttendEmp_DTO> attendEmp_DTOs = EmployeeRepo.GetAttend(from, to, name);
                return Ok(attendEmp_DTOs);
            }
        }
        [HttpDelete]
        public ActionResult DeleteEmpAttend(int id)
        {
            attend.DeleteEmployeeAttend(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetAttend(int id)
        {
           Attend attendEmp= attend.GetEmployeeAttend(id);
            return Ok(attendEmp);
        }
        [HttpPut()]
        public ActionResult UpdateEmpAttend([FromBody] AttendDTO attendance)
        {
            attend.UpdateEmployeeAttend(attendance);
            return Ok();
        }
    }
}


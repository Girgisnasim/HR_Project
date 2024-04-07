using HR_Project.DTO;
using HR_Project.Models;
using HR_Project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        IHoliday holiday;
        IEmployee employee;
        IEmp_Holiday employee_holiday;
        public HolidayController(IHoliday holiday, IEmployee employee, IEmp_Holiday employee_holiday)
        {
            this.holiday = holiday;
            this.employee = employee;
            this.employee_holiday = employee_holiday;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var Holiday = holiday.GetAll();
            List<HolidayDTO> holidayDTOs = new List<HolidayDTO>();

            foreach (var item in Holiday)
            {
                HolidayDTO DTO = new HolidayDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Date = item.Date,
                    HR_id = item.HR_id,
                    //Emp_name = item.Employee.Name,

                };
                holidayDTOs.Add(DTO);
            }
            if (holidayDTOs == null)
            {
                return NotFound();

            }
            return Ok(holidayDTOs);
        }
        [HttpGet("{id}")]
        //public ActionResult GetById(int id)
        //{
        //    var Holiday = holiday.GetById(id);

        //    if (Holiday == null)
        //    {
        //        return NotFound();

        //    }
        //    return Ok(Holiday);

        //}
        public ActionResult GetById(int id)
        {
            var Holiday = holiday.GetById(id);

            var holidayDTO = new HolidayDTO
            {
                Id = Holiday.Id,
                Name = Holiday.Name,
                Date = Holiday.Date,
                HR_id = Holiday.HR_id,

            };

            return Ok(holidayDTO);
        }


        [HttpPost("{duration:int}")]
        public ActionResult Addholiday(HolidayDTO holidayDTO,int duration)
        {
            List<Employee> employees= employee.GetAll();
            Holiday holidays=holiday.insert(holidayDTO);
                holiday.Save();
           foreach(var emp in employees)
            {
                Emp_Holiday emp_Holiday = new Emp_Holiday();
                emp_Holiday.Employee_id = emp.Id;
                emp_Holiday.Holiday_id = holidays.Id;
                emp_Holiday.Duration= duration;
                employee_holiday.AddEmpHoliday(emp_Holiday);
                
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Editholiday(HolidayDTO holidayDTO)
        {

            Holiday Holiday = holiday.Update(holidayDTO);
            if(holidayDTO == null)
            {
                return BadRequest();
            }
            else {
                holiday.Save();
                return Ok();
            }

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            holiday.Delete(id);
            holiday.Save();
            return Ok();
        }
    }
}


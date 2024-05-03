using HR_Project.DTO;
using HR_Project.Models;
using HR_Project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendController : ControllerBase
    {
        IAttend attend;
        public AttendController(IAttend attend)
        {
            this.attend = attend;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var Attend = attend.GetAll();
            List<Attend_DTO> attendDTOs = new List<Attend_DTO>();

            foreach (var item in Attend)
            {
                Attend_DTO DTO = new Attend_DTO()
                {
                    Id = item.Id,
                    Date = item.Date,
                    LeaveTime = item.LeaveTime,
                    AttendTime = item.AttendTime,
                    HR_id = item.HR_id,
                    Emp_id = item.Emp_id,

                };
                attendDTOs.Add(DTO);
            }
            if (attendDTOs == null)
            {
                return NotFound();

            }
            return Ok(attendDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var Attend = attend.GetById(id);

            if (Attend == null)
            {
                return NotFound();

            }
            var Attend_DTO = new Attend_DTO
            {
                Id = Attend.Id,
                Date = Attend.Date,
                LeaveTime = Attend.LeaveTime,
                AttendTime = Attend.AttendTime,
                HR_id = Attend.HR_id,
                Emp_id = Attend.Emp_id,

            };
            return Ok(Attend_DTO);

        }



        [HttpPost("{id:int}")]
        public ActionResult AddAttend(int id,int hr_id)
        {
            DateTime dateTime= DateTime.Now;
            Attend attendEmp=attend.insert(id, dateTime,hr_id);
            if(attendEmp == null)
            {
                return BadRequest();
            }
            else
            {
                attend.Save();
                return Ok(attendEmp);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult EditAttend(int id)
        {
            Attend Attend = attend.Update(id);
            if (Attend == null)
            {
                return BadRequest();
            }
            else
            {
                 attend.Save();
                 return Ok(Attend);

            }
        }



        [HttpDelete]
        public ActionResult DeleteEmployee(int id)
        {
            if (id == null) BadRequest();
            Attend Attend = attend.Delete(id);
            attend.Save();
            return Ok(Attend);
        }
    }
}

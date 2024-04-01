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
        public HolidayController(IHoliday holiday)
        {
            this.holiday=holiday;
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
                    HR_id= item.HR_id,
                    HR_Name=item.HR.Name,
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

            if (Holiday == null)
            {
                return NotFound();
            }

            var holidayDTO = new HolidayDTO
            {
                Id = Holiday.Id,
                Name = Holiday.Name,
                Date = Holiday.Date,
                HR_id = Holiday.HR_id,
                HR_Name=Holiday.HR.Name
                
            };

            return Ok(holidayDTO);
        }


        [HttpPost]
        public ActionResult Addholiday(HolidayDTO holidayDTO)
        {
            if (holidayDTO == null) NotFound();
            Holiday Holiday = new Holiday();
            if (ModelState.IsValid)
            {
                Holiday = holiday.insert(holidayDTO);
                holiday.Save();

            }
            return Ok(Holiday);
        }

        [HttpPut("{id}")]
        public ActionResult Editholiday(HolidayDTO holidayDTO, int id)
        {
            if (holidayDTO == null) NotFound();
            if (id == null) BadRequest();
            Holiday Holiday = holiday.Update(holidayDTO, id);
            holiday.Save();
            return Ok(Holiday);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id == null) BadRequest();
            Holiday Holiday = holiday.Delete(id);
            holiday.Save();
            return Ok(Holiday);
        }
    }
}


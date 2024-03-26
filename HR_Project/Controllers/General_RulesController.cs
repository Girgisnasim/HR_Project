using HR_Project.DTO;
using HR_Project.Models;
using HR_Project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class General_RulesController : ControllerBase
    {
        IGeneral_Rules general_Rules;


        public General_RulesController(HRContext context, IGeneral_Rules general_Rules)
        {

            this.general_Rules = general_Rules;

        }

        // get all
        [HttpGet]
        public ActionResult GetAll()
        {
            var General_Rules = general_Rules.GetAll();
            List<RulesDTO> RulesDTOs = new List<RulesDTO>();

            foreach (var item in General_Rules)
            {
                RulesDTO DTO = new RulesDTO()
                {
                    Id = item.Id,
                    Bonus = item.Bonus,
                    Discound = item.Discound,
                    OffDay1 = item.OffDay1,
                    OffDay2 = item.OffDay2,
                    HR_id = item.HR_id,
                    HR_Name = item.HR.Name


                };
                RulesDTOs.Add(DTO);
            }
            if (RulesDTOs == null)
            {
                return NotFound();

            }
            return Ok(RulesDTOs);
        }


        // get by id 


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var General_Rules = general_Rules.GetById(id);

            if (General_Rules == null)
            {
                return NotFound();

            }
            return Ok(General_Rules);

        }

        // add rule

        [HttpPost]
        public ActionResult Addrule(RulesDTO rulesDTO)
        {
            if (rulesDTO == null) NotFound();
            General_Rules General_Rules = new General_Rules();
            if (ModelState.IsValid)
            {
                General_Rules = general_Rules.insert(rulesDTO);
                general_Rules.Save();

            }
            return Ok(General_Rules);
        }

        // edit rule


        [HttpPut("{id}")]
        public ActionResult Editrule(RulesDTO rulesDTO, int id)
        {
            if (rulesDTO == null) NotFound();
            if (id == null) BadRequest();

            General_Rules General_Rules = general_Rules.Update(rulesDTO, id);
            general_Rules.Save();
            return Ok(General_Rules);
        }





        // delete rule

        [HttpDelete]
        public ActionResult Deleterule(int id)
        {
            if (id == null) BadRequest();
            General_Rules General_Rules = general_Rules.Delete(id);
            general_Rules.Save();
            return Ok(General_Rules);
        }
    }
}

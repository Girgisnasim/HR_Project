using HR_Project.DTO;
using HR_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_Project.Repositories
{
    public class Generals_Rules:IGeneral_Rules
    {
        private HRContext context;

        public Generals_Rules(HRContext context)
        {
            this.context = context;
        }
        public List<General_Rules> GetAll()
        {
            return context.General_Rules.Include(h => h.HR).ToList();


        }

        public General_Rules GetById(int id)
        {
            return context.General_Rules.Include(h => h.HR).SingleOrDefault(h => h.Id == id);
        }

        public General_Rules insert(RulesDTO rulesDTO)
        {
            General_Rules rules = new General_Rules()
            {
                Id = rulesDTO.Id,
                Bonus = rulesDTO.Bonus,
                Discound = rulesDTO.Discound,
                OffDay1 = rulesDTO.OffDay1,
                OffDay2 = rulesDTO.OffDay2,
                HR_id = rulesDTO.HR_id,
               
            };
            context.General_Rules.Add(rules);
            return rules;

        }

        public void Save()
        {
            context.SaveChanges();
        }

        public General_Rules Update(RulesDTO rulesDTO, int id)
        {
            General_Rules rules = GetById(id);

            rules.Id = id;
            rules.Discound = rulesDTO.Discound;
            rules.Bonus = rulesDTO.Bonus;
            rules.OffDay1 = rulesDTO.OffDay1;
            rules.OffDay2 = rulesDTO.OffDay2;
            rules.HR_id = rulesDTO.HR_id;

            return rules;
        }

        public General_Rules Delete(int id)
        {
            General_Rules rules = GetById(id);
            context.General_Rules.Remove(rules);
            return rules;
        }
    }
}

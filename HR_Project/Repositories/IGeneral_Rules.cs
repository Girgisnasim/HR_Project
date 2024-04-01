using HR_Project.DTO;
using HR_Project.Models;

namespace HR_Project.Repositories
{
    public interface IGeneral_Rules
    {
        public List<General_Rules> GetAll();
        public General_Rules GetById(int id);
        public void Save();
        public General_Rules insert(RulesDTO rulesDTO);
        public General_Rules Update(RulesDTO rulesDTO,int id);
        public General_Rules Delete(int id);
    }
}

using HR_Project.DTO;
using HR_Project.Models;

namespace HR_Project.Repositories
{
    public interface IHoliday
    {
        public List<Holiday> GetAll();
     
        public Holiday GetById(int id);

       
        public void Save();

        public void insert(HolidayDTO holidayDTO);
        public Holiday Update(HolidayDTO holidayDTO);
        public void Delete(int id);
    }
}

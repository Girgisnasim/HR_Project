using HR_Project.DTO;
using HR_Project.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HR_Project.Repositories
{
    public class Holidays:IHoliday
    {
        private HRContext context;

        public Holidays(HRContext context)
        {
            this.context = context;
        }

       

        public List<Holiday> GetAll()
        {
            return context.Holiday.Include(h=>h.HR).ToList();
        }

        public Holiday GetById(int id)
        {
            return context.Holiday.SingleOrDefault(h=>h.Id==id);
        }
        
            
        public Holiday insert(HolidayDTO holidayDTO)
        {

            Holiday holiday = new Holiday()
            {
                Id = holidayDTO.Id,
                Name = holidayDTO.Name,
                Date = holidayDTO.Date,
                HR_id = 2,
               
            };
            context.Holiday.Add(holiday);
            return holiday;

        }

        public void Save()
        {
                context.SaveChanges();
           
        }

        public Holiday Update(HolidayDTO holidayDTO)
        {
            Holiday holiday = context.Holiday.SingleOrDefault(h => h.Id == holidayDTO.Id);
            holiday.Id = holidayDTO.Id;
            holiday.Name = holidayDTO.Name;
            holiday.Date = holidayDTO.Date;
            holiday.HR_id = holidayDTO.HR_id;
            return holiday;
        }
        public void Delete(int id)
        {
            Holiday holiday = GetById(id);
            context.Holiday.Remove(holiday);
        }

       
    }
}

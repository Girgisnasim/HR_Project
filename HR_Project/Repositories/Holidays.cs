using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Holidays:IHoliday
    {
        private HRContext context;

        public Holidays(HRContext context)
        {
            this.context = context;
        }
    }
}

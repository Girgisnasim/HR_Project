using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Holiday:IHoliday
    {
        private HRContext context;

        public Holiday(HRContext context)
        {
            this.context = context;
        }
    }
}

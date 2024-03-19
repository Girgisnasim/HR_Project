using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class HRs:IHR
    {
        private HRContext context;

        public HRs(HRContext context)
        {
            this.context = context;
        }
    }
}

using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Attend:IAttend
    {
        private HRContext context;

        public Attend(HRContext context)
        {
            this.context = context;
        }
    }
}

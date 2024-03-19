using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Attends:IAttend
    {
        private HRContext context;

        public Attends(HRContext context)
        {
            this.context = context;
        }
    }
}

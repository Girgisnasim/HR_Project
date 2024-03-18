using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class HR:IHR
    {
        private HRContext context;

        public HR(HRContext context)
        {
            this.context = context;
        }
    }
}

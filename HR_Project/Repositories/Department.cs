using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Department:IDepartment
    {
        private HRContext context;

        public Department(HRContext context)
        {
            this.context = context;
        }
    }
}

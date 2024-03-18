using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Departments:IDepartment
    {
        private HRContext context;

        public Departments(HRContext context)
        {
            this.context = context;
        }
    }
}

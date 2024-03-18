using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Employee:IEmployee
    {
        private HRContext context;

        public Employee(HRContext context)
        {
            this.context = context;
        }
    }
}

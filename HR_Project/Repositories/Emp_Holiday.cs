using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Emp_Holiday:IEmp_Holiday
    {
        private HRContext context;

        public Emp_Holiday(HRContext context)
        {
            this.context = context;
        }
    }
}

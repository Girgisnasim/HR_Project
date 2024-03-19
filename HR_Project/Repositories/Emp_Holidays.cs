using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Emp_Holidays:IEmp_Holiday
    {
        private HRContext context;

        public Emp_Holidays(HRContext context)
        {
            this.context = context;
        }
    }
}

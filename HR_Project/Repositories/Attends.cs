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

        public void DeleteEmployeeAttend(int id)
        {
            Attend EmpAttend = context.Attend.SingleOrDefault(x => x.Id == id);
            context.Attend.Remove(EmpAttend);
            context.SaveChanges();
        }
    }
}

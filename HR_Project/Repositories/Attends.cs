using HR_Project.DTO;
using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Attends : IAttend
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

        public void UpdateEmployeeAttend(AttendEmp_DTO attendance)
        {
            // Retrieve the corresponding employee attendance from the database
            Attend EmpAttend = context.Attend.Find(attendance.Id);

            // Update the retrieved attendance entity with the new values
            EmpAttend.AttendTime = attendance.AttendTime[0];
            EmpAttend.LeaveTime = attendance.LeaveTime[0];

            // Save the changes to the database
            context.SaveChanges();
        }
    }
}

using HR_Project.DTO;
using HR_Project.Models;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;



namespace HR_Project.Repositories
{
    public class Attends : IAttend
    {
        private HRContext context;

        public Attends(HRContext context)
        {
            this.context = context;
        }

        public List<Attend> GetAll()
        {
            
            return context.Attend.Include(e => e.Employee).Include(h=>h.HRs).ToList();
        }
        public Attend GetById(int id)
        {
            return context.Attend.Include(e => e.Employee).Include(h => h.HRs).SingleOrDefault(A => A.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        //public string GetEmployeeNameById(A empId)
        //{
        //    using (var context = new HRContext())
        //    {
               
        //        var employee = context.Employee.FirstOrDefault(e => e.Id == empId);

               
        //        if (employee != null)
        //        {
        //            return employee.Name; 
        //        }
        //        else
        //        {
        //            return null; 
        //        }
        //    }
        //}

        public Attend insert(Attend_DTO attendDTO)
        {
            //string employeeName = GetEmployeeNameById(attendDTO.Emp_id);

            Attend attend = new Attend()
            {
                Id = attendDTO.Id,
                Date = attendDTO.Date,
                LeaveTime = attendDTO.LeaveTime,
                AttendTime = attendDTO.AttendTime,
                Emp_id = attendDTO.Emp_id,
                //Emp_Name = employeeName
            };
            context.Attend.Add(attend);
          
            return attend;
          
        }
     
        public Attend Update(Attend_DTO attendDTO, int id)
        {
            Attend attend = GetById(id);
            attend.Id = id;
            attend.Date = attendDTO.Date;
            attend.AttendTime = attendDTO.AttendTime;
            attend.LeaveTime= attendDTO.LeaveTime;
            attend.Emp_id = attendDTO.Emp_id;
            return attend;
        }

        public Attend Delete(int id)
        {
            Attend attend = GetById(id);
            context.Attend.Remove(attend);
            return attend;
        
        }

        

        public void DeleteEmployeeAttend(int id)
        {
            Attend EmpAttend = context.Attend.SingleOrDefault(x => x.Id == id);
            context.Attend.Remove(EmpAttend);
            context.SaveChanges();
        }

        public Attend GetEmployeeAttend(int Id)
        {
            Attend attend = context.Attend.SingleOrDefault(x => x.Id == Id);
            return attend;
        }

        public void UpdateEmployeeAttend(AttendDTO attendance)
        {
            // Retrieve the corresponding employee attendance from the database
            Attend EmpAttend = context.Attend.Find(attendance.Id);

            // Update the retrieved attendance entity with the new values
            EmpAttend.AttendTime = attendance.AttendTime;
            EmpAttend.LeaveTime = attendance.LeaveTime;

            // Save the changes to the database
            context.SaveChanges();
        }

    }
}

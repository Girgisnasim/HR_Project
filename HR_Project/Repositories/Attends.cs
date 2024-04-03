using HR_Project.DTO;
using HR_Project.Models;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Globalization;



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

            if (EmpAttend == null)
            {
                // Handle case where attendance record with given ID is not found
                throw new ArgumentException("Attendance record not found.");
            }

            // Parse the input time strings to DateTime objects
            DateTime attTime;
            if (!DateTime.TryParseExact(attendance.AttendTime, new[] { "HH:mm:ss", "HH:mm" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out attTime))
            {
                // Handle invalid time format
                throw new ArgumentException("Invalid attend time format. Please use 'HH:mm' or 'HH:mm:ss'.");
            }

            DateTime leaveTime;
            if (!DateTime.TryParseExact(attendance.LeaveTime, new[] { "HH:mm:ss", "HH:mm" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out leaveTime))
            {
                // Handle invalid time format
                throw new ArgumentException("Invalid leave time format. Please use 'HH:mm' or 'HH:mm:ss'.");
            }

            // Update the retrieved attendance entity with the new values
            EmpAttend.AttendTime = attTime.TimeOfDay;
            EmpAttend.LeaveTime = leaveTime.TimeOfDay;

            // Save the changes to the database
            context.Attend.Update(EmpAttend);
            context.SaveChanges();
        }

       
    }
}

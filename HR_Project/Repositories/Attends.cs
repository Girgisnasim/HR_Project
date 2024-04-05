using HR_Project.DTO;
using HR_Project.Models;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
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
      

        public Attend insert(int id , DateTime dateTime, int hr_id)
        {
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            Attend attend=context.Attend.SingleOrDefault(e => e.Emp_id == id && e.Date== dateOnly);

            if(attend == null)
            {
                Attend AttendEmp=new Attend();
                AttendEmp.Date = dateOnly;
                AttendEmp.Emp_id= id;
                AttendEmp.AttendTime = dateTime-DateTime.Today;
                AttendEmp.HR_id = hr_id;
                context.Attend.Add(AttendEmp);
                return AttendEmp;

            }
            else
            {
                return null;
            }
          
        }
     
        public Attend Update(int id)
        {
            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            Attend attend = context.Attend.SingleOrDefault(e => e.Emp_id == id && e.Date == dateOnly);

            if(attend == null)
            {
                return null;
            }
            else
            {
                attend.LeaveTime=dateTime- DateTime.Today;
                return attend;
            }

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

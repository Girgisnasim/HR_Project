using HR_Project.DTO;
using HR_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace HR_Project.Repositories
{
    public class Employees : IEmployee
    {
        private HRContext context;

        public Employees(HRContext context)
        {
            this.context = context;
        }

        public Emp_DTO GetEmployeeName(string Name)
        {
            Employee Emp = context.Employee.Include(D => D.Department)
                .Include(G => G.General_Rules)
                .SingleOrDefault(e => e.Name == Name);

            if (Emp == null)
            {
                // Handle the case where no employee with the given ID is found
                return null; // Or throw an exception, depending on your requirements
            }

            List<Attend> attend = context.Attend.Where(a => a.Emp_id == Emp.Id).ToList();

            Emp_DTO employee = new Emp_DTO();
            employee.Name = Emp.Name;
            employee.DepartmentName = Emp.Department.Name;
            employee.Salary = Emp.Salary;

            // Calculate attendance and absence days
            int attendanceDays = attend.Count();
            int absenceDays = 2;

            employee.AttendanceDays = attendanceDays;
            employee.AbsenceDays = absenceDays;

            // Initialize bonus hours and late hours
            int bonusHours = 0;
            int lateHours = 0;

            // Calculate bonus and late hours
            foreach (var item in attend)
            {
                if (item.AttendTime > Emp.AttendTime)
                {
                    lateHours += Convert.ToInt32((item.AttendTime - Emp.AttendTime).TotalHours);
                }
                if (item.LeaveTime > Emp.LeaveTime)
                {
                    bonusHours += Convert.ToInt32((item.LeaveTime - Emp.LeaveTime).TotalHours);
                }
            }

            // Calculate total bonus, total discount, and final salary
            decimal totalBonus = Convert.ToDecimal(bonusHours * Emp.General_Rules.Bonus);
            decimal totalDiscount = Convert.ToDecimal(lateHours * Emp.General_Rules.Discound);
            decimal finalSalary = (Emp.Salary - totalDiscount) + totalBonus;

            // Assign calculated values to employee DTO
            employee.BounsHours = bonusHours;
            employee.LateHours = lateHours;
            employee.TotalBouns = totalBonus;
            employee.TotalDiscount = totalDiscount;
            employee.FinalSalary = finalSalary;

            return employee;
        }

    }
}

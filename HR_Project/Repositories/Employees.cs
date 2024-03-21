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

        public List<AttendEmp_DTO> GetAttend(DateOnly from, DateOnly to)
        {
            List<Attend> attends = context.Attend
                .Include(e=>e.Employee)
                .Include(e=>e.Employee.Department)
                .Where(e=> e.Date>=from && e.Date<=to ).ToList();

            List<AttendEmp_DTO> attendEmp_DTOs = new List<AttendEmp_DTO>();

            foreach(Attend emp in attends)
            {
                AttendEmp_DTO attendEmp=new AttendEmp_DTO();
                attendEmp.EmpName = emp.Employee.Name;
                attendEmp.DepartmentName = emp.Employee.Department.Name;
                List<Attend> test = context.Attend.
                    Where(e => e.Emp_id == emp.Emp_id).ToList();
                attendEmp.AttendTime.Add(emp.AttendTime);
                attendEmp.LeaveTime.Add(emp.LeaveTime);
                attendEmp.AttendDate.Add(emp.Date);
                //foreach(var item in test)
                //{
                //    attendEmp.AttendTime.Add(item.AttendTime);
                //    attendEmp.LeaveTime.Add(item.LeaveTime);
                //    attendEmp.AttendDate.Add(item.Date);
                //}
                attendEmp_DTOs.Add(attendEmp);
               
            }
            return attendEmp_DTOs;

        }

     
        public Emp_DTO GetEmployeeName(string Name,int month,int year)
        { 
            
            Employee Emp = context.Employee.Include(D => D.Department)
                .Include(G => G.General_Rules)
                .SingleOrDefault(e => e.Name == Name);

            if (Emp == null)
            {
                // Handle the case where no employee with the given ID is found
                return null; // Or throw an exception, depending on your requirements
            }

            List<Attend> attend = context.Attend.Where(a => a.Emp_id == Emp.Id && a.Date.Month==month&&a.Date.Year==year).ToList();

            Emp_DTO employee = new Emp_DTO();
            employee.Name = Emp.Name;
            employee.DepartmentName = Emp.Department.Name;
            employee.Salary = Emp.Salary;

            // Calculate attendance and absence days
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int attendanceDays = attend.Count();
            int absenceDays = daysInMonth - attendanceDays - 8;


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
            decimal totalDiscount = Convert.ToDecimal((lateHours * Emp.General_Rules.Discound)+(absenceDays*Emp.General_Rules.Discound*8));
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





//public Emp_DTO GetEmployeeName(string Name)
//{
//    Employee Emp = context.Employee.Include(D => D.Department)
//        .Include(G => G.General_Rules)
//        .SingleOrDefault(e => e.Name == Name);

//    if (Emp == null)
//    {
//        // Handle the case where no employee with the given ID is found
//        return null; // Or throw an exception, depending on your requirements
//    }

//    List<Attend> attend = context.Attend.Where(a => a.Emp_id == Emp.Id).ToList();

//    Emp_DTO employee = new Emp_DTO();
//    employee.Name = Emp.Name;
//    employee.DepartmentName = Emp.Department.Name;
//    employee.Salary = Emp.Salary;

//    // Calculate attendance and absence days
//    int attendanceDays = attend.Count();
//    int absenceDays = 2;

//    employee.AttendanceDays = attendanceDays;
//    employee.AbsenceDays = absenceDays;

//    // Initialize bonus hours and late hours
//    int bonusHours = 0;
//    int lateHours = 0;

//    // Calculate bonus and late hours
//    foreach (var item in attend)
//    {
//        if (item.AttendTime > Emp.AttendTime)
//        {
//            lateHours += Convert.ToInt32((item.AttendTime - Emp.AttendTime).TotalHours);
//        }
//        if (item.LeaveTime > Emp.LeaveTime)
//        {
//            bonusHours += Convert.ToInt32((item.LeaveTime - Emp.LeaveTime).TotalHours);
//        }
//    }

//    // Calculate total bonus, total discount, and final salary
//    decimal totalBonus = Convert.ToDecimal(bonusHours * Emp.General_Rules.Bonus);
//    decimal totalDiscount = Convert.ToDecimal(lateHours * Emp.General_Rules.Discound);
//    decimal finalSalary = (Emp.Salary - totalDiscount) + totalBonus;

//    // Assign calculated values to employee DTO
//    employee.BounsHours = bonusHours;
//    employee.LateHours = lateHours;
//    employee.TotalBouns = totalBonus;
//    employee.TotalDiscount = totalDiscount;
//    employee.FinalSalary = finalSalary;

//    return employee;
//}
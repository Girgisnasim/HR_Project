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


        public List<Employee> GetAll()
        {
            return context.Employee.Include(e => e.Department).ToList();

        }
        ////////////////////////////////////////////
        public Employee GetEmployee(int id)
        {
            return context.Employee.Include(e => e.Department).FirstOrDefault(n => n.Id == id);


        }
        ////////////////////////////////////////////

        public Employee GetEmployeeByName(string name)
        {
            return context.Employee.Include(e => e.Department)
                                   .FirstOrDefault(e => e.Name == name);
        }

        ////////////////////////////////////////////

        public Employee Add(EmployeeWthDepartmentDTO EmployeeDTO)
        {
           

            Employee employee = new Employee()
            {

                SSN = EmployeeDTO.SSN,
                Name = EmployeeDTO.Name,
                Nationality = EmployeeDTO.Nationality,
                Gender = EmployeeDTO.Gender,
                phone = EmployeeDTO.phone,
                Address = EmployeeDTO.Address,
                Salary = EmployeeDTO.Salary,
                HireDate = EmployeeDTO.HireDate,
                BirthDate = EmployeeDTO.BirthDate,
                LeaveTime = EmployeeDTO.LeaveTime,
                AttendTime = EmployeeDTO.AttendTime,
                Dept_id = EmployeeDTO.Dept_id,
                

            };
            context.Employee.Add(employee);
            return employee;

        }

        ////////////////////////////////////////////
      
        public Employee Edit(EmployeeWthDepartmentDTO EmployeeDTO, int id)
        {


            Employee employee = GetEmployee(id);
            employee.Id = id;
            employee.SSN = EmployeeDTO.SSN;
            employee.Name = EmployeeDTO.Name;
            employee.Nationality = EmployeeDTO.Nationality;
            employee.Gender = EmployeeDTO.Gender;
            employee.phone = EmployeeDTO.phone;
            employee.Address = EmployeeDTO.Address;
            employee.Salary = EmployeeDTO.Salary;
            employee.HireDate = EmployeeDTO.HireDate.AddDays(1);
            employee.BirthDate = EmployeeDTO.BirthDate.AddDays(1);
            employee.LeaveTime = EmployeeDTO.LeaveTime;
            employee.AttendTime = EmployeeDTO.AttendTime;
            employee.Dept_id = EmployeeDTO.Dept_id;


            return employee;

        }

        ////////////////////////////////////////////
        public Employee Delete(int id)
        {
            Employee employee = GetEmployee(id);
            context.Employee.Remove(employee);
            return employee;
        }





        ////////////////////////////////////////////
        public void Save()
        {
            context.SaveChanges();
        }
        ////////////////////////////////////////////
     




        //public List<Employee> GetEmployeeByName(string name)
        //{
        //    return context.Employee.Include(e => e.Department).Where(e => e.Name == name).ToList();
        //}


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

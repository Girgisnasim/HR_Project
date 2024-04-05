
﻿using HR_Project.Models;
using HR_Project.DTO;

﻿using HR_Project.DTO;
using HR_Project.Models;


namespace HR_Project.Repositories
{
    public interface IAttend
    {

        //Get Attend By Name
        public List<Attend> GetAll();
        //public Attend GetAttendance(int id);
         public Attend GetById(int id);

        //List<Attend> GetByEmpName(string empName);
        public void Save();
        //public string GetEmployeeNameById(int empId);

        // For Insert, Update And Delete
        public Attend insert(int id,DateTime dateTime,int hr_id);
        public Attend Update(int id);
        public Attend Delete(int id);

       //Delete
        public void DeleteEmployeeAttend(int id);
        //Get attend by id
        public Attend GetEmployeeAttend(int Id);
        //update
        public void UpdateEmployeeAttend(AttendDTO attendance);

    }
}


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
        public Attend insert(Attend_DTO attendDTO);
        public Attend Update(Attend_DTO attendDTO, int id);
        public Attend Delete(int id);

       //Delete
        public void DeleteEmployeeAttend(int id);
        //update
        public void UpdateEmployeeAttend(AttendEmp_DTO attendance);

    }
}

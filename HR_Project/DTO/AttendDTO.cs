using HR_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HR_Project.DTO
{
    public class AttendDTO
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public TimeSpan LeaveTime { get; set; }

        public TimeSpan AttendTime { get; set; }

        public int? Emp_id { get; set; }

        public int? HR_id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Project.Models
{
    public class General_Rules
    {
        public int Id { get; set; }
        public double Discound { get; set; }
        public double Bonus { get; set; }
        public string OffDay1 { get; set; }
        public string OffDay2 { get; set; }



        //relation with Employee
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();


        //relation with HR
        [ForeignKey("HR")]
         public  int? HR_id { get; set; }
         public HR? HR { get; set; }

       


    }
}

using HR_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace HR_Project.DTO
{
    public class RulesDTO
    {
        public int Id { get; set; }
        public double Discound { get; set; }
        public double Bonus { get; set; }

        public string OffDay1 { get; set; }

        [RegularExpression("^(Friday|Saturday|Sunday|Monday|Tuesday|Wednesday|Thursday)$", ErrorMessage = "Must be a Day")]

        public string OffDay2 { get; set; }


        public int? HR_id { get; set; }

        public string HR_Name { get; set; }

        
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HR_Project.DTO
{
    public class HolidayDTO
    {
        public int Id { get; set; }


        public string Name { get; set; }

  
        public DateOnly Date { get; set; }

      
        public int? HR_id { get; set; }
    }
}

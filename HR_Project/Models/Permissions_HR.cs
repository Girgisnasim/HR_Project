using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Project.Models
{
    public class Permissions_HR
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        //relation with HR
        [ForeignKey("HR")]
        public int? HR_id { get; set; }
        public HR? HR { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HR_Project.Models
{
    public class HRContext :DbContext
    {
        public HRContext()
        {
           
        }

        public HRContext(DbContextOptions options):base(options)
        { 
            
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Attend> Attend { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<General_Rules> General_Rules { get; set; }
        public virtual DbSet<Emp_Holiday> Emp_Holiday { get; set; }
        public virtual DbSet<HR> HR { get; set; }
        public virtual DbSet<Permissions_Department> Permissions_Department { get; set; }
        public virtual DbSet<Permissions_HR> Permissions_HR { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-IDORBHT;Initial Catalog=HRSystem;Integrated Security=True;TrustServerCertificate=True");
        //}


    }
}

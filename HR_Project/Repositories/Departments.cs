using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Departments:IDepartment
    {
        private HRContext context;

        public Departments(HRContext context)
        {
            this.context = context;
        }


        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }

        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }

        public Department GetByName(string name)
        {
            return context.Department.FirstOrDefault(d => d.Name == name);
        }
    }
}

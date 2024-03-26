using HR_Project.Models;

namespace HR_Project.Repositories
{
    public interface IDepartment
    {
        List<Department> GetAll();
        Department GetById(int id);
        Department GetByName(string name);
    }
}

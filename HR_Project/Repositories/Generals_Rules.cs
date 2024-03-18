using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class Generals_Rules:IGeneral_Rules
    {
        private HRContext context;

        public Generals_Rules(HRContext context)
        {
            this.context = context;
        }
    }
}

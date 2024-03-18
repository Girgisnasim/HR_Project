using HR_Project.Models;

namespace HR_Project.Repositories
{
    public class General_Rules:IGeneral_Rules
    {
        private HRContext context;

        public General_Rules(HRContext context)
        {
            this.context = context;
        }
    }
}

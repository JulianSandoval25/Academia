using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        Data.Database.PlanAdapter PlanData;
        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();

        }
        public List<Plan> GetAll()
        {
            List<Plan> planes = PlanData.GetAll();
            return planes;
        }


        public Plan GetOne(int id)
        {
            Plan user = PlanData.GetOne(id);
            return user;
        }

        public void Delete(int id)
        {
            PlanData.Delete(id);
        }


        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
    }
}

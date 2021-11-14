using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        Data.Database.ComisionAdapter ComisionData;
        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();

        }
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = ComisionData.GetAll();
            return comisiones;
        }
        
       public List<Comision> GetAllxID(int ID)
        {
            List<Comision> comisiones = ComisionData.GetAllxID(ID);
            return comisiones;
        }

        public Comision GetOne(int id)
        {
            Comision user = ComisionData.GetOne(id);
            return user;
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }


        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }
    }
}

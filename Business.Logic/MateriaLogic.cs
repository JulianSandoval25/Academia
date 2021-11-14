using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic: BusinessLogic
    {
        Data.Database.MateriaAdapter MateriaData;
        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();

        }
        public List<Materia> GetAll()
        {
            List<Materia> materias = MateriaData.GetAll();
            return materias;
        }
        public List<Materia> GetAllxID(int ID)
        {
            List<Materia> materias = MateriaData.GetAllxID(ID);
            return materias;
        }

        public Materia GetOne(int id)
        {
            Materia materia = MateriaData.GetOne(id);
            return materia;
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }


        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }

        public List<Materia> TraerTodosPorIdPlan(int ID)
        {
            return MateriaData.TraerTodosPorIdPlan(ID);
        }
    }
}

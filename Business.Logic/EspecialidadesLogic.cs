using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadesLogic : BusinessLogic
    {
        Data.Database.EspecialidadesAdapter EspecialidadData;
        public EspecialidadesLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadesAdapter();

        }
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = EspecialidadData.GetAll();
            return especialidades;
        }


        public Especialidad GetOne(int id)
        {
            Especialidad especialidad = EspecialidadData.GetOne(id);
            return especialidad;
        }

        public void Delete(int id)
        {
            EspecialidadData.Delete(id);
        }


        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
        }
    }
}

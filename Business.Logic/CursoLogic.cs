using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic: BusinessLogic
    {
        Data.Database.CursoAdapter CursoData;
        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();

        }
        public List<Curso> GetAll()
        {
            List<Curso> cursos = CursoData.GetAll();
            return cursos;
        }


        public Curso GetOne(int id)
        {
            Curso curso = CursoData.GetOne(id);
            return curso;
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }


        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }

        public List<Curso> GetAllxPlan(int id_plan, int id)
        {
            return CursoData.GetAllxPlan(id_plan, id);
        }
    }
}


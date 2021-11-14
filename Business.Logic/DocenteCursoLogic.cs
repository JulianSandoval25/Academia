using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        public List<DocenteCurso> TraerTodosxIdDoc(int doc)
        {
            DocenteCursoAdapter docentescursos = new DocenteCursoAdapter();
            return docentescursos.TraerTodosxIdDoc(doc);
        }
    }
}

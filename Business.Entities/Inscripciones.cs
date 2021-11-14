using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Inscripciones : BusinessEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Materia { get; set; }

        public string Condicion { get; set; }
        public int Nota { get; set; }
        public int IDCurso { get; set; }
    }
}

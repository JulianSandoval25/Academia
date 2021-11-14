using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class InscripcionLogic
    {
        AlumnoInscripcionAdapter _DatosInscripcion;
        public AlumnoInscripcionAdapter DatosInscripcion
        {
            get
            {
                return _DatosInscripcion;
            }
            set
            {
                _DatosInscripcion = value;
            }
        }

        public InscripcionLogic()
        {
            _DatosInscripcion = new AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAllxIdPersona(int IdPersona)
        {
            return DatosInscripcion.GetAllxIdPersona(IdPersona);
        }

        public void Inscribir(AlumnoInscripcion alum)
        {
            DatosInscripcion.Inscribir(alum);
        }
        public List<AlumnoInscripcion> GetAllxIdCurso(int idCurso)
        {
            AlumnoInscripcionAdapter aia = new AlumnoInscripcionAdapter();
            return aia.GetAllxIdCurso(idCurso);
        }

        public void Update(Inscripciones ins)
        {
            _DatosInscripcion.Update(ins);
        }

        public Inscripciones ConseguirInscripcionXid(int id)
        {
            return DatosInscripcion.ConseguirInscripcionXid(id);
        }
    }

    
}

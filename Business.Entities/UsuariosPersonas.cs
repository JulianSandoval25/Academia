using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class UsuariosPersonas : BusinessEntity
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }
        public int IDPersona;
        

        public string Direccion { get; set; }
        

        

        public DateTime FechaNacimiento { get; set; }


        public int _IDPlan { get; set; }


        public int Legajo { get; set; }


        public string _Telefono { get; set; }

        // Definir un tipo para TipoPersona "TiposPersonas" enumerado
        //public string TipoPersona;
        private Tipo _TipoPersona;
        public Tipo TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        public enum Tipo
        {
            Alumno,
            Profesor,
            Administrativo
        }


    }
}

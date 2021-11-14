using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        public string _NombreUsuario;
        public string _Clave;
        public string _Nombre;
        public string _Apellido;

        public string _Email;
        public bool _Habilitado;
        public int _IDPersona;
        public string _Privilegio;

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

       
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

       
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

       
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        public int IDPersona 
        { 
            get { return _IDPersona; } 
            set { _IDPersona = value; } 
        }


        public string Privilegio { get { return _Privilegio; } set { _Privilegio = value; } }

    }
}

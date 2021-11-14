using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Business.Logic
{
    public class Validaciones
    {
        public static bool esMailValido(string correoIngresado)
        {
            string expresionCorrecta = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(correoIngresado, expresionCorrecta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool esCampoValido(string cadena)
        {
            if (String.IsNullOrEmpty(cadena))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool esPrivilegioValido(string PrivilegioIngresado)
        {
            if (PrivilegioIngresado == "Administrador" || PrivilegioIngresado == "Alumno" || PrivilegioIngresado == "Profesor")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CuposValidos(int id)
        {
            CursoLogic cl = new CursoLogic();
            if (cl.GetOne(id).Cupo==0)
            {
                throw new ArgumentNullException();
            }
            return true;
        }
    }
}

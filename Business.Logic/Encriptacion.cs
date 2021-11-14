using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class Encriptacion
    {
        public static string encriptar(string cadena)
        {
            return Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(cadena));
        }

        public static string desencritar(string cadena)
        {
            return System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(cadena));
        }
    }
}

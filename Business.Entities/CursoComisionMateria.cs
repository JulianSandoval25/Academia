using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class CursoComisionMateria : BusinessEntity
    {
        private int _AnioCalendario;
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        private int _Cupo;
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        /*
        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        */

        private int _IDComision;
        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }

        private int _IDMateria;
        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

        public string DescripcionMateria { get; set; }
        

        private int _HSSemanales;
        public int HSSemanales
        {
            get { return _HSSemanales; }
            set { _HSSemanales = value; }
        }

        private int _HSTotales;
        public int HSTotales
        {
            get { return _HSTotales; }
            set { _HSTotales = value; }
        }

        private int _IDPlan;
        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }

        private int _AnioEspecialidad;
        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }
        
        public string DescripcionComisiones { get; set; }
      
        
    }
}

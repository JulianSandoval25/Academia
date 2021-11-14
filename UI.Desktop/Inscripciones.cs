using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Inscripciones : ApplicationForm
    {
        public Usuario usuarioActual { get; set; }
        public Inscripciones()
        {
            InitializeComponent();
        }

        public Inscripciones(Usuario usu  )
        {

            InitializeComponent();
            dgvInscripciones.AutoGenerateColumns = false;
            usuarioActual = usu;
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            MateriaLogic lm = new MateriaLogic();
            ComisionLogic lc = new ComisionLogic();
            CursoLogic lcu = new CursoLogic();
            InscripcionLogic li = new InscripcionLogic();
            List<AlumnoInscripcion> ais = new List<AlumnoInscripcion>();
            ais = li.GetAllxIdPersona(this.usuarioActual.IDPersona);
            List<InscripcionesEditado> ins = new List<InscripcionesEditado>();
            foreach (AlumnoInscripcion ai in ais)
            {
                InscripcionesEditado i = new InscripcionesEditado();
                i.ID = ai.ID;
                i.Materia = lm.GetOne(lcu.GetOne(ai.IDCurso).IDMateria).Descripcion;
                i.Comision = lc.GetOne(lcu.GetOne(ai.IDCurso).IDComision).Descripcion;
                i.Nota = ai.Nota;
                i.Condicion = ai.Condicion;
                ins.Add(i);
            }
            dgvInscripciones.DataSource = ins;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            InscripcionesDesktop insD = new InscripcionesDesktop( usuarioActual, ModoForm.Alta);
            insD.Show();
            Listar();
        }
    }
}

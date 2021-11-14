using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class InscripcionesDesktop : ApplicationForm
    {
        public InscripcionesDesktop()
        {
            InitializeComponent();
        }
        public Usuario UsuarioActual { get; set; }
        public AlumnoInscripcion inscripcionActual { get; set; }
        public Persona personaActual { get; set; }

        //altas
        public InscripcionesDesktop(Usuario usuario, ModoForm modo)
        {
            InitializeComponent();
            UsuarioActual= usuario;
            PersonaLogic p = new PersonaLogic();
            personaActual = p.GetOne(usuario.IDPersona);
            dgvInscripciones.AutoGenerateColumns = false;

            
        }

        private void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            /*
            List<Materia> materias = new List<Materia>();
            materias = ml.TraerTodosPorIdPlan(personaActual.IDPlan);
            */
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();
            List<CursoComisionMateria> inscripciones = new List<CursoComisionMateria>();
            foreach (Curso c in cl.GetAllxPlan(personaActual.IDPlan, personaActual.ID))
            {
                CursoComisionMateria curso = new CursoComisionMateria();
                curso.ID = c.ID;
                //curso.IDComision = c.IDComision;
                curso.DescripcionComisiones = col.GetOne(c.IDComision).Descripcion;
                curso.DescripcionMateria = ml.GetOne(c.IDMateria).Descripcion;
                curso.AnioCalendario = c.AnioCalendario;
                curso.Cupo = c.Cupo;
                inscripciones.Add(curso);
            }
            dgvInscripciones.DataSource = inscripciones;

        }

        private void InscripcionesDesktop_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnInscripbir_Click(object sender, EventArgs e)
        {
            try
            {

                Validaciones.CuposValidos(((CursoComisionMateria)dgvInscripciones.CurrentRow.DataBoundItem).ID);
                
                int id = ((CursoComisionMateria)dgvInscripciones.CurrentRow.DataBoundItem).ID;
                AlumnoInscripcion alum = new AlumnoInscripcion();
                alum.IDCurso = id;
                alum.IDAlumno = personaActual.ID;
                alum.Condicion = "Cursando";
                InscripcionLogic il = new InscripcionLogic();
                il.Inscribir(alum);
                Listar();
                Notificar("Ok", "Inscripcion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
               

            }
            catch (Exception)
            {

                Notificar("Error", "Curso sin cupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

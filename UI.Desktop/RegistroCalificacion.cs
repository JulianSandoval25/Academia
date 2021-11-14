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
    public partial class RegistroCalificacion : ApplicationForm
    {
        public RegistroCalificacion()
        {
            InitializeComponent();
        }

        public RegistroCalificacion(Usuario usuario)
        {
            InitializeComponent();
            dgvCalificaiones.AutoGenerateColumns = false;
            usuarioActual = usuario;
        }
        public Usuario usuarioActual { get; set; }
        public CursoLogic cursoData { get; set; }
        public DocenteCursoLogic docentecursoData { get; set; }
        

        public void Listar()
        {
            List<Business.Entities.Inscripciones> alumnos = new List<Business.Entities.Inscripciones>();
            InscripcionLogic il = new InscripcionLogic();
            PersonaLogic perData = new PersonaLogic();
            if (cbCursos.SelectedValue!= null) {
                foreach (AlumnoInscripcion ai in il.GetAllxIdCurso(int.Parse(cbCursos.SelectedValue.ToString())))
                {
                    Business.Entities.Inscripciones alumno = new Business.Entities.Inscripciones();
                    alumno.ID = ai.ID;
                    alumno.Nombre = perData.GetOne(ai.IDAlumno).Nombre;
                    alumno.Apellido = perData.GetOne(ai.IDAlumno).Apellido;
                    alumno.Condicion = ai.Condicion;
                    alumno.Nota = ai.Nota;
                    alumno.IDCurso = ai.IDCurso;
                    alumnos.Add(alumno);
                }
            }
            else
            {
                //MessageBox.Show("sin alumnos");
            }
            dgvCalificaiones.DataSource = alumnos;

        }

        private void RegistroCalificacion_Load(object sender, EventArgs e)
        {
            docentecursoData = new DocenteCursoLogic();
            List<DocenteCurso> cursos = new List<DocenteCurso>();
            cursos= docentecursoData.TraerTodosxIdDoc(usuarioActual.IDPersona);
            cbCursos.DataSource = cursos;
            cbCursos.DisplayMember = "IDCurso";
            cbCursos.ValueMember = "IDCurso";
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

        private void btnRegistrarNota_Click(object sender, EventArgs e)
        {
            if (dgvCalificaiones.CurrentRow!=null) {
                Business.Entities.Inscripciones ins = ((Business.Entities.Inscripciones)dgvCalificaiones.CurrentRow.DataBoundItem);

                RegistrarCalificacionDesktop formUsuario = new RegistrarCalificacionDesktop(ins);
                formUsuario.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("sin alumnos");
            }
        }
    }
}

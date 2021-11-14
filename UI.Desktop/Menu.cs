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
    public partial class Menu : Form
    {
        public Usuario usuarioActual { get; set; }
        public Menu(Usuario usu)
        {
            InitializeComponent();
            usuarioActual= usu;
            PersonaLogic lp = new PersonaLogic();
            personaActual = lp.GetOne(usu.IDPersona);
            //MessageBox.Show("Bienvenido " + usuarioActual.Nombre + " " + usuarioActual.Apellido, "UTN FRRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            label1.Text = "Bienvenido " + usuarioActual.Nombre + " " + usuarioActual.Apellido + " UTN FRRO";
            
            //MessageBox.Show(personaActual.TipoPersona.ToString());
            label2.Text ="Rol: " + personaActual.TipoPersona.ToString();
            switch (personaActual.TipoPersona)
            {
                case Persona.Tipo.Administrativo:
                    alumnoToolStripMenuItem.Visible = false;
                    docenteToolStripMenuItem.Visible = false;
                    break;
                case Persona.Tipo.Alumno:
                    actividadesToolStripMenuItem.Visible = false;
                    docenteToolStripMenuItem.Visible = false;
                    aBMEspecialidadesToolStripMenuItem.Enabled = false;
                    aBMPlanes.Enabled = false;
                    aBMUsuariosToolStripMenuItem.Enabled = false;
                    aBMComisionesToolStripMenuItem.Enabled = false;
                    break;
                case Persona.Tipo.Profesor:
                    aBMEspecialidadesToolStripMenuItem.Enabled = false;
                    actividadesToolStripMenuItem.Visible = false;
                    alumnoToolStripMenuItem.Visible = false;
                    aBMPlanes.Enabled = false;
                    aBMUsuariosToolStripMenuItem.Enabled = false;
                    aBMComisionesToolStripMenuItem.Enabled = false;
                    break;
            }
        }
        

        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        Persona personaActual;
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void aBMUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios formUsuario = new Usuarios();
            formUsuario.ShowDialog();
        }


        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aBMEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidad = new Especialidades();
            formEspecialidad.ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes formPlan = new Planes();
            formPlan.ShowDialog();
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias formMateria = new Materias();
            formMateria.ShowDialog();
        }

        private void aBMComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones formComision = new Comisiones();
            formComision.ShowDialog();
        }

        

        private void inscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inscripciones formInscripcion = new Inscripciones(usuarioActual);
            formInscripcion.ShowDialog();
        }

        private void aBMCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos formCurso = new Cursos();
            formCurso.ShowDialog();
        }

        private void calificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroCalificacion rc = new RegistroCalificacion(usuarioActual);
            rc.ShowDialog();
        }

        private void reporteCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formReporteCursos frc = new formReporteCursos();
            frc.ShowDialog();
        }

        private void reportePlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formReportePlanes frp = new formReportePlanes();
            frp.ShowDialog();
        }
    }
}

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
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
            cargarCbPlanes();
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic col = new ComisionLogic();
            List<CursoComisionMateria> cursos = new List<CursoComisionMateria>();
            foreach (Curso c in cl.GetAll())
            {
                CursoComisionMateria ccm = new CursoComisionMateria();
                ccm.ID = c.ID;
                ccm.AnioCalendario = c.AnioCalendario;
                ccm.DescripcionMateria = ml.GetOne(c.IDMateria).Descripcion;
                ccm.DescripcionComisiones = col.GetOne(c.IDComision).Descripcion;
                ccm.Cupo = c.Cupo;
                cursos.Add(ccm);

            }
            this.dgvCursos.DataSource = cursos;
            //this.dgvCursos.DataSource = cl.GetAll();
        }

        private void Curso_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formCursos = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCursos.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((CursoComisionMateria)dgvCursos.CurrentRow.DataBoundItem).ID;

            CursoDesktop formCursos = new CursoDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formCursos.ShowDialog();
            this.Listar();

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((CursoComisionMateria)dgvCursos.CurrentRow.DataBoundItem).ID;

            CursoDesktop formCursos = new CursoDesktop(id, ApplicationForm.ModoForm.Baja);
            formCursos.ShowDialog();
            this.Listar();
        }
  
        public void cargarCbPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            cbPlanes.DataSource = planes;
            cbPlanes.DisplayMember = "Descripcion";
            cbPlanes.ValueMember = "ID";
        }

  
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formCursos = new CursoDesktop(ApplicationForm.ModoForm.Alta, int.Parse(cbPlanes.SelectedValue.ToString()));
            formCursos.ShowDialog();
            this.Listar();
        }
    }
}

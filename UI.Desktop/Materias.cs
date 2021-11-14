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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            PlanLogic pl = new PlanLogic();
            List<MateriaPlan> matplan = new List<MateriaPlan>();
            foreach (Materia m in ml.GetAll())
            {
                MateriaPlan mat = new MateriaPlan();
                mat.ID = m.ID;
                mat.Descripcion = m.Descripcion;
                mat.HSSemanales = m.HSSemanales;
                mat.HSTotales = m.HSTotales;
                mat.DescripcionPlan = pl.GetOne(m.IDPlan).Descripcion;
                matplan.Add(mat);
            }
            this.dgvMaterias.DataSource = matplan;
            //this.dgvMaterias.DataSource = ml.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
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
            MateriasDesktop formUsuario = new MateriasDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((MateriaPlan)dgvMaterias.CurrentRow.DataBoundItem).ID;

            MateriasDesktop formUsuario = new MateriasDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((MateriaPlan)dgvMaterias.CurrentRow.DataBoundItem).ID;

            MateriasDesktop formUsuario = new MateriasDesktop(id, ApplicationForm.ModoForm.Baja);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Planes p = new Planes();
            p.ShowDialog();
            Listar();
        }
    }
}

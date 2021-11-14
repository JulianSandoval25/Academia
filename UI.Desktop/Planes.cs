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
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            EspecialidadesLogic el = new EspecialidadesLogic();
            List<PlanEspecialidad> planes = new List<PlanEspecialidad>();
            foreach (Plan p in pl.GetAll())
            {
                PlanEspecialidad plan = new PlanEspecialidad();
                plan.ID = p.ID;
                plan.Descripcion = p.Descripcion;
                plan.DescripcionEspecialidad = el.GetOne(p.IDEspecialidad).Descripcion;
                planes.Add(plan);
            }
            this.dgvPlanes.DataSource = planes;
            //this.dgvPlanes.DataSource = pl.GetAll();

        }

        private void Planes_Load(object sender, EventArgs e)
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
            PlanesDesktop formPlanes = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            formPlanes.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((PlanEspecialidad)dgvPlanes.CurrentRow.DataBoundItem).ID;

            PlanesDesktop formPlanes = new PlanesDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formPlanes.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((PlanEspecialidad)dgvPlanes.CurrentRow.DataBoundItem).ID;

            PlanesDesktop formPlanes = new PlanesDesktop(id, ApplicationForm.ModoForm.Baja);
            formPlanes.ShowDialog();
            this.Listar();
        }
    }
}

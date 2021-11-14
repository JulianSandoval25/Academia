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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            PlanLogic pl = new PlanLogic();
            List<ComisionPlan> comisiones = new List<ComisionPlan>();
            foreach (Comision c in cl.GetAll())
            {
                ComisionPlan comision = new ComisionPlan();
                comision.ID = c.ID;
                comision.Descripcion = c.Descripcion;
                comision.AnioEspecialidad = c.AnioEspecialidad;
                comision.DescripcionPlan = pl.GetOne(c.IDPlan).Descripcion;
                comisiones.Add(comision);
            }
            this.dgvComisiones.DataSource = comisiones;
            //this.dgvComisiones.DataSource = cl.GetAll();
        }

        private void Comisiones_Load(object sender, EventArgs e)
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
            ComisionesDesktop formComision = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((ComisionPlan)dgvComisiones.CurrentRow.DataBoundItem).ID;

            ComisionesDesktop formComision = new ComisionesDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((ComisionPlan)dgvComisiones.CurrentRow.DataBoundItem).ID;

            ComisionesDesktop formComision = new ComisionesDesktop(id, ApplicationForm.ModoForm.Baja);
            formComision.ShowDialog();
            this.Listar();
        }
    }
}

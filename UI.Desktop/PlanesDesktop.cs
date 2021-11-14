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
    public partial class PlanesDesktop : ApplicationForm
    {
        public PlanesDesktop()
        {
            InitializeComponent();
        }
        public PlanesDesktop(ModoForm modo) : this()
        {
            llenarCbEspecialidades();
            this.modo = modo;
            PlanLogic plan = new PlanLogic();

        }
        public PlanesDesktop(int ID, ModoForm modo) : this()
        {
            llenarCbEspecialidades();
            this.modo = modo;
            PlanLogic plan = new PlanLogic();

            planActual = plan.GetOne(ID);
            this.MapearDeDatos();
            if (modo == ModoForm.Baja)
            {
                txtDesc.Enabled = false;
                cbIDEspecialidades.Enabled = false;
            }
        }
        public Plan planActual { get; set; }

        public override void MapearDeDatos()
        {
            txtID.Text = this.planActual.ID.ToString();
            txtDesc.Text = this.planActual.Descripcion;
            //cbIDEspecialidades.DisplayMember = this.planActual.IDEspecialidad.ToString();
            cbIDEspecialidades.SelectedValue = this.planActual.IDEspecialidad;




            switch (this.modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;

            }


        }
        public override void MapearADatos()
        {
            switch (modo)
            {
                case ModoForm.Alta:
                    {
                        Plan plan = new Plan();
                        planActual = plan;


                        planActual.Descripcion = this.txtDesc.Text;
                        planActual.IDEspecialidad = int.Parse(this.cbIDEspecialidades.SelectedValue.ToString());
                        planActual.State = BusinessEntity.States.New;
                        btnAceptar.Text = "Guardar";

                    }
                    break;
                case ModoForm.Modificacion:
                    {
                        Plan plan = new Plan();
                        planActual = plan;
                        planActual.ID = int.Parse(txtID.Text);
                        planActual.Descripcion = this.txtDesc.Text;
                        planActual.IDEspecialidad = int.Parse(this.cbIDEspecialidades.SelectedValue.ToString());

                        planActual.State = BusinessEntity.States.Modified;
                        btnAceptar.Text = "Alta";

                    }
                    break;
                case ModoForm.Baja:
                    {
                        Plan plan = new Plan();
                        planActual = plan;

                        planActual.ID = int.Parse(txtID.Text);
                        planActual.Descripcion = this.txtDesc.Text;
                        planActual.IDEspecialidad = int.Parse(this.cbIDEspecialidades.SelectedValue.ToString());

                        planActual.State = BusinessEntity.States.Deleted;
                        btnAceptar.Text = "Eliminar";

                    }
                    break;

            }
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanLogic planLog = new PlanLogic();
            planLog.Save(planActual);

        }
        public override bool Validar()
        {


            if (string.IsNullOrEmpty(txtDesc.Text))
            {

                this.Notificar("Error", "Descripcion incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void PlanesDesktop_Load(object sender, EventArgs e)
        {
            /*
            EspecialidadesLogic el = new EspecialidadesLogic();
            List<Especialidad> especialidades = el.GetAll();

            especialidades = el.GetAll();

            //cbIDEspecialidades.DataSource = especialidades;
            cbIDEspecialidades.DisplayMember = "Descripcion";
            cbIDEspecialidades.ValueMember = "ID";
            cbIDEspecialidades.DataSource = especialidades;
            */

        }


        public void llenarCbEspecialidades()
            {
            EspecialidadesLogic el = new EspecialidadesLogic();
            List<Especialidad> especialidades = el.GetAll();

            especialidades = el.GetAll();


            cbIDEspecialidades.DisplayMember = "Descripcion";
            cbIDEspecialidades.ValueMember = "ID";
            cbIDEspecialidades.DataSource = especialidades;
        }
       

    }
}

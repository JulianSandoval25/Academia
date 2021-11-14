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
    public partial class ComisionesDesktop : ApplicationForm
    {
        public ComisionesDesktop()
        {
            InitializeComponent();
        }
        public ComisionesDesktop(ModoForm modo) : this()
        {
            llenarCbPlanes();
            this.modo = modo;
            ComisionLogic comision = new ComisionLogic();

        }
        public ComisionesDesktop(int ID, ModoForm modo) : this()
        {
            llenarCbPlanes();
            this.modo = modo;
            ComisionLogic comision = new ComisionLogic();

            comisionActual = comision.GetOne(ID);
            this.MapearDeDatos();
            if (modo == ModoForm.Baja)
            {
                txtAnioEsp.ReadOnly = true;
                txtDesc.ReadOnly = true;
                cbIDPlan.Enabled = false;
            }
        }
        public Comision comisionActual { get; set; }

        public override void MapearDeDatos()
        {
            txtID.Text = this.comisionActual.ID.ToString();
            txtDesc.Text = this.comisionActual.Descripcion;
            txtAnioEsp.Text = this.comisionActual.AnioEspecialidad.ToString();
            cbIDPlan.SelectedValue = this.comisionActual.IDPlan;

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
                        Comision comision = new Comision();
                        comisionActual = comision;


                        comisionActual.Descripcion = this.txtDesc.Text;
                        comisionActual.AnioEspecialidad = int.Parse(this.txtAnioEsp.Text);
                        comisionActual.IDPlan = int.Parse(this.cbIDPlan.SelectedValue.ToString());
                        comisionActual.State = BusinessEntity.States.New;
                        btnAceptar.Text = "Guardar";

                    }
                    break;
                case ModoForm.Modificacion:
                    {
                        Comision comision = new Comision();
                        comisionActual = comision;
                        comisionActual.ID = int.Parse(txtID.Text);
                        comisionActual.Descripcion = this.txtDesc.Text;
                        comisionActual.AnioEspecialidad = int.Parse(this.txtAnioEsp.Text);
                        comisionActual.IDPlan = int.Parse(this.cbIDPlan.SelectedValue.ToString());

                        comisionActual.State = BusinessEntity.States.Modified;
                        btnAceptar.Text = "Alta";

                    }
                    break;
                case ModoForm.Baja:
                    {
                        Comision comision = new Comision();
                        comisionActual = comision;

                        comisionActual.ID = int.Parse(txtID.Text);
                        comisionActual.Descripcion = this.txtDesc.Text;
                        comisionActual.AnioEspecialidad = int.Parse(this.txtAnioEsp.Text);
                        comisionActual.IDPlan = int.Parse(this.cbIDPlan.SelectedValue.ToString());

                        comisionActual.State = BusinessEntity.States.Deleted;
                        btnAceptar.Text = "Eliminar";

                    }
                    break;

            }
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic comisionLog = new ComisionLogic();
            comisionLog.Save(comisionActual);

        }
        public override bool Validar()
        {


            if (Validaciones.esCampoValido(txtDesc.Text))
            {
                if (Validaciones.esCampoValido(txtAnioEsp.Text))
                {
                    return true;
                }
                else
                {
                    Notificar("Error", "anio invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                Notificar("Error", "Descripcion invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

        private void ComisionesDesktop_Load(object sender, EventArgs e)
        {
            /*
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            cbIDPlan.DataSource = planes;
            cbIDPlan.DisplayMember = "Descripcion";
            cbIDPlan.ValueMember = "ID";
            */

        }

        public void llenarCbPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            cbIDPlan.DataSource = planes;
            cbIDPlan.DisplayMember = "Descripcion";
            cbIDPlan.ValueMember = "ID";
        }


    }
}

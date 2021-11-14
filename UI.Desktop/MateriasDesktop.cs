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
    public partial class MateriasDesktop : ApplicationForm
    {
        public MateriasDesktop()
        {
            InitializeComponent();
        }

        public MateriasDesktop(ModoForm modo) : this()
        {
            llenarCbPlanes();
            this.modo = modo;
            MateriaLogic materia = new MateriaLogic();

        }
        public MateriasDesktop(int ID, ModoForm modo) : this()
        {
            llenarCbPlanes();
            this.modo = modo;
            MateriaLogic materia = new MateriaLogic();

            materiaActual = materia.GetOne(ID);
            this.MapearDeDatos();
            if (modo == ModoForm.Baja)
            {
                txtDesc.ReadOnly = true;
                txtHSS.ReadOnly = true;
                txtHST.ReadOnly = true;
                cbPlanes.Enabled = false;

            }
        }
        public Materia materiaActual { get; set; }

        public override void MapearDeDatos()
        {
            txtID.Text = this.materiaActual.ID.ToString();
            txtDesc.Text = this.materiaActual.Descripcion;
            txtHSS.Text = this.materiaActual.HSSemanales.ToString();
            txtHST.Text = this.materiaActual.HSTotales.ToString();
            //cbPlanes.DisplayMember = this.materiaActual.IDPlan.ToString();
            cbPlanes.SelectedValue = materiaActual.IDPlan;

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
                        Materia mate = new Materia();
                        materiaActual = mate;


                        materiaActual.Descripcion = this.txtDesc.Text;
                        materiaActual.HSSemanales = int.Parse(this.txtHSS.Text);
                        materiaActual.HSTotales = int.Parse(this.txtHST.Text);
                        materiaActual.IDPlan = int.Parse(this.cbPlanes.SelectedValue.ToString());
                        materiaActual.State = BusinessEntity.States.New;
                        btnAceptar.Text = "Guardar";

                    }
                    break;
                case ModoForm.Modificacion:
                    {
                        Materia mate = new Materia();
                        materiaActual = mate;
                        materiaActual.ID = int.Parse(txtID.Text);
                        materiaActual.Descripcion = this.txtDesc.Text;
                        materiaActual.HSSemanales = int.Parse(this.txtHSS.Text);
                        materiaActual.HSTotales = int.Parse(this.txtHST.Text);
                        materiaActual.IDPlan = int.Parse(this.cbPlanes.SelectedValue.ToString());

                        materiaActual.State = BusinessEntity.States.Modified;
                        btnAceptar.Text = "Alta";

                    }
                    break;
                case ModoForm.Baja:
                    {
                        Materia mate = new Materia();
                        materiaActual = mate;

                        materiaActual.ID = int.Parse(txtID.Text);
                        materiaActual.Descripcion = this.txtDesc.Text;
                        materiaActual.HSSemanales = int.Parse(this.txtHSS.Text);
                        materiaActual.HSTotales = int.Parse(this.txtHST.Text);
                        materiaActual.IDPlan = int.Parse(this.cbPlanes.SelectedValue.ToString());

                        materiaActual.State = BusinessEntity.States.Deleted;
                        btnAceptar.Text = "Eliminar";

                    }
                    break;

            }
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            MateriaLogic mateLog = new MateriaLogic();
            mateLog.Save(materiaActual);

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

        private void MateriasDesktop_Load(object sender, EventArgs e)
        {
            /*
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            cbPlanes.DataSource = planes;
            cbPlanes.DisplayMember = "Descripcion";
            cbPlanes.ValueMember = "ID";
            */
        }

        public void llenarCbPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            cbPlanes.DataSource = planes;
            cbPlanes.DisplayMember = "Descripcion";
            cbPlanes.ValueMember = "ID";
        }
    }
}

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
    public partial class EspecialidadesDesktop : ApplicationForm
    {
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }
        public Especialidad especialidadActual { get; set; }

        public override void MapearDeDatos()
        {
            txtID.Text = this.especialidadActual.ID.ToString();
            txtDescripcion.Text = this.especialidadActual.Descripcion;
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
            switch (this.modo)
            {
                case ModoForm.Alta:
                    {
                        Especialidad esp = new Especialidad();
                        especialidadActual = esp;
                        especialidadActual.Descripcion = txtDescripcion.Text;
                        especialidadActual.State= BusinessEntity.States.New;
                        btnAceptar.Text = "Guardar";
                    }
                    break;
                case ModoForm.Baja:
                    {
                        Especialidad esp = new Especialidad();
                        especialidadActual = esp;
                        especialidadActual.ID = int.Parse(txtID.Text);
                        especialidadActual.Descripcion = txtDescripcion.Text;
                        especialidadActual.State = BusinessEntity.States.Deleted;
                        btnAceptar.Text = "Eliminar";
                    }
                    break;
                case ModoForm.Modificacion:
                    {
                        Especialidad esp = new Especialidad();
                        especialidadActual = esp;
                        especialidadActual.ID = int.Parse(txtID.Text);
                        especialidadActual.Descripcion = txtDescripcion.Text;
                        especialidadActual.State = BusinessEntity.States.Modified;
                        btnAceptar.Text = "Guardar";
                    }
                    break;
                

            }
        }


        public EspecialidadesDesktop(ModoForm modo) : this() 
        {
            this.modo = modo;
            EspecialidadesLogic espLog = new EspecialidadesLogic();
        }

        public EspecialidadesDesktop(int ID, ModoForm modo) : this() 
        {
            this.modo = modo;
            EspecialidadesLogic espLog = new EspecialidadesLogic();
            especialidadActual = espLog.GetOne(ID);
            this.MapearDeDatos();
            txtID.ReadOnly = true;
            if(this.modo == ModoForm.Baja)
            {
                this.txtDescripcion.ReadOnly = true;
                
            }

        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {

                this.Notificar("Error", "Descripcion incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadesLogic especLog = new EspecialidadesLogic();
            especLog.Save(especialidadActual);

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
    }
}

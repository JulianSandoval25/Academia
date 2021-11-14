using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        // formulario para altas
        public UsuarioDesktop(ModoForm modo) : this()
        {
            llegarCB();
            this.modo = modo;
            //UsuarioLogic usu = new UsuarioLogic();
        }
        //formulario para edicion y bajas
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            llegarCB();
            this.modo = modo;
            UsuarioLogic usu = new UsuarioLogic();
            PersonaLogic per = new PersonaLogic();

            UsuarioActual = usu.GetOne(ID);
            PersonaActual = per.GetOne(UsuarioActual.IDPersona);
            this.MapearDeDatos();
            txtID.ReadOnly = true;
            if (modo == ModoForm.Baja)
            {
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtClave.ReadOnly = true;
                this.txtConfirmarClave.ReadOnly = true;
                this.txtID.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;
                this.chkHabilitado.Enabled = false;
                //this.txtTipoPersona.ReadOnly = true;
                this.txtLegajo.ReadOnly = true;
                this.dtpFechaNac.Enabled = false;
                this.cbPlanes.Enabled = false;
                this.cbTipo.Enabled = false;
            }
        }
        public Usuario UsuarioActual { get; set; }
        public Persona PersonaActual { get; set; }

        public override void MapearDeDatos()
        {
            txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            txtApellido.Text = this.UsuarioActual.Apellido;
            txtEmail.Text = this.UsuarioActual.Email;
            txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            txtClave.Text = Encriptacion.desencritar(this.UsuarioActual.Clave);
            txtConfirmarClave.Text = Encriptacion.desencritar(this.UsuarioActual.Clave);
            switch (PersonaActual.TipoPersona)
            {
                case Persona.Tipo.Alumno:
                    //txtTipoPersona.Text = "Alumno";
                    cbTipo.SelectedIndex = 1;
                    break;
                case Persona.Tipo.Profesor:
                    //txtTipoPersona.Text = "Profesor";
                    cbTipo.SelectedIndex = 2;
                    break;
                case Persona.Tipo.Administrativo:
                    //txtTipoPersona.Text = "Administrador";
                    cbTipo.SelectedIndex = 0;
                    break;
            }
            llegarCB();
            cbPlanes.SelectedValue = PersonaActual.IDPlan;
            txtLegajo.Text = PersonaActual.Legajo.ToString();
            dtpFechaNac.Value = PersonaActual.FechaNacimiento;


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
                        Usuario usu = new Usuario();
                        UsuarioActual = usu;
                        Persona per = new Persona();
                        PersonaActual = per;


                        UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                        UsuarioActual.Nombre = this.txtNombre.Text;
                        UsuarioActual.Apellido = txtApellido.Text;
                        UsuarioActual.Email = txtEmail.Text;
                        UsuarioActual.NombreUsuario = txtUsuario.Text;
                        UsuarioActual.Clave = Encriptacion.encriptar(txtClave.Text);
                        UsuarioActual.State = BusinessEntity.States.New;
                        /*
                        switch (txtTipoPersona.Text)
                        {
                            case "Alumno":
                                PersonaActual.TipoPersona = Persona.Tipo.Alumno;
                                break;
                            case "Profesor":
                                PersonaActual.TipoPersona = Persona.Tipo.Profesor;
                                break;
                            case "Administrador":
                                PersonaActual.TipoPersona = Persona.Tipo.Administrativo;
                                break;

                        }
                        */
                        switch (cbTipo.SelectedIndex)
                        {
                            case 1:
                                PersonaActual.TipoPersona = Persona.Tipo.Alumno;
                                break;
                            case 2:
                                PersonaActual.TipoPersona = Persona.Tipo.Profesor;
                                break;
                            case 0:
                                PersonaActual.TipoPersona = Persona.Tipo.Administrativo;
                                break;

                        }
                        //base de datos no me admites valores nulos asi que tuve que hardcodearlos algunos
                        if (!(this.cbPlanes.SelectedValue == null))
                        {
                            PersonaActual.IDPlan = int.Parse(this.cbPlanes.SelectedValue.ToString());
                        }
                        //PersonaActual.IDPlan = int.Parse(this.cbPlanes.SelectedValue.ToString()); 
                        //PersonaActual.Telefono = "";
                        //PersonaActual.Direccion = "";
                        PersonaActual.Email = txtEmail.Text;
                        PersonaActual.Legajo = int.Parse(txtLegajo.Text);
                        PersonaActual.FechaNacimiento = dtpFechaNac.Value.Date;
                        PersonaActual.Nombre = this.txtNombre.Text;
                        PersonaActual.Apellido = txtApellido.Text;
                        PersonaActual.State = BusinessEntity.States.New;
                        btnAceptar.Text = "Guardar";




                    } break;
                case ModoForm.Modificacion:
                    {
                        /*
                        Usuario usu = new Usuario();
                        UsuarioActual = usu;
                        */
                        Persona per = new Persona();
                        PersonaActual = per;

                        UsuarioActual.ID = int.Parse(txtID.Text);
                        UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                        UsuarioActual.Nombre = this.txtNombre.Text;
                        UsuarioActual.Apellido = txtApellido.Text;
                        UsuarioActual.Email = txtEmail.Text;
                        UsuarioActual.NombreUsuario = txtUsuario.Text;
                        UsuarioActual.Clave = Encriptacion.encriptar(txtClave.Text);
                        UsuarioActual.State = BusinessEntity.States.Modified;
/*
                        switch (txtTipoPersona.Text)
                        {
                            case "Alumno":
                                PersonaActual.TipoPersona = Persona.Tipo.Alumno;
                                break;
                            case "Profesor":
                                PersonaActual.TipoPersona = Persona.Tipo.Profesor;
                                break;
                            case "Administrativo":
                                PersonaActual.TipoPersona = Persona.Tipo.Administrativo;
                                break;

                        }
*/
                        switch (cbTipo.SelectedIndex)
                        {
                            case 1:
                                PersonaActual.TipoPersona = Persona.Tipo.Alumno;
                                break;
                            case 2:
                                PersonaActual.TipoPersona = Persona.Tipo.Profesor;
                                break;
                            case 0:
                                PersonaActual.TipoPersona = Persona.Tipo.Administrativo;
                                break;

                        }
                        //base de datos no me admites valores nulos asi que tuve que hardcodearlos algunos
                        PersonaActual.ID = UsuarioActual.IDPersona;
                        if (!(this.cbPlanes.SelectedValue == null))
                        {
                            PersonaActual.IDPlan = int.Parse(this.cbPlanes.SelectedValue.ToString());
                        }
                        //PersonaActual.IDPlan = int.Parse(this.cbPlanes.SelectedValue.ToString()); ;
                        //PersonaActual.Telefono = "";
                        //PersonaActual.Direccion = "";
                        PersonaActual.Email = txtEmail.Text;
                        PersonaActual.Legajo = int.Parse(txtLegajo.Text);
                        PersonaActual.FechaNacimiento = dtpFechaNac.Value.Date;
                        PersonaActual.Nombre = this.txtNombre.Text;
                        PersonaActual.Apellido = txtApellido.Text;
                        PersonaActual.State = BusinessEntity.States.Modified;

                        btnAceptar.Text = "Alta";


                    }
                    break;
                case ModoForm.Baja:
                    {

                        /**
                        Usuario usu = new Usuario();
                        UsuarioActual = usu;
                        */
                        Persona per = new Persona();
                        PersonaActual = per;

                        UsuarioActual.ID = int.Parse(txtID.Text);
                        UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                        UsuarioActual.Nombre = this.txtNombre.Text;
                        UsuarioActual.Apellido = txtApellido.Text;
                        UsuarioActual.Email = txtEmail.Text;
                        UsuarioActual.NombreUsuario = txtUsuario.Text;
                        UsuarioActual.Clave = Encriptacion.encriptar(txtClave.Text);
                        UsuarioActual.State = BusinessEntity.States.Deleted;

                        PersonaActual.ID = UsuarioActual.IDPersona;
                        /*
                        PersonaActual.IDPlan = 3;
                        PersonaActual.FechaNacimiento = DateTime.Today;
                        PersonaActual.Nombre = this.txtNombre.Text;
                        PersonaActual.Apellido = txtApellido.Text;
                        */
                        PersonaActual.State = BusinessEntity.States.Deleted;

                        btnAceptar.Text = "Eliminar";

                    }
                    break;

            }
        }
        public override void GuardarCambios()
        {

            this.MapearADatos();

            PersonaLogic perLogic = new PersonaLogic();
            perLogic.Save(PersonaActual);
            UsuarioActual.IDPersona = PersonaActual.ID;
            UsuarioLogic usuLog = new UsuarioLogic();
            usuLog.Save(UsuarioActual);
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

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            //llegarCB();

        }
        public void llegarCB()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            cbPlanes.DataSource = planes;
            cbPlanes.DisplayMember = "Descripcion";
            cbPlanes.ValueMember = "ID";
            cbPlanes.SelectedIndex = -1;


        }

     


        public override bool Validar()
        {

            if (Validaciones.esCampoValido(txtNombre.Text))
            {
                if (Validaciones.esCampoValido(txtApellido.Text))
                {
                    if (Validaciones.esMailValido(txtEmail.Text))
                    {
                        if (Validaciones.esCampoValido(txtUsuario.Text))
                        {
                            if (Validaciones.esCampoValido(txtClave.Text))
                            {
                                if (Validaciones.esCampoValido(txtConfirmarClave.Text))
                                {
                                    if (txtClave.Text == txtConfirmarClave.Text)
                                    {
                                        if (cbTipo.SelectedIndex==0 || cbTipo.SelectedIndex==1 || cbTipo.SelectedIndex==2)
                                        {
                                            if (Validaciones.esCampoValido(txtLegajo.Text))
                                            {
                                                return true;
                                            }
                                            else 
                                            {
                                                Notificar("Error", "Legajo invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return false;
                                            }
                                            
                                        }
                                        else
                                        {
                                            Notificar("Error", "Solo se permiten privilegios Administrador, Alumno o Profesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return false;

                                        }
                                    }
                                    else
                                    {
                                        Notificar("Error", "Las claves no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;

                                    }
                                }
                                else
                                {
                                    Notificar("Error", "Confirmar clave invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                Notificar("Error", "Clave invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            Notificar("Error", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        Notificar("Error", "email invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    Notificar("Error", "Apellido invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                Notificar("Error", "Nombre invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cbPlanes.Enabled = true;
            if (cbTipo.SelectedIndex==0 || cbTipo.SelectedIndex == 2)
            {
                cbPlanes.SelectedIndex =-1;
                cbPlanes.Enabled = false;
            }
            
        }
    }
}

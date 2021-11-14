using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Usuarios : WebModo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			this.LoadGrid();
			if (!IsPostBack) {
				PlanLogic pl = new PlanLogic();
				List<Plan> planes = pl.GetAll();
				ddlPlan.DataSource = planes;
				//ddlPlan. = "Descripcion";
				//ddlPlan.ValueMember = "ID";
				ddlPlan.DataTextField = "Descripcion";
				ddlPlan.DataValueField = "ID";
				ddlPlan.DataBind();
				ddlPlan.SelectedIndex = -1;
				ListItem init = new ListItem();
				init.Text = "Seleccionar Plan";
				init.Value = "-1";
				this.ddlPlan.Items.Add(init);
				this.ddlPlan.SelectedValue = "-1";
			}
		}

		UsuarioLogic _logic;
		private UsuarioLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new UsuarioLogic();
				}
				return _logic;
			}
		}
		PersonaLogic _PerData;
		private PersonaLogic PerData
		{
			get
			{
				if (_PerData == null)
				{
					_PerData = new PersonaLogic();
				}
				return _PerData;
			}
		}
		private Usuario Entity
		{
			get;
			set;
		}
		private Persona PEntity
		{
			get;
			set;
		}
		public void Listar()
		{
			UsuarioLogic ul = new UsuarioLogic();
			PersonaLogic pl = new PersonaLogic();
			List<UsuariosPersonas> lup = new List<UsuariosPersonas>();
			foreach (Usuario u in ul.GetAll())
			{
				UsuariosPersonas up = new UsuariosPersonas();
				up.ID = u.ID;
				up.Nombre = u.Nombre;
				up.Apellido = u.Apellido;
				up.NombreUsuario = u.NombreUsuario;
				// up.TipoPersona = pl.GetOne(u.IDPersona).TipoPersona.ToString();
				//up.Tipo = int.Parse(pl.GetOne(u.IDPersona).TipoPersona);
				switch (pl.GetOne(u.IDPersona).TipoPersona)
				{
					case Persona.Tipo.Alumno:
						up.TipoPersona = UsuariosPersonas.Tipo.Alumno;
						break;
					case Persona.Tipo.Profesor:
						up.TipoPersona = UsuariosPersonas.Tipo.Profesor;
						break;
					case Persona.Tipo.Administrativo:
						up.TipoPersona = UsuariosPersonas.Tipo.Administrativo;
						break;
				}
				up.Legajo = pl.GetOne(u.IDPersona).Legajo;
				up.Habilitado = u.Habilitado;
				up.FechaNacimiento = pl.GetOne(u.IDPersona).FechaNacimiento;
				up.Email = u.Email;

				lup.Add(up);


			}
			this.gridView.DataSource = lup;
			this.gridView.DataBind();
			
		}
		private void LoadGrid()
		{
			//this.gridView.DataSource = this.Logic.GetAll();
			//this.gridView.DataBind();
			Listar();
		}

		
		

		private int SelectedID
		{
			get
			{
				if (this.ViewState["SelectedID"] != null)
				{
					return (int)this.ViewState["SelectedID"];
				}
				else
				{
					return 0;
				}
			}
			set
			{
				this.ViewState["SelectedID"] = value;
			}
		}
		private bool IsEntitySelected
		{
			get
			{
				return (this.SelectedID != 0);
			}
		}

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
			this.SelectedID = (int)this.gridView.SelectedValue;
			this.formPanel.Visible = false;
		}

		private void LoadForm(int id)
		{
			this.Entity = this.Logic.GetOne(id);
			this.nombreTextBox.Text = this.Entity.Nombre;
			this.apellidoTextBox.Text = this.Entity.Apellido;
			this.emailTextBox.Text = this.Entity.Email;
			this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
			this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
			this.claveTextBox.Text = Encriptacion.desencritar(this.Entity.Clave);
			this.repetirClaveTextBox.Text = Encriptacion.desencritar(this.Entity.Clave);
			this.PEntity = this.PerData.GetOne(this.Entity.IDPersona);

			
			switch (this.PEntity.TipoPersona)
			{
				case Persona.Tipo.Alumno:
					//this.txtTipo.Text = "Alumno";
					this.ddlTipo.SelectedIndex = 1;
					break;
				case Persona.Tipo.Profesor:
					//this.txtTipo.Text = "Profesor";
					this.ddlTipo.SelectedIndex = 2;
					break;
				case Persona.Tipo.Administrativo:
					//this.txtTipo.Text = "Administrador";
					this.ddlTipo.SelectedIndex = 0;
					break;
			}
			
			txtLegajo.Text = this.PEntity.Legajo.ToString();
			//fechaNacCalendario.SelectedDate = this.PEntity.FechaNacimiento.Date;
			//ddlPlan.SelectedValue = PEntity.IDPlan.ToString();
			if (this.PEntity.IDPlan != 0)
			{
				ddlPlan.SelectedValue = this.PEntity.IDPlan.ToString();
            }
            else
            {
				this.ddlPlan.SelectedValue = "-1";
			}
			//txtFecha.Text = this.PEntity.FechaNacimiento.ToShortDateString(); ;
			txtFecha.Text = this.PEntity.FechaNacimiento.ToString("yyyy-MM-dd");


		}
		private void SaveEntity(Usuario usuario)
		{
			this.Logic.Save(usuario);
		}
		private void SavePEntity(Persona persona)
		{
			this.PerData.Save(persona);
		}

		

		
		

		protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
			/*
			this.Entity = new Usuario();
			this.PEntity = new Persona();
			this.Entity = Logic.GetOne(this.SelectedID);
			//this.Entity.ID = this.SelectedID;
			this.Entity.State = BusinessEntity.States.Modified;
			this.LoadEntity(this.Entity);
			this.PEntity.ID = this.Entity.IDPersona;
			this.PEntity.State = BusinessEntity.States.Modified;
			this.LoadPEntity(this.PEntity);
			this.SaveEntity(this.Entity);
			this.SavePEntity(this.PEntity);
			this.LoadGrid();
			*/
			if (Validar()) {
				this.EnableForm(true);
				this.formPanel.Visible = false;
			}
		}
		private void LoadEntity(Usuario usuario)
		{
			usuario.Nombre = this.nombreTextBox.Text;
			usuario.Apellido = this.apellidoTextBox.Text;
			usuario.Email = this.emailTextBox.Text;
			usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
			usuario.Clave = Encriptacion.encriptar(this.claveTextBox.Text);
			usuario.Habilitado = this.habilitadoCheckBox.Checked;
		}
		private void LoadPEntity(Persona persona)
		{
			persona.Nombre = this.nombreTextBox.Text;
			persona.Apellido = this.apellidoTextBox.Text;
			persona.Email = this.emailTextBox.Text;
			//persona.FechaNacimiento = this.fechaNacCalendario.SelectedDate;
			//persona.FechaNacimiento = DateTime.Parse(txtFecha.ToString());
			persona.FechaNacimiento = DateTime.Parse(txtFecha.Text);
			persona.Legajo = int.Parse(this.txtLegajo.Text);
			/*
			switch (txtTipo.Text)
			{
				case "Alumno":
					persona.TipoPersona = Persona.Tipo.Alumno;
					break;
				case "Profesor":
					persona.TipoPersona = Persona.Tipo.Profesor;
					break;
				case "Administrador":
					persona.TipoPersona = Persona.Tipo.Administrativo;
					break;

			}
			*/
			switch (ddlTipo.SelectedIndex)
			{
				case 1:
					persona.TipoPersona = Persona.Tipo.Alumno;
					break;
				case 2:
					persona.TipoPersona = Persona.Tipo.Profesor;
					break;
				case 0:
					persona.TipoPersona = Persona.Tipo.Administrativo;
					break;

			}
			if (!(this.ddlPlan.SelectedValue == "-1"))
			{
				persona.IDPlan = int.Parse(this.ddlPlan.SelectedValue.ToString());
			}
			//persona.IDPlan = int.Parse(ddlPlan.SelectedValue.ToString());

		}

		private void EnableForm(bool enable)
		{
			switch (this.FormMode)
			{
				case FormModes.Baja:
					this.Entity = new Usuario();
					this.PEntity = new Persona();
					this.Entity = Logic.GetOne(this.SelectedID);

					//this.Entity.ID = this.SelectedID;
					this.Entity.State = BusinessEntity.States.Deleted;
					//this.LoadEntity(this.Entity);
					this.PEntity.ID = this.Entity.IDPersona;
					this.PEntity.State = BusinessEntity.States.Deleted;
					//this.LoadPEntity(this.PEntity);
					this.DeletePEntity(this.PEntity.ID);
					this.DeleteEntity(this.Entity.ID);
					this.LoadGrid();
					break;
				case FormModes.Modificacion:
					/*
					this.Entity = new Usuario();
					this.Entity.ID = this.SelectedID;
					this.Entity.State = BusinessEntity.States.Modified;
					this.LoadEntity(this.Entity);
					this.SaveEntity(this.Entity);
					this.LoadGrid();
					*/
					this.Entity = new Usuario();
					this.PEntity = new Persona();
					this.Entity = Logic.GetOne(this.SelectedID);

					//this.Entity.ID = this.SelectedID;
					this.Entity.State = BusinessEntity.States.Modified;
					this.LoadEntity(this.Entity);
					this.PEntity.ID = this.Entity.IDPersona;
					this.PEntity.State = BusinessEntity.States.Modified;
					this.LoadPEntity(this.PEntity);
					this.SaveEntity(this.Entity);
					this.SavePEntity(this.PEntity);
					this.LoadGrid();
					break;
				case FormModes.Alta:
					this.Entity = new Usuario();
					this.Entity.State = BusinessEntity.States.New;
					this.PEntity = new Persona();
					this.PEntity.State = BusinessEntity.States.New;
					
					this.LoadEntity(this.Entity);
					this.LoadPEntity(this.PEntity);
					this.SavePEntity(this.PEntity);
					this.Entity.IDPersona = this.PEntity.ID;
					this.SaveEntity(this.Entity);

					this.LoadGrid();
					break;
				default:
					break;
			}
			this.formPanel.Visible = false;
			//ClearForm();
		}

		protected void editarLinkButton_Click(object sender, EventArgs e)
		{
			ddlPlan.Enabled = true;
			this.gridView.SelectedIndex = -1;
			if (this.IsEntitySelected)
			{
				this.formPanel.Visible = true;
				this.FormMode = FormModes.Modificacion;
				this.LoadForm(this.SelectedID);
				//this.EnableForm(true);
			}
		}

		protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
			this.gridView.SelectedIndex = -1;
			if (this.IsEntitySelected)
			{
				this.formPanel.Visible = false;
				this.FormMode = FormModes.Baja;
				this.EnableForm(false);
				//this.LoadForm(this.SelectedID);
			}

		}
		protected void nuevoLinkLinkButton_Click(object sender, EventArgs e)
		{
			this.formPanel.Visible = true;
			this.FormMode = FormModes.Alta;
			this.ClearForm();

		}
		private void DeleteEntity(int id)
		{
			this.Logic.Delete(id);
		}
		private void DeletePEntity(int id)
		{
			this.PerData.Delete(id);
		}


		private void ClearForm()
		{
			this.nombreTextBox.Text = string.Empty;
			this.apellidoTextBox.Text = string.Empty;
			this.habilitadoCheckBox.Checked = false;
			this.nombreUsuarioTextBox.Text = string.Empty;
			emailTextBox.Text = string.Empty;
			this.claveTextBox.Text = string.Empty;
			this.repetirClaveTextBox.Text = string.Empty;
			this.txtLegajo.Text = string.Empty;
			this.txtFecha.Text = DateTime.Now.ToString();
			//this.txtTipo.Text = string.Empty;
			this.ddlPlan.SelectedValue = "-1";
		}

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
			this.formPanel.Visible = false;
			this.ClearForm();
			this.LoadGrid();
		}


		public bool Validar()
		{

			if (Validaciones.esCampoValido(nombreTextBox.Text))
			{
				if (Validaciones.esCampoValido(apellidoTextBox.Text))
				{
					if (Validaciones.esMailValido(emailTextBox.Text))
					{
						if (Validaciones.esCampoValido(nombreTextBox.Text))
						{
							if (Validaciones.esCampoValido(claveTextBox.Text))
							{
								if (Validaciones.esCampoValido(repetirClaveTextBox.Text))
								{
									if (claveTextBox.Text == repetirClaveTextBox.Text)
									{
										if ( ddlTipo.SelectedIndex ==0 || ddlTipo.SelectedIndex ==1 || ddlTipo.SelectedIndex==2)
										{
											if (Validaciones.esCampoValido(txtLegajo.Text))
											{
												return true;
											}
											else
											{
												lblLegajo.Visible = true;
												return false;
											}

										}
										else
										{
											lblTipo.Visible = true;
											return false;

										}
									}
									else
									{
										lblrepetirCoincidencia.Visible = true;
										return false;

									}
								}
								else
								{
									lblrepetirClave.Visible = true;
									return false;
								}
							}
							else
							{
								lblClave.Visible = true;
								return false;
							}
						}
						else
						{
							lblnombreUsuario.Visible = true;
							return false;
						}
					}
					else
					{
						lblemail.Visible = true;
						return false;
					}
				}
				else
				{
					lblApellido.Visible = true;
					return false;
				}
			}
			else
			{
				lblNombre.Visible = true;
				return false;
			}

		}

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
			//ddlPlan.Enabled = true;
			if (ddlTipo.SelectedIndex == 0 || ddlTipo.SelectedIndex == 2)
			{
				ddlPlan.SelectedValue = "-1";
				ddlPlan.Enabled = false;
			}
		}
    }
}
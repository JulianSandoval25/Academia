using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Especialidades : WebModo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Listar();

        }

        
		public void Listar()
		{
			this.gridView.DataSource = Logic.GetAll();
			this.gridView.DataBind();
		}

		EspecialidadesLogic _logic;
		private EspecialidadesLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new EspecialidadesLogic();
				}
				return _logic;
			}
		}
        private Especialidad espActual;
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

		protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
			if (Validar()) {
				this.EnableForm(true);
				this.formPanel.Visible = false;
			}
		}

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
			this.formPanel.Visible = false;
			this.ClearForm();
			this.Listar();
		}

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
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
				this.LoadForm(this.SelectedID);
			}
		}

        protected void nuevoLinkLinkButton_Click(object sender, EventArgs e)
        {
			this.formPanel.Visible = true;
			this.FormMode = FormModes.Alta;
			this.ClearForm();
		}

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
			this.SelectedID = (int)this.gridView.SelectedValue;
			this.formPanel.Visible = false;
		}

		private void EnableForm(bool enable)
		{
			switch (this.FormMode)
			{
				case FormModes.Baja:
					
					Logic.Delete(this.SelectedID);
					break;
				case FormModes.Modificacion:
					this.espActual = new Especialidad();
					this.espActual = Logic.GetOne(this.SelectedID);
					this.espActual.State = BusinessEntity.States.Modified;
					espActual.ID = int.Parse(txtID.Text);
					espActual.Descripcion = txtDescripcion.Text;
					this.Logic.Save(this.espActual);
					break;
				case FormModes.Alta:
					this.espActual = new Especialidad();
					this.espActual.State = BusinessEntity.States.New;
					espActual.Descripcion = txtDescripcion.Text;
					Logic.Save(this.espActual);

					break;
				default:
					break;

			}
			Listar();
		}

		private void LoadForm(int id)
		{
			this.espActual = this.Logic.GetOne(id);
			this.txtID.Text = this.espActual.ID.ToString();
			this.txtDescripcion.Text = this.espActual.Descripcion;


		}


		private void ClearForm()
		{
			this.txtID.Text = string.Empty;
			this.txtDescripcion.Text = string.Empty;
			
		}

		public bool Validar()
		{

			if (Validaciones.esCampoValido(txtDescripcion.Text))
			{
				return true;
			}
			else
			{
				lblDescripcion2.Visible = true;
				return false;
			}

		}
	}


}
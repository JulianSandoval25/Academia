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
    public partial class Planes : WebModo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Listar();
            if (!IsPostBack)
            {
				CargarDdlEspecialidades();
            }

		}
		PlanLogic _logic;
		private PlanLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new PlanLogic();
				}
				return _logic;
			}
		}
		private Plan planActual;
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
		public void Listar()
		{
			EspecialidadesLogic el = new EspecialidadesLogic();
			List<PlanEspecialidad> planes = new List<PlanEspecialidad>();
			foreach (Plan p in Logic.GetAll())
			{
				PlanEspecialidad plan = new PlanEspecialidad();
				plan.ID = p.ID;
				plan.Descripcion = p.Descripcion;
				plan.DescripcionEspecialidad = el.GetOne(p.IDEspecialidad).Descripcion;
				planes.Add(plan);
			}
			this.gridView.DataSource = planes;
			this.gridView.DataBind();

		}

		public void CargarDdlEspecialidades()
		{
			EspecialidadesLogic el = new EspecialidadesLogic();
			List<Especialidad> especialidades = el.GetAll();
			ddlEspecialidad.DataSource = especialidades;
			ddlEspecialidad.DataTextField = "Descripcion";
			ddlEspecialidad.DataValueField = "ID";
			ddlEspecialidad.DataBind();
			ddlEspecialidad.SelectedIndex = -1;
		}
		protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
			this.SelectedID = (int)this.gridView.SelectedValue;
			this.formPanel.Visible = false;
			//this.gridView.SelectedIndex = -1;
		}

        protected void nuevoLinkLinkButton_Click(object sender, EventArgs e)
        {
			this.formPanel.Visible = true;
			this.FormMode = FormModes.Alta;
			this.ClearForm();
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

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
			this.formPanel.Visible = false;
			this.Listar();
		}

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
			if (Validar()) {
				this.EnableForm(true);
				this.formPanel.Visible = false;
			}
		}


		private void EnableForm(bool enable)
		{
			switch (this.FormMode)
			{
				case FormModes.Baja:

					Logic.Delete(this.SelectedID);
					break;
				case FormModes.Modificacion:
					this.planActual = new Plan();
					this.planActual = Logic.GetOne(this.SelectedID);
					this.planActual.State = BusinessEntity.States.Modified;
					planActual.ID = int.Parse(txtID.Text);
					planActual.Descripcion = txtDescripcion.Text;
					
					if (!(this.ddlEspecialidad.SelectedValue == null))
					{
						planActual.IDEspecialidad = int.Parse(this.ddlEspecialidad.SelectedValue);
					}
					this.Logic.Save(this.planActual);
					break;
				case FormModes.Alta:
					this.planActual = new Plan();
					this.planActual.State = BusinessEntity.States.New;
					planActual.Descripcion = txtDescripcion.Text;
					if (!(this.ddlEspecialidad.SelectedValue == null))
					{
						planActual.IDEspecialidad = int.Parse(this.ddlEspecialidad.SelectedValue.ToString());
					}
					Logic.Save(this.planActual);

					break;
				default:
					break;

			}
			Listar();
		}

		private void LoadForm(int id)
		{
			this.planActual = this.Logic.GetOne(id);
			this.txtID.Text = this.planActual.ID.ToString();
			this.txtDescripcion.Text = this.planActual.Descripcion;
			if (this.planActual.IDEspecialidad != 0) {
				ddlEspecialidad.SelectedValue = this.planActual.IDEspecialidad.ToString();
			}
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
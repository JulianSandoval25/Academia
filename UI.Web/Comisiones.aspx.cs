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
    public partial class Comisiones : WebModo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Listar();
			if (!IsPostBack)
			{
				CargarDdlPlan();
			}
		}
		ComisionLogic _logic;
		private Comision comisionActual;
		private ComisionLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new ComisionLogic();
				}
				return _logic;
			}
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


		public void Listar()
		{
			PlanLogic pl = new PlanLogic();
			List<ComisionPlan> comisiones = new List<ComisionPlan>();
			foreach (Comision c in Logic.GetAll())
			{
				ComisionPlan comision = new ComisionPlan();
				comision.ID = c.ID;
				comision.Descripcion = c.Descripcion;
				comision.AnioEspecialidad = c.AnioEspecialidad;
				comision.DescripcionPlan = pl.GetOne(c.IDPlan).Descripcion;
				comisiones.Add(comision);
			}
			this.gridView.DataSource = comisiones;
			this.gridView.DataBind();
		}
		public void CargarDdlPlan()
		{
			PlanLogic pl = new PlanLogic();
			List<Plan> planes = pl.GetAll();
			ddlPlan.DataSource = planes;
			ddlPlan.DataTextField = "Descripcion";
			ddlPlan.DataValueField = "ID";
			ddlPlan.DataBind();
			ddlPlan.SelectedIndex = -1;
		}
		private void EnableForm(bool enable)
		{
			switch (this.FormMode)
			{
				case FormModes.Baja:

					Logic.Delete(this.SelectedID);
					break;
				case FormModes.Modificacion:
					this.comisionActual = new Comision();
					this.comisionActual = Logic.GetOne(this.SelectedID);
					this.comisionActual.State = BusinessEntity.States.Modified;
					comisionActual.ID = int.Parse(txtID.Text);
					comisionActual.Descripcion = txtDescripcion.Text;
					comisionActual.AnioEspecialidad = int.Parse(txtAnioEspecialidad.Text);

					if (!(this.ddlPlan.SelectedValue == null))
					{
						comisionActual.IDPlan = int.Parse(this.ddlPlan.SelectedValue);
					}
					this.Logic.Save(this.comisionActual);
					break;
				case FormModes.Alta:
					this.comisionActual = new Comision();
					this.comisionActual.State = BusinessEntity.States.New;
					comisionActual.Descripcion = txtDescripcion.Text;
					comisionActual.AnioEspecialidad = int.Parse(txtAnioEspecialidad.Text);
					if (!(this.ddlPlan.SelectedValue == null))
					{
						comisionActual.IDPlan = int.Parse(this.ddlPlan.SelectedValue.ToString());
					}
					Logic.Save(this.comisionActual);

					break;
				default:
					break;

			}
			Listar();
		}

		private void LoadForm(int id)
		{
			this.comisionActual = this.Logic.GetOne(id);
			this.txtID.Text = this.comisionActual.ID.ToString();
			this.txtDescripcion.Text = this.comisionActual.Descripcion;
			this.txtAnioEspecialidad.Text = this.comisionActual.AnioEspecialidad.ToString();
			if (this.comisionActual.IDPlan != 0)
			{
				ddlPlan.SelectedValue = this.comisionActual.IDPlan.ToString();
			}
		}

		private void ClearForm()
		{
			this.txtID.Text = string.Empty;
			this.txtDescripcion.Text = string.Empty;
			this.txtAnioEspecialidad.Text = string.Empty;

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
			this.ClearForm();
			this.Listar();
		}

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
			if (Validar()) {
				this.EnableForm(true);
				this.formPanel.Visible = false;
			}
		}


		public bool Validar()
		{

			if (Validaciones.esCampoValido(txtDescripcion.Text))
			{
				if (Validaciones.esCampoValido(txtAnioEspecialidad.Text))
				{
					return true;
				}
				else
				{
					lblAnio2.Visible = true;
					return false;
				}
			}
			else
			{
				lblDescripcion2.Visible = true;
				return false;
			}

		}
	}
}
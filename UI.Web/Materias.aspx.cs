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
	public partial class Materias : WebModo
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Listar();
			if (!IsPostBack) {
				//necesario para uq ande bien
				CargarDdlPlan();
			}
		}
		MateriaLogic _logic;
		private MateriaLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new MateriaLogic();
				}
				return _logic;
			}
		}
		private Materia matActual;
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
			PlanLogic pl = new PlanLogic();
			List<MateriaPlan> matplan = new List<MateriaPlan>();
			foreach (Materia m in Logic.GetAll())
			{
				MateriaPlan mat = new MateriaPlan();
				mat.ID = m.ID;
				mat.Descripcion = m.Descripcion;
				mat.HSSemanales = m.HSSemanales;
				mat.HSTotales = m.HSTotales;
				mat.DescripcionPlan = pl.GetOne(m.IDPlan).Descripcion;
				matplan.Add(mat);
			}
			this.gridView.DataSource = matplan;
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
			this.SelectedID = (int)this.gridView.SelectedValue;
			this.formPanel.Visible = false;
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

		private void EnableForm(bool enable)
		{
			switch (this.FormMode)
			{
				case FormModes.Baja:

					Logic.Delete(this.SelectedID);
					break;
				case FormModes.Modificacion:
					this.matActual = new Materia();
					this.matActual = Logic.GetOne(this.SelectedID);
					this.matActual.State = BusinessEntity.States.Modified;
					matActual.ID = int.Parse(txtID.Text);
					matActual.Descripcion = txtDescripcion.Text;
					matActual.HSSemanales = int.Parse(txtHSSemanales.Text);
					matActual.HSTotales = int.Parse(txtHSTotales.Text);
					if (!(this.ddlPlan.SelectedValue == null))
					{
						matActual.IDPlan = int.Parse(this.ddlPlan.SelectedValue.ToString());
						matActual.IDPlan = int.Parse(this.ddlPlan.SelectedValue);
						matActual.IDPlan = int.Parse(ddlPlan.SelectedItem.Value);
					}
					this.Logic.Save(this.matActual);
					break;
				case FormModes.Alta:
					this.matActual = new Materia();
					this.matActual.State = BusinessEntity.States.New;
					matActual.Descripcion = txtDescripcion.Text;
					matActual.HSSemanales = int.Parse(txtHSSemanales.Text);
					matActual.HSTotales = int.Parse(txtHSTotales.Text);
					if (!(this.ddlPlan.SelectedValue == null))
					{
						matActual.IDPlan = int.Parse(this.ddlPlan.SelectedValue.ToString());
					}
					Logic.Save(this.matActual);

					break;
				default:
					break;

			}
			Listar();
		}
		private void LoadForm(int id)
		{
			this.matActual = this.Logic.GetOne(id);
			this.txtID.Text = this.matActual.ID.ToString();
			this.txtDescripcion.Text = this.matActual.Descripcion;
			this.txtHSSemanales.Text = this.matActual.HSSemanales.ToString();
			this.txtHSTotales.Text = this.matActual.HSTotales.ToString();
			if (this.matActual.IDPlan != 0)
			{
				ddlPlan.SelectedValue = this.matActual.IDPlan.ToString();
			}


		}

		private void ClearForm()
		{
			this.txtID.Text = string.Empty;
			this.txtDescripcion.Text = string.Empty;
			txtHSSemanales.Text = string.Empty;
			txtHSTotales.Text = string.Empty;

		}


		public bool Validar()
		{

			if (Validaciones.esCampoValido(txtDescripcion.Text))
			{
				if (Validaciones.esCampoValido(txtHSSemanales.Text))
				{
					if (Validaciones.esCampoValido(txtHSTotales.Text))
					{
						return true;
					}
					else
					{
						lblHSTotales2.Visible = true;
						return false;
					}
				}
				else
				{
					lblHSSemanales2.Visible = true;
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
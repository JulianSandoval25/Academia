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
    public partial class Cursos : WebModo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Listar();
			if (!IsPostBack)
			{
				//CargarDdlMateria();
				//CargarDdlComision();
				CargarDdlPlanes();
			}
		}
		CursoLogic _logic;
		private CursoLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new CursoLogic();
				}
				return _logic;
			}
		}
		private Curso cursoActual;
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
			MateriaLogic ml = new MateriaLogic();
			ComisionLogic cl = new ComisionLogic();
			List<CursoComisionMateria> cursos = new List<CursoComisionMateria>();
			foreach (Curso c in Logic.GetAll())
			{
				CursoComisionMateria curso = new CursoComisionMateria();
				curso.ID = c.ID;
				curso.DescripcionMateria = ml.GetOne(c.IDMateria).Descripcion ;
				curso.DescripcionComisiones = cl.GetOne(c.IDComision).Descripcion;
				curso.AnioCalendario = c.AnioCalendario;
				curso.Cupo = c.Cupo;
				cursos.Add(curso);
			}
			this.gridView.DataSource = cursos;
			this.gridView.DataBind();

		}

		public void CargarDdlMateria()
		{
			MateriaLogic ml = new MateriaLogic();
			List<Materia> materias = ml.GetAll();
			ddlMateria.DataSource = materias;
			ddlMateria.DataTextField = "Descripcion";
			ddlMateria.DataValueField = "ID";
			ddlMateria.DataBind();
			ddlMateria.SelectedIndex = -1;
		}

		public void CargarDdlComision()
		{
			ComisionLogic cl = new ComisionLogic();
			List<Comision> comisiones = cl.GetAll();
			ddlComision.DataSource = comisiones;
			ddlComision.DataTextField = "Descripcion";
			ddlComision.DataValueField = "ID";
			ddlComision.DataBind();
			ddlComision.SelectedIndex = -1;
		}

		public void CargarDdlPlanes()
		{

			PlanLogic pl = new PlanLogic();
			List<Plan> planes = pl.GetAll();
			ddlPlanes.DataSource = planes;
			ddlPlanes.DataTextField = "Descripcion";
			ddlPlanes.DataValueField = "ID";
			ddlPlanes.DataBind();
			ddlPlanes.SelectedIndex = -1;
		}

		public void CargarDdl(int ID)
		{
			MateriaLogic ml = new MateriaLogic();
			List<Materia> materias = ml.GetAllxID(ID);
			ddlMateria.DataSource = materias;
			ddlMateria.DataTextField = "Descripcion";
			ddlMateria.DataValueField = "ID";
			ddlMateria.DataBind();
			ddlMateria.SelectedIndex = -1;

			ComisionLogic cl = new ComisionLogic();
			List<Comision> comisiones = cl.GetAllxID(ID);
			ddlComision.DataSource = comisiones;
			ddlComision.DataTextField = "Descripcion";
			ddlComision.DataValueField = "ID";
			ddlComision.DataBind();
			ddlComision.SelectedIndex = -1;
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
					this.cursoActual = new Curso();
					this.cursoActual = Logic.GetOne(this.SelectedID);
					this.cursoActual.State = BusinessEntity.States.Modified;
					cursoActual.ID = int.Parse(txtID.Text);
					
					if (!(this.ddlMateria.SelectedValue == null))
					{
						cursoActual.IDMateria = int.Parse(this.ddlMateria.SelectedValue);
					}
					if (!(this.ddlComision.SelectedValue == null))
					{
						cursoActual.IDComision = int.Parse(this.ddlComision.SelectedValue);
					}
					cursoActual.AnioCalendario = int.Parse(txtAnioCalendario.Text);
					cursoActual.Cupo = int.Parse(txtCupo.Text);
					this.Logic.Save(this.cursoActual);
					break;
				case FormModes.Alta:
					this.cursoActual = new Curso();
					this.cursoActual.State = BusinessEntity.States.New;
					if (!(this.ddlMateria.SelectedValue == null))
					{
						cursoActual.IDMateria = int.Parse(this.ddlMateria.SelectedValue);
					}
					if (!(this.ddlComision.SelectedValue == null))
					{
						cursoActual.IDComision = int.Parse(this.ddlComision.SelectedValue);
					}
					cursoActual.AnioCalendario = int.Parse(txtAnioCalendario.Text);
					cursoActual.Cupo = int.Parse(txtCupo.Text);
					Logic.Save(this.cursoActual);

					break;
				default:
					break;

			}
			Listar();
		}
		private void LoadForm(int id)
		{
			this.cursoActual = this.Logic.GetOne(id);
			this.txtID.Text = this.cursoActual.ID.ToString();
			if (this.cursoActual.IDMateria != 0)
			{
				ddlMateria.SelectedValue = this.cursoActual.IDMateria.ToString();
			}
			if (this.cursoActual.IDComision != 0)
			{
				ddlComision.SelectedValue = this.cursoActual.IDComision.ToString();
			}
			this.txtAnioCalendario.Text = this.cursoActual.AnioCalendario.ToString();
			this.txtCupo.Text = this.cursoActual.Cupo.ToString();


		}

		private void ClearForm()
		{
			this.txtID.Text = string.Empty;
			this.txtAnioCalendario.Text = string.Empty;
			txtCupo.Text = string.Empty;
			ddlMateria.SelectedIndex = -1;
			ddlComision.SelectedIndex = -1;

		}

        protected void nuevoLinkLinkButton_Click(object sender, EventArgs e)
        {
			this.formPanel.Visible = true;
			this.FormMode = FormModes.Alta;
			CargarDdl(int.Parse(ddlPlanes.SelectedValue));
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
				ComisionLogic cl = new ComisionLogic();
				int idplan = cl.GetOne(Logic.GetOne(this.SelectedID).IDComision).IDPlan;
				CargarDdl(idplan);
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

		public bool Validar()
		{

			if (Validaciones.esCampoValido(txtAnioCalendario.Text))
			{
				if (Validaciones.esCampoValido(txtCupo.Text))
				{
                    if (ddlComision.SelectedValue != null)
                    {
						if (ddlMateria.SelectedValue != null)
						{
							return true;
						}
						else
						{
							Response.Write("materia invalida");
							return false;
						}
					}
                    else
                    {
						Response.Write("comision invalida");
						return false;
                    }
				}
				else
				{
					lblCupo2.Visible = true;
					return false;
				}
			}
			else
			{
				lblAnio2.Visible = true;
				return false;
			}

		}
	}
}
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
    public partial class RegistroCalificacion : WebModo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                cargarDdlCurso();
            }
            Listar();
        }
        DocenteCursoLogic _logic;
        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteCursoLogic();
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

        public Usuario usuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
        }
        public Persona personaActual
        {
            get { return (Persona)Session["PersonaActual"]; }
        }

        public void Listar()
        {
            List<Business.Entities.Inscripciones> alumnos = new List<Business.Entities.Inscripciones>();
            InscripcionLogic il = new InscripcionLogic();
            PersonaLogic perData = new PersonaLogic();
            if (ddlCursos.SelectedValue != "-1")
            {
                foreach (AlumnoInscripcion ai in il.GetAllxIdCurso(int.Parse(ddlCursos.SelectedValue.ToString())))
                {
                    Business.Entities.Inscripciones alumno = new Business.Entities.Inscripciones();
                    alumno.ID = ai.ID;
                    alumno.Nombre = perData.GetOne(ai.IDAlumno).Nombre;
                    alumno.Apellido = perData.GetOne(ai.IDAlumno).Apellido;
                    alumno.Condicion = ai.Condicion;
                    alumno.Nota = ai.Nota;
                    alumno.IDCurso = ai.IDCurso;
                    alumnos.Add(alumno);
                }
            }
            else
            {
                Response.Write("sin alumnos");
            }
            gridView.DataSource = alumnos;
            gridView.DataBind();
        }
        public void cargarDdlCurso()
        {
            List<DocenteCurso> cursos = new List<DocenteCurso>();
            cursos = Logic.TraerTodosxIdDoc(usuarioActual.IDPersona);
            ddlCursos.DataSource = cursos;
            ddlCursos.DataTextField = "IDCurso";
            ddlCursos.DataValueField = "IDCurso";
            ddlCursos.DataBind();
            ListItem init = new ListItem();
            init.Text = "Seleccionar Curso";
            init.Value = "-1";
            ddlCursos.Items.Add(init);
            ddlCursos.SelectedValue = "-1";
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void cargarNotaLinkLinkButton_Click(object sender, EventArgs e)
        {
            this.gridView.SelectedIndex = -1;
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                //this.ClearForm();
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Validar()) {
                Business.Entities.Inscripciones inscripto = new Business.Entities.Inscripciones();
                inscripto.ID = int.Parse(txtID.Text);
                inscripto.Condicion = txtCondicion.Text;
                inscripto.Nota = int.Parse(txtNota.Text);
                InscripcionLogic il = new InscripcionLogic();
                il.Update(inscripto);
                this.formPanel.Visible = false;
                Listar();
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.Listar();
        }

        protected void actualizarLinkLinkButton_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void ClearForm()
        {
            this.txtID.Text = string.Empty;
            this.txtCondicion.Text = string.Empty;
            this.txtNota.Text = string.Empty;

        }

        private void LoadForm(int id)
        {
            InscripcionLogic il = new InscripcionLogic();
            Business.Entities.Inscripciones ins = il.ConseguirInscripcionXid(id);
            txtID.Text = ins.ID.ToString();
            txtCondicion.Text = ins.Condicion;
        }
        public bool Validar()
        {

            if (Validaciones.esCampoValido(txtCondicion.Text))
            {
                if (Validaciones.esCampoValido(txtNota.Text))
                {
                    return true;
                }
                else
                {
                    lblNota2.Visible = true;
                    return false;
                }
            }
            else
            {
                lblCondicion2.Visible = true;
                return false;
            }

        }
    }
}
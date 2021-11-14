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
    public partial class Inscripciones : WebModo
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Listar();
        }
        InscripcionLogic _logic;
        private InscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new InscripcionLogic();
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
            MateriaLogic lm = new MateriaLogic();
            ComisionLogic lc = new ComisionLogic();
            CursoLogic lcu = new CursoLogic();
            List<AlumnoInscripcion> ais = new List<AlumnoInscripcion>();
            ais = Logic.GetAllxIdPersona(this.usuarioActual.IDPersona);
            List<InscripcionesEditado> ins = new List<InscripcionesEditado>();
            foreach (AlumnoInscripcion ai in ais)
            {
                InscripcionesEditado i = new InscripcionesEditado();
                i.ID = ai.ID;
                i.Materia = lm.GetOne(lcu.GetOne(ai.IDCurso).IDMateria).Descripcion;
                i.Comision = lc.GetOne(lcu.GetOne(ai.IDCurso).IDComision).Descripcion;
                i.Nota = ai.Nota;
                i.Condicion = ai.Condicion;
                ins.Add(i);
            }
            gridView.DataSource = ins;
            gridView.DataBind();
        }

        private void ListarInscripcion()
        {
            MateriaLogic ml = new MateriaLogic();
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();
            List<CursoComisionMateria> inscripciones = new List<CursoComisionMateria>();
            foreach (Curso c in cl.GetAllxPlan(personaActual.IDPlan, personaActual.ID))
            {
                CursoComisionMateria curso = new CursoComisionMateria();
                curso.ID = c.ID;
                //curso.IDComision = c.IDComision;
                curso.DescripcionComisiones = col.GetOne(c.IDComision).Descripcion;
                curso.DescripcionMateria = ml.GetOne(c.IDMateria).Descripcion;
                curso.AnioCalendario = c.AnioCalendario;
                curso.Cupo = c.Cupo;
                inscripciones.Add(curso);
            }
            gridViewInscripcion.DataSource = inscripciones;
            gridViewInscripcion.DataBind();

        }

        protected void nuevoLinkLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            ListarInscripcion();
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            //this.gridView.SelectedIndex = -1;
            try
            {

            
            
            if (this.IsEntitySelected)
            {
                Validaciones.CuposValidos(SelectedID);
                
                AlumnoInscripcion alum = new AlumnoInscripcion();
                alum.IDCurso = SelectedID;
                alum.IDAlumno = personaActual.ID;
                alum.Condicion = "Cursando";
                Logic.Inscribir(alum);
                
            }
            
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Curso sin cupo');</script>");
            }
            finally
            {
                Listar();
                this.gridViewInscripcion.SelectedIndex = -1;
                this.formPanel.Visible = false;
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.Listar();
        }


        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridViewInscripcion_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridViewInscripcion.SelectedValue;
        }
    }
}
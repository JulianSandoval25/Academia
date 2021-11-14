using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;

namespace UI.Web
{
    public partial class ReporteCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<CursoComisionMateria> cursos = new List<CursoComisionMateria>();
                CursoLogic cl = new CursoLogic();
                ComisionLogic coml = new ComisionLogic();
                MateriaLogic ml = new MateriaLogic();
                try
                {
                    foreach (Curso c in cl.GetAll())
                    {
                        CursoComisionMateria cur = new CursoComisionMateria();
                        cur.ID = c.ID;
                        cur.DescripcionComisiones = coml.GetOne(c.IDComision).Descripcion;
                        cur.DescripcionMateria = ml.GetOne(c.IDMateria).Descripcion;
                        cur.AnioCalendario = c.AnioCalendario;
                        cur.Cupo = c.Cupo;
                        cursos.Add(cur);
                    }
                    ReportDataSource rds = new ReportDataSource("ReporteCursos", cursos);
                    this.ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.InformeReporte.rdlc";
                    this.ReportViewer1.LocalReport.DataSources.Clear();
                    this.ReportViewer1.LocalReport.DataSources.Add(rds);
                    this.ReportViewer1.DataBind();
                }
                catch (Exception Ex)
                {
                    Response.Write("Error al recuperar lista de curso " + Ex);
                }
            }
        }
    }
}
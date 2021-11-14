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
    public partial class ReportePlanes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PlanLogic pl = new PlanLogic();
                EspecialidadesLogic el = new EspecialidadesLogic();
                List<PlanEspecialidad> planes = new List<PlanEspecialidad>();
                try
                {
                    foreach (Plan p in pl.GetAll())
                    {
                        PlanEspecialidad plan = new PlanEspecialidad();
                        plan.ID = p.ID;
                        plan.Descripcion = p.Descripcion;
                        plan.DescripcionEspecialidad = el.GetOne(p.IDEspecialidad).Descripcion;
                        planes.Add(plan);
                    }
                    ReportDataSource rds = new ReportDataSource("ReportePlanes", planes);
                    this.ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.Report1.rdlc";
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class formReportePlanes : Form
    {
        public formReportePlanes()
        {
            InitializeComponent();
        }

        private void formReportePlanes_Load(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            EspecialidadesLogic el = new EspecialidadesLogic();
            List<PlanEspecialidad> planes = new List<PlanEspecialidad>();
            foreach (Plan p in pl.GetAll())
            {
                PlanEspecialidad plan = new PlanEspecialidad();
                plan.ID = p.ID;
                plan.Descripcion = p.Descripcion;
                plan.DescripcionEspecialidad = el.GetOne(p.IDEspecialidad).Descripcion;
                planes.Add(plan);
            }
            ReportDataSource rds = new ReportDataSource("ReportePlanes", planes);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}

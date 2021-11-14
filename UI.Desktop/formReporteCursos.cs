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
    public partial class formReporteCursos : Form
    {
        public formReporteCursos()
        {
            InitializeComponent();
        }

        private void formReporteCursos_Load(object sender, EventArgs e)
        {
            List<CursoComisionMateria> cursos = new List<CursoComisionMateria>();
            CursoLogic cl = new CursoLogic();
            ComisionLogic coml = new ComisionLogic();
            MateriaLogic ml = new MateriaLogic();
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
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.InformeReporte.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

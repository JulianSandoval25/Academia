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

namespace UI.Desktop
{
    public partial class RegistrarCalificacionDesktop : ApplicationForm
    {
        public RegistrarCalificacionDesktop()
        {
            InitializeComponent();
        }

        public RegistrarCalificacionDesktop(Business.Entities.Inscripciones ins)
        {
            InitializeComponent();
            
            txtInscripcion.Text = ins.ID.ToString();
            txtCondicion.Text = ins.Condicion;
        }

        private void RegistrarCalificacionDesktop_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()) {
                Business.Entities.Inscripciones inscripto = new Business.Entities.Inscripciones();
                inscripto.ID = int.Parse(txtInscripcion.Text);
                inscripto.Condicion = txtCondicion.Text;
                inscripto.Nota = int.Parse(txtNota.Text);
                InscripcionLogic il = new InscripcionLogic();
                il.Update(inscripto);
                MessageBox.Show("nota cargada", "Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override bool Validar()
        {


            if (Validaciones.esCampoValido(txtCondicion.Text))
            {
                if (Validaciones.esCampoValido(txtNota.Text))
                {
                    return true;
                }
                else
                {
                    Notificar("Error", "Nota invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                Notificar("Error", "Condicion invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }
    }
}

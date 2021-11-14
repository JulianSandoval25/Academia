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
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public Usuario usuarioActual { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                UsuarioLogic usuarioData = new UsuarioLogic();
                //usuarioActual = usuarioData.Login(txtUsuario.Text, txtPass.Text);
                usuarioActual = usuarioData.Login(txtUsuario.Text, Encriptacion.encriptar(txtPass.Text));
                if (usuarioActual.ID != 0)
                {
                    if (usuarioActual.Habilitado)
                    {
                        Notificar("Login Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Notificar("El Usuario no está habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Notificar("Usuario o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPass.Clear();
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public override bool Validar()
        {

            if (Validaciones.esCampoValido(txtUsuario.Text))
            {
                if (Validaciones.esCampoValido(txtPass.Text))
                {
                    return true;
                }
                else
                {
                    Notificar("Error", "Contraseña invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                Notificar("Error", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}

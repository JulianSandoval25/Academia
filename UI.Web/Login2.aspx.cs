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
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Usuario usuarioActual { get; set; }
        public Persona personaActual { get; set; }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            
            UsuarioLogic usuarioData = new UsuarioLogic();
            //usuarioActual = usuarioData.Login(txtUsuario.Text, txtClave.Text);
            usuarioActual = usuarioData.Login(txtUsuario.Text, Encriptacion.encriptar(txtClave.Text));
            
            if (usuarioActual.ID != 0)
            {
                if (usuarioActual.Habilitado)
                {
                    Page.Response.Write("Login Correcto");
                    Session["UsuarioActual"] = usuarioActual;
                    PersonaLogic perData = new PersonaLogic();
                    personaActual = perData.GetOne(usuarioActual.IDPersona);
                    Session["PersonaActual"] = personaActual;
                    Page.Response.Redirect("~/Default.aspx");

                }
                else
                {
                    //Page.Response.Write("El Usuario no está habilitado");
                    lblMensage2.Visible = true;
                }
            }
            else
            {
                //Page.Response.Write("Usuario o contraseña incorrectos");
                lblMensage.Visible = true;
                this.txtClave.Text="";
            }
            
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("No implementado");
        }

    }
}
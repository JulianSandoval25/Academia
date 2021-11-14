using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.Web
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["UsuarioActual"];

                string text = string.Format("¡Bienvenido a la Academia: {0}, {1}!", user.Apellido, user.Nombre);
                Label1.Text = text;
            }
        }
    }
}
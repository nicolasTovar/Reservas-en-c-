using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reserva
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {


            if (txtUsuario.Text.Length > 0 && txtNombre.Text.Length > 0 && txtApellido.Text.Length > 0 && txtCorreo.Text.Length > 0 && txtContraseña.Text.Length > 0)
            {
                
                Session["usuario"] = txtUsuario.Text;
                Session["nombre"] = txtNombre.Text;
                Session["apellido"] = txtApellido.Text;
                Session["correo"] = txtCorreo.Text;
                Session["contraseña"] = txtContraseña.Text;
               
                Response.Redirect("Login.aspx");

            }
            else
            {
                Response.Write("<script> alert('Debe llenar todos los campos')</script>");
            }
        }
    }
}
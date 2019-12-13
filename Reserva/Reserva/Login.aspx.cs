using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reserva
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtUsuario.Text = Session["usuario"].ToString();
                txtContraseña.Text = Session["contraseña"].ToString();
                   
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length>0 && txtContraseña.Text.Length>0)
            {
                if (txtUsuario.Text == Session["usuario"].ToString() && txtContraseña.Text == Session["contraseña"].ToString())
                {
                    Response.Redirect("Cliente.aspx");
                }



            }
            else if (txtUsuario.Text != Session["usuario"].ToString() || txtContraseña.Text != Session["contraseña"].ToString())
            {
                Response.Write("<script>alert('Usuario incorrecto')</script>");
            }


            else
            {
                Response.Write("<script> alert('Debe llenar todos los campos')</script>");
            }
           
        }
    }
}
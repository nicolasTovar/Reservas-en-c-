using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Reserva
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                lblNombreM.Text = Session["nombre"].ToString() + " " + Session["apellido"].ToString();
                DataSet set = new DataSet();
                set.ReadXml(Server.MapPath("Paises.xml"));
                ddlPaises.DataSource = set;
                ddlPaises.DataTextField = "NombrePaises";
                ddlPaises.DataBind();
                btnGenerar.Enabled = false;
                table();
            }
        }

        public void limpiar()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtInicio.Text = "";
            txtFinal.Text = "";
            ddlPaises.Text = "";
        }
    

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtIdentificacion.Text.Length>0 && txtNombre.Text.Length>0 && txtApellido.Text.Length > 0 && txtCorreo.Text.Length>0 && txtInicio.Text.Length>0 && txtFinal.Text.Length>0 && ddlPaises.Text.Length > 0)
            {
                Session["nombreC"] = txtNombre.Text;
                Session["identificacion"] = txtIdentificacion.Text;
                Session["apellido"] = txtApellido.Text;
                Session["correo"] = txtCorreo.Text;
                Session["inicio"] = txtInicio.Text;
                Session["final"] = txtFinal.Text;
                Session["paises"] = ddlPaises.SelectedItem;

                Clientes clientes = new Clientes
                {
                    identificacion = Session["identificacion"].ToString(),
                    nombre = Session["nombreC"].ToString(),
                    apellido = Session["apellido"].ToString(),
                    correo = Session["correo"].ToString(),
                    inicio = Session["inicio"].ToString(),
                    final = Session["final"].ToString(),
                    paises = Session["paises"].ToString()

                };
                DataTable table = (DataTable)ViewState["table"];
              

                table.Rows.Add(clientes.identificacion, clientes.nombre, clientes.apellido, clientes.correo, clientes.inicio, clientes.final, clientes.paises);
                gvInformacion.DataSource = table;
                gvInformacion.DataBind();

                Session["archivo"] = JsonConvert.SerializeObject(table);
                limpiar();
                Response.Write("<script>alert('El registro a sido agregado a la tabla')</script>");
                btnGenerar.Enabled = true;
            }
            else
            {
                Response.Write("<script>alert('Debe llenar todos los campos')</script>");
            }
        }
        public void table()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Identificacion");
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Correo");
            table.Columns.Add("Fecha de inicio");
            table.Columns.Add("Fecha de finalización");
            table.Columns.Add("Paises");
            ViewState["table"] = table;
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Server.MapPath("archivo.json"), "[" + Session["Archivo"].ToString() + "]");
            Response.Write("<script>alert('Archivo JSON generado')</script>");
        }
    }
}
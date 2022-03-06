using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

public partial class Login : System.Web.UI.Page
{
    /*Esto hace referencia al string de conexion que guardamos en el WebConfig 
    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
     */
    protected void Page_Load(object sender, EventArgs e) 
    {

        Session["Usuario"] = null;

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        try
        {

            LogUsuario logusu = new LogUsuario();
            Usuario usuario = logusu.Logueo(txtUsu.Text.Trim(), txtClave.Text.Trim());
            if (usuario != null)
            {
                Session["Usuario"] = usuario;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMensaje.Text = "Los datos son incorrectos.";
            }



        }
        catch (Exception ex) 
        {
            lblMensaje.Text = ex.Message;
        }

    }
}
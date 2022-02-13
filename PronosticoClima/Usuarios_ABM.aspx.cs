using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;

public partial class Usuarios_ABM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpiarFormulario();
    }







    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario usuario = new Usuario(txtNombreUsuario.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtClave.Text.Trim());
            LogUsuario logusuario = new LogUsuario();
            logusuario.RegistrarUsuario(usuario);
            LimpiarFormulario();
            lblMensaje.Text = " Usuario agregado con éxito";
        } 
        catch (Exception ex) 
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;

        } 
    
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try 
        {

            lblMensaje.Text = string.Empty;
            string logueo= txtNombreUsuario.Text.Trim();
            LogUsuario logusuario = new LogUsuario();
            Usuario usuario = logusuario.Buscar(logueo);
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtClave.Text = usuario.Contrasenia;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
          

        }
        catch (Exception ex) 
        {
            lblMensaje.Text = ex.Message;
            btnAgregar.Enabled = true;
            


        } 
        finally 
        
        {
         
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtClave.Enabled = true;
            txtNombreUsuario.Enabled = false;
            txtNombre.Focus();
        }

    }



    protected void LimpiarFormulario() 
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        txtNombreUsuario.Enabled = true;
        txtNombreUsuario.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtClave.Text = string.Empty;
        txtNombreUsuario.Focus();

    }
}
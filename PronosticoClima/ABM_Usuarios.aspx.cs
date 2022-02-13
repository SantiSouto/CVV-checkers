using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;
public partial class ABM_Usuarios : System.Web.UI.Page
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

        }
        catch (Exception ex)
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;

        }
        finally
        {
            txtNombreUsuario.Enabled = true;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtClave.Enabled = false;
            txtNombreUsuario.Focus();
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text = string.Empty;
            Usuario usuario = new Usuario(txtNombreUsuario.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtClave.Text.Trim());
            LogUsuario logusuario = new LogUsuario();
            logusuario.Editar(usuario);

        }
        catch (Exception ex)
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;

        }
        finally
        {
            txtNombreUsuario.Enabled = true;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtClave.Enabled = false;
            txtNombre.Focus();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text = string.Empty;
            string logueo = txtNombreUsuario.Text.Trim();
            LogUsuario logusuario = new LogUsuario();
            logusuario.Eliminar(logueo);

        }
        catch (Exception ex)
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;
        }
        finally
        {
            txtNombreUsuario.Enabled = true;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtClave.Enabled = false;
            txtNombreUsuario.Focus();

        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            LimpiarFormulario();
            lblMensaje.Text = string.Empty;
            string logueo = txtNombreUsuario.Text.Trim();
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
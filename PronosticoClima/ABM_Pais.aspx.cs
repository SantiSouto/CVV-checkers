using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;
public partial class ABM_Pais : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpiarFormulario();
    }









    protected void LimpiarFormulario()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        txtCodPais.Enabled = true;
        txtCodPais.Text = string.Empty;
        txtNombrePais.Text = string.Empty;
        lblMensaje.Text = string.Empty;
        txtCodPais.Focus();

    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {

        LimpiarFormulario();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text = string.Empty;
            string cod = txtCodPais.Text.Trim();

            LogPais logpais = new LogPais();
            Pais pais = logpais.Buscar(cod);
            txtCodPais.Text = pais.CodigoPais;
            txtNombrePais.Text = pais.Nombre;
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
            txtCodPais.Enabled = false;
            txtNombrePais.Enabled = true;
            txtNombrePais.Focus();
        }
    }





    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais pais = new Pais(txtCodPais.Text.Trim(), txtNombrePais.Text.Trim());
            LogPais logpais = new LogPais();
            logpais.RegistrarPais(pais);
            LimpiarFormulario();

        }
        catch (Exception ex)
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;

        }
        finally
        {
            txtCodPais.Enabled = true;
            txtNombrePais.Enabled = false;
            txtCodPais.Focus();
        }
    }




    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text = string.Empty;
            Pais pais = new Pais(txtCodPais.Text.Trim(), txtNombrePais.Text.Trim());
            LogPais logpais = new LogPais();
            logpais.EditarPais(pais); 
     
        }
        catch (Exception ex)
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;

        }
        finally
        {
            txtCodPais.Enabled = true;
            txtNombrePais.Enabled = true;
            txtCodPais.Focus();

        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text = string.Empty;

            string cod = txtCodPais.Text.Trim();
            LogPais logpais = new LogPais();
            logpais.Eliminar(cod);
       

        }
        catch (Exception ex)
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;
        }
        finally
        {
            txtCodPais.Enabled = true;
            txtNombrePais.Enabled = true;
            txtCodPais.Focus();

        }
    }
}
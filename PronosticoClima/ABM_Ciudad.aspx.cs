using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

public partial class ABM_Ciudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpiarFormulario();

    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }



    protected void LimpiarFormulario() 
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        txtCodCiudad.Enabled = true;
        txtCodCiudad.Text = string.Empty;
        txtNombreCiudad.Text = string.Empty;
        txtCodigoPais.Text = string.Empty;
        lblMensaje.Text = string.Empty;
        txtCodCiudad.Focus();
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {

        try
        {
            lblMensaje.Text = string.Empty;
            string cod = txtCodCiudad.Text.Trim();
            LogicaCiudad logciudad = new LogicaCiudad();
            Ciudad ciudad = logciudad.Buscar(cod);
            txtCodCiudad.Text = ciudad.Codigociudad;
            txtNombreCiudad.Text = ciudad.NombreCiudad;
            txtCodigoPais.Text = ciudad.Pais.CodigoPais;
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
            txtCodCiudad.Enabled = false;
            txtNombreCiudad.Enabled = true;
            txtCodigoPais.Enabled = true;
            txtNombreCiudad.Focus();
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            LogPais logpais = new LogPais();
            string cod = txtCodigoPais.Text.Trim();
            Pais pais = logpais.Buscar(cod);
            Ciudad ciudad = new Ciudad(txtCodCiudad.Text.Trim() , txtNombreCiudad.Text.Trim(), pais);
            LogicaCiudad logciudad = new LogicaCiudad();
            logciudad.RegistrarCiudad(ciudad, pais);
            LimpiarFormulario();

        }
        catch (Exception ex)
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;

        }
        finally
        {
            txtCodCiudad.Enabled = true;
            txtNombreCiudad.Enabled = false;
            txtCodigoPais.Enabled = false;
            txtCodCiudad.Focus();
        }
    }







    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text = string.Empty;
            LogPais logpais = new LogPais();
            string cod = txtCodigoPais.Text.Trim();
            Pais pais = logpais.Buscar(cod);
            Ciudad ciudad = new Ciudad(txtCodCiudad.Text.Trim(), txtNombreCiudad.Text.Trim(), pais);
            LogicaCiudad logciudad = new LogicaCiudad();
            logciudad.EditarCiudad(ciudad, pais);

        }
        catch (Exception ex)
        {
            LimpiarFormulario();
            lblMensaje.Text = ex.Message;

        }
        finally
        {
            txtCodCiudad.Enabled = true;
            txtNombreCiudad.Enabled = false;
            txtCodigoPais.Enabled = false;
            txtCodCiudad.Focus();

        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }
}
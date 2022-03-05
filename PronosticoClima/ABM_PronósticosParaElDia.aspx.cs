using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

public partial class ABM_PronósticosParaElDia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    private void LimpioFormulario()
    {


        txtFecha.Text = "";
        lblMensaje.Text = "";

       grdpronosticosdeldia.Columns.Clear();
       grdpronosticosdeldia.DataBind();

    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {

        lblMensaje.Text = string.Empty;
        if (txtFecha.Text.Trim() == string.Empty)
            throw new Exception("Ingrese una fecha");

        try
        {

            DateTime fecha = Convert.ToDateTime(txtFecha.Text);

            fecha = Convert.ToDateTime(txtFecha.Text.Trim());
            LogPronostico logpronostico = new LogPronostico();
            List<Pronostico> pronosticos = logpronostico.PronosticosPorFecha(fecha);


            grdpronosticosdeldia.DataSource = pronosticos;
            grdpronosticosdeldia.DataBind();

            if ( pronosticos.Any() is false)
            {

                lblMensaje.Text = "No existe Pronosticos para esa fecha";
            }

        }



        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
        finally
        {
            btnBuscar.Enabled = true;
            btnLimpiar.Enabled = true;
        }
       
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}
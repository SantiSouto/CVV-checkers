using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

public partial class ABM_PronosticoPorCiudad : System.Web.UI.Page
{
    LogPais logpais = new LogPais();
    LogicaCiudad logicaCiudad = new LogicaCiudad();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        if (!IsPostBack)
        {

            LogPais logpais = new LogPais();

            ddlPais.DataSource = logpais.TodosLosPaises();
            ddlPais.DataValueField = "CODIGOPAIS";
            ddlPais.DataTextField = "NOMBRE";

            ddlPais.DataBind();

        }
    }

        
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
     

            string paiselegido = ddlPais.SelectedValue;    
        Pais pais = logpais.Buscar(paiselegido);


        LogicaCiudad logciudad = new LogicaCiudad();

        grdciudadporpais.DataSource = logciudad.TodosLasCiudades(pais);
        grdciudadporpais.DataBind();

    }

    protected void grdciudadporpais_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string codciudad = grdciudadporpais.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;             
        string paiselegido = ddlPais.SelectedValue;   
        Pais pais = logpais.Buscar(paiselegido);
        Ciudad ciudad = logicaCiudad.Buscar(codciudad,paiselegido);
      
        LogPronostico pronosticos = new LogPronostico();
        grdPronosticoDeCiudad.DataSource = pronosticos.PronosticosPorCiudad(ciudad);
        grdPronosticoDeCiudad.DataBind();
    }



    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
     
        grdPronosticoDeCiudad.Columns.Clear();
        grdPronosticoDeCiudad.DataBind();
    }
}
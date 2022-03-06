using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Entidades;

public partial class Registrar_Pronostico : System.Web.UI.Page
{

    static string codigociudad;
    static string codigopais;
    private int codigointerno;
    LogicaCiudad logicaCiudad = new LogicaCiudad();
    LogPais logPais = new LogPais();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarddlPais();

        }
    }



    protected void LlenarddlPais()
    {
        LogPais logPais = new LogPais();
        ddlPais.DataSource = logPais.TodosLosPaises();

        ddlPais.DataValueField = "CODIGOPAIS";
        ddlPais.DataBind();
    }



    protected void LlenargrdCiuadad()
    {



        string paisbuscado = ddlPais.SelectedValue;
        Pais pais = logPais.Buscar(paisbuscado);
        grdCiudades.DataSource = logicaCiudad.CiudadPorPais(pais);

        grdCiudades.DataBind();
    }

    protected void Limpiar()
    {
        txtNombreUsuario.Text = "";
        txtFechHora.Text = "";
        txtProbLluvia.Text = "";
        txtProbTormenta.Text = "";
        txtTMax.Text = "";
        txtTMin.Text = "";
        txtVelViento.Text = "";
        grdCiudades.Columns.Clear();
        grdCiudades.DataBind();



    }




    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            LogUsuario logUsuario = new LogUsuario();
            Usuario usuario = logUsuario.Buscar(txtNombreUsuario.Text);
            LogicaCiudad logicaciudad = new LogicaCiudad();
            Ciudad ciudad = logicaciudad.Buscar(codigociudad, codigopais);



            Pronostico pronostico = new Pronostico(codigointerno, ciudad, usuario, Convert.ToInt32(txtTMax.Text.Trim()),
            Convert.ToInt32(txtTMin.Text.Trim()), Convert.ToDateTime(txtFechHora.Text),
            Convert.ToInt32(txtVelViento.Text.Trim()), ddlTipoCielo.SelectedValue.ToString(),
            Convert.ToInt32(txtProbLluvia.Text.Trim()), Convert.ToInt32(txtProbTormenta.Text.Trim()));



            LogPronostico logPronostico = new LogPronostico();
            logPronostico.RegistrarPronostico(pronostico);
            if (pronostico != null)



                lblMensaje.Text = "Pronostico Registrado";




        }
        catch (Exception Ex)
        {
            lblMensaje.Text = Ex.Message;
        }





    }





    protected void btn_BuscarPais_Click(object sender, EventArgs e)
    {
        LlenargrdCiuadad();
    }









    protected void grdCiudades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        codigociudad = grdCiudades.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        codigopais = ddlPais.SelectedValue;
    }



    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }
}


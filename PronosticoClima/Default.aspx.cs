using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


      


        LogPronostico logPronostico = new LogPronostico();
        grdpronosticosdeldia.DataSource = logPronostico.PronosticoDiario();
        grdpronosticosdeldia.DataBind();
      
    }


  
}
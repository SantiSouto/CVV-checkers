
  <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM_PronosticoPorCiudad.aspx.cs" Inherits="ABM_PronosticoPorCiudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            max-width: 1320px;
            text-align: center;
            margin-left: auto;
            margin-right: auto;
            padding-left: var(--bs-gutter-x, .75rem);
            padding-right: var(--bs-gutter-x, .75rem);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
          <center>
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <center> 

              
                <div class="row">
                       <div class="row">
                <div class="col">
                    <center>
                        <h3>
                          
                        </h3>
                        <h3>Pronosticos por Ciudad: </h3>
                    </center>
                    <hr />
                        <div class="auto-style1">

                            Pais<br />
                            &nbsp<asp:DropDownList ID="ddlPais" runat="server">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <br />
&nbsp;<asp:Button class="btn btn-outline-primary" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  />

                        </div>




                <center> 

              
                <center> 

              
          <center>
          <center>




                            <br />




                            <br />
&nbsp;Ciudad<br />




                            <br />




                          <asp:GridView ID="grdciudadporpais" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnRowCommand="grdciudadporpais_RowCommand">
                              <Columns>
                                  <asp:CommandField ShowSelectButton="True" />
                              </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#35b58a" Font-Bold="True" ForeColor="#b6ff00" />
            <PagerStyle BackColor="#35b58a" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
                    <br />
                    Pronostico<br />




                          <asp:GridView ID="grdPronosticoDeCiudad" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#35b58a" Font-Bold="True" ForeColor="#b6ff00" />
            <PagerStyle BackColor="#35b58a" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
                            <br />
                            <asp:Button class="btn btn-outline-primary" ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click"  />
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                           </div>
                </div>
                               </div>
  </asp:Content>
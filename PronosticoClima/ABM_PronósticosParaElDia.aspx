  <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM_PronósticosParaElDia.aspx.cs" Inherits="ABM_PronósticosParaElDia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/iconos/calendariapordia.png" />
                        </h3>
                        <h3>Pronosticos para el dia: </h3>
                    </center>
                    <hr />
                        <div class="container-sm">

                            <asp:Label class="form-label" runat="server" ID="lblFecha">FECHA</asp:Label>
                            &nbsp
                                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>

                        </div>




                            <br />




                            <br />
            <asp:Button class="btn btn-outline-primary" ID="btnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click"  />
&nbsp;<asp:Button class="btn btn-outline-primary" ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click"  />
                            <br />




                            <br />




                          <asp:GridView ID="grdpronosticosdeldia" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
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
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                           </div>
                </div>
                               </div>
  </asp:Content>
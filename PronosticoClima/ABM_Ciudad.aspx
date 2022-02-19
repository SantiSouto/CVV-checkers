<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM_Ciudad.aspx.cs" Inherits="ABM_Ciudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
          <center>
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <center> 

              
                <div class="row">
                    <center>
                        <img src="iconos/Ciudad.png">
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <center>
                        <h3>Ciudades</h3>
                    </center>
                    <hr />

                </div>
            </div>
            <div class="row">
                <div class="col">
                    <center>


                        <div class="container-sm">

                            <asp:Label class="form-label" runat="server" ID="lblCodCiudad">Código Ciudad</asp:Label>
                            &nbsp
                                <asp:TextBox ID="txtCodCiudad" runat="server"></asp:TextBox>

                        </div>
                        <div class="container-sm">
                            <asp:Label class="form-label" runat="server" ID="lblNomCiudad">Nombre Ciudad</asp:Label>
                            &nbsp
                                <asp:TextBox ID="txtNombreCiudad" runat="server"></asp:TextBox>
                        </div>
                        <div class="container-sm">
                            <asp:Label class="form-label" runat="server" ID="lblCodigoPais">Código País</asp:Label>
                            &nbsp
                                <asp:TextBox ID="txtCodigoPais" runat="server"></asp:TextBox>

                        </div>
                        <br />
                        <div class="container-sm">
                           
                           
                            <asp:Button class="btn btn-outline-primary" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"  />  
                            <asp:Button class="btn btn-outline-primary" ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"   />     
                            <asp:Button class="btn btn-outline-primary" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"  />
                            <br>
                            <br>
                            <asp:Button class="btn btn-outline-primary" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  />
                            <asp:Button class="btn btn-outline-primary" ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                          <br>
                           <br>

                        </div>
                    </center>

                    <div>
                        <hr />
                        <center>
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        </center>
                        <p></p>
                        <p></p>
                    </div>
                </div>
            </div>

        </div>
              </center>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM_Pais.aspx.cs" Inherits="ABM_Pais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
          <center>
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <center> 

              
                <div class="row">
                    <center>
                        <img src="iconos/Pais2.png">
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <center>
                        <h3>Países</h3>
                    </center>
                    <hr />

                </div>
            </div>
            <div class="row">
                <div class="col">
                    <center>


                        <div class="container-sm">

                            <asp:Label class="form-label" runat="server" ID="lblCodPais">Código País</asp:Label>
                            &nbsp
                                <asp:TextBox ID="txtCodPais" runat="server"></asp:TextBox>

                        </div>
                        <div class="container-sm">
                            <asp:Label class="form-label" runat="server" ID="lblNomPais">Nombre</asp:Label>
                            &nbsp
                                <asp:TextBox ID="txtNombrePais" runat="server"></asp:TextBox>
                        </div>
                        <div class="container-sm">
                        </div>
                        <br />
                        <div class="container-sm">
                           
                           
                            <asp:Button class="btn btn-outline-primary" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"  />  
                            <asp:Button class="btn btn-outline-primary" ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"  />     
                            <asp:Button class="btn btn-outline-primary" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                            <br>
                            <br>
                            <asp:Button class="btn btn-outline-primary" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  />
                            <asp:Button class="btn btn-outline-primary" ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click"  />
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


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABM_Usuarios.aspx.cs" Inherits="ABM_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <div class="row">
                            <center>
                                <img width="64px" src="iconos/iconoUsuario.png">
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Usuario</h3>
                            </center>
                            <hr />

                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                             
                        
                                 <div class="container-sm">
                        
                                <asp:label class="form-label" runat="server">Nombre Usuario</asp:label> &nbsp
                                <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                         
                           </div>
                                <div class="container-sm">
                               <asp:label class="form-label" runat="server">Nombre </asp:label> &nbsp
                                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            </div>
                                <div class="container-sm">
                                      <asp:label class="form-label" runat="server">Apellido </asp:label> &nbsp
                                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                            </div>
                            <div class="container-sm">
                                    <asp:label class="form-label" runat="server">Contraseña </asp:label> &nbsp
                                <asp:TextBox type="password" ID="txtClave" runat="server"></asp:TextBox>
                            </div>
                                <br />
                                 <div class="container-sm">
               
                          
                                    <asp:Button class="btn btn-outline-primary" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"  />
                                    <asp:Button class="btn btn-outline-primary" ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"  />
                                    <asp:Button class="btn btn-outline-primary" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                                     <br />
                                     <br />
                                    <asp:Button class="btn btn-outline-primary" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"  />
                          
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     <asp:ImageButton ID="btnLimpiar" runat="server" ImageUrl="~/iconos/icons8-broom-64.png" />
                          
                                     </div>
                            </center>

                            <div>
                                <hr />
                                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                <p> </p>
                                <p> </p>
                            </div>



                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>


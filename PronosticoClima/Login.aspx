 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <div class="row">
                            <center>
                                <img width="64px" src="Icons/iconoUsuario.png">
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Login Usuario</h3>
                            </center>
                            <hr />

                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                            </center>

                            <div class="mb-3">
                                <label for="exampleInputEmail1" class="form-label">Nombre de Usuario</label>
                                <input type="email" class="form-control" id="inputUsuarioNombre">
                            </div>
                            <div class="mb-3">
                                <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                                <input type="password" class="form-control" id="inputClave">
                            </div>
                            <center>
                          
                                <asp:Button ID="btnLogin" CssClass="btn-success btn-block btn-lg"  runat="server" Text="Entrar" OnClick="btnLogin_Click" />
                          
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


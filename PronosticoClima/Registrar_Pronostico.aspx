<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registrar_Pronostico.aspx.cs" Inherits="Registrar_Pronostico" %>

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
                                <img src="iconos/RegistrarPronostico.png">
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Registrar Pronostico</h3>
                                <p>
                                    &nbsp;
                                </p>
                            </center>
                            <p class="auto-style2">
                                &nbsp;Pais&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlPais" runat="server">
                                </asp:DropDownList>
                            </p>
                            <p class="auto-style2">
                                <asp:Button class="btn btn-outline-primary" ID="btn_BuscarPais" runat="server" Text="Buscar ciudades del Pais" OnClick="btn_BuscarPais_Click" />
                            </p>
                            <div>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style3">&nbsp;</td>
                                        <td class="text-center">

                                            <asp:GridView ID="grdCiudades" runat="server" AutoGenerateSelectButton="True" CellPadding="4" GridLines="None" OnRowCommand="grdCiudades_RowCommand" ForeColor="#333333">
                                                <AlternatingRowStyle BackColor="White" />
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                            </asp:GridView>

                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                                &nbsp;
                            </div>
                            <hr />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <div class="container-sm">
                                    Fecha y Hora&nbsp;
                                    <asp:TextBox ID="txtFechHora" runat="server"></asp:TextBox>
                                </div>
                                <div class="container-sm">
                                    Temperatura Máxima&nbsp
                                    <asp:TextBox ID="txtTMax" runat="server"></asp:TextBox>
                                </div>
                                <div class="container-sm">
                                    Temperatura Mínima&nbsp
                                    <asp:TextBox ID="txtTMin" runat="server"></asp:TextBox>
                                </div>
                                <div class="container-sm">
                                    Velocidad del Viento km/h&nbsp
                                    <asp:TextBox ID="txtVelViento" runat="server"></asp:TextBox>
                                    <br />
                                    <br />
                                </div>
                                Tipo de cielo
                                <asp:DropDownList ID="ddlTipoCielo" runat="server">
                                    <asp:ListItem Value="Nuboso">Nuboso</asp:ListItem>
                                    <asp:ListItem Value="Parcialmente Nuboso">Parcialmente Nuboso</asp:ListItem>
                                    <asp:ListItem Value="Despejado">Despejado</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <br />
                                Probabilidad de Lluvia
                                <asp:TextBox ID="txtProbLluvia" runat="server"></asp:TextBox>
                                <br />
                                Probabilidad de Tormenta
                                <asp:TextBox ID="txtProbTormenta" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <div class="container-sm">
                                    <asp:Button class="btn btn-outline-primary" ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button class="btn btn-outline-primary" ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <br />
                                    <br />
                                    Nombre de Usuario<asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                                </div>
                            </center>
                            <div>
                                <hr />
                                <center>
                                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                </center>
                                <p>
                                </p>
                                <p>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


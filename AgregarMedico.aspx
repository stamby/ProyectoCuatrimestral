<%@ Page Title="Agregar un Medico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="ProyectoCuatrimestral.AgregarMedico" %>
<asp:Content ID="AgregarMedicoContenido" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />

    <div>
        <div>
            <asp:Label Text="Nombre:" runat="server" />
            <asp:TextBox ID="txtNombre" runat="server" />
        </div>
        <br />
        <div>
            <asp:CheckBox ID="chkAdmin" Text="Administrador" runat="server" />
        </div>
        <div>
            <asp:CheckBox ID="chkComprar" Text="Puede Comprar" runat="server" />
        </div>
        <div>
            <asp:CheckBox ID="chkVender" Text="Puede Vender" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="Clave:" runat="server" />
            <asp:TextBox ID="txtClave" runat="server" />
            <asp:Button CssClass="btn btn-secondary" ID="btnGenerar" Text="Generar" OnClick="btnGenerar_Click" runat="server" />
        </div>
    </div>

    <hr />

    <div>
        <asp:Button CssClass="btn btn-primary" Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
    </div>
</asp:Content>

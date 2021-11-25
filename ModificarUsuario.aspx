<%@ Page Title="Modificar un Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="ProyectoCuatrimestral.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />
    
    <div>
        <div>
            <asp:Label Text="ID: " runat="server" />
            <asp:Label ID="lblID" runat="server" />
        </div>
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
            <asp:Label Text="Nueva clave (dejar en blanco para mantener la actual):" runat="server" />
            <asp:TextBox ID="txtClave" runat="server" />
            <asp:Button CssClass="btn btn-secondary" ID="btnGenerar" Text="Generar" OnClick="btnGenerar_Click" runat="server" />
        </div>
    </div>
    
    <hr />

    <div>
        <asp:Button CssClass="btn btn-primary" Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
    </div>
</asp:Content>

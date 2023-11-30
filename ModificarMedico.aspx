<%@ Page Title="Modificar Médico o Administrador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="ProyectoCuatrimestral.ModificarMedico" %>

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
        <br />
        <div>
            <asp:Label Text="Nombre:" runat="server" />
            <asp:TextBox ID="txtNombre" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="Apellido:" runat="server" />
            <asp:TextBox ID="txtApellido" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="Especialidad:" runat="server" />
            <asp:DropDownList ID="ddlEspecialidades" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Label Text="E-Mail:" runat="server" />
            <asp:TextBox ID="txtUsuario" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="Clave:" runat="server" />
            <asp:TextBox ID="txtClave" TextMode="Password" runat="server" />
        </div>
    </div>

    <hr />

    <div>
        <asp:Button CssClass="btn btn-primary" Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
    </div>
</asp:Content>

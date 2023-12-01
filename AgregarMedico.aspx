<%@ Page Title="Agregar Médico o Administrador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="ProyectoCuatrimestral.AgregarMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />

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
        <asp:Label Text="Usuario:" runat="server" />
        <asp:TextBox ID="txtUsuario" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label Text="Clave:" runat="server" />
        <asp:TextBox ID="txtClave" TextMode="Password" runat="server" />
    </div>
    <br />
    <hr />
    <div>
        <asp:Button CssClass="btn btn-primary" Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
    </div>
</asp:Content>

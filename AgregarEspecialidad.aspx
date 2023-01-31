<%@ Page Title="Agregar una Especialidad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEspecialidad.aspx.cs" Inherits="ProyectoCuatrimestral.AgregarEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />

    <div>
        <asp:Label Text="Nombre:" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" />
    </div>

    <hr />

    <div>
        <asp:Button CssClass="btn btn-primary" Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
    </div>
</asp:Content>

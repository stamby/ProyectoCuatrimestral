<%@ Page Title="Modificar Marca" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarMarca.aspx.cs" Inherits="ProyectoCuatrimestral.ModificarMarca" %>
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
    </div>
    
    <hr />

    <div>
        <asp:Button CssClass="btn btn-primary" Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
    </div>
</asp:Content>

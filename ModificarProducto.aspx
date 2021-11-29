<%@ Page Title="Modificar un Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="ProyectoCuatrimestral.ModificarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />

    <div>
        <asp:Label Text="ID: " runat="server" />
        <asp:Label ID="lblID" runat="server" />
    </div>

    <br />

    <div>
        <asp:Label Text="Título:" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" />
    </div>

    <br />

    <div>
        <asp:Label Text="Marca:" runat="server" />
        <asp:DropDownList ID="MarcaDropdownList" runat="server">
        </asp:DropDownList>
    </div>

    <br />

    <div>
        <asp:Label Text="Descripción:" runat="server" />
        <asp:TextBox ID="txtDescripcion" runat="server" />
    </div>

    <br />

    <div>
        <asp:Label Text="Unidades:" runat="server" />
        <asp:TextBox ID="txtUnidades" runat="server" />
    </div>
    
    <br />

    <div>
        <asp:Label Text="Precio: $" runat="server" />
        <asp:TextBox ID="txtPrecio" runat="server" />
    </div>

    <br />

    <div>
        <asp:Label Text="Ilustración (enlace):" runat="server" />
        <asp:TextBox ID="txtIlustracion" runat="server" />
    </div>
    
    <hr />

    <div>
        <asp:Button CssClass="btn btn-primary" Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" runat="server" />
    </div>
</asp:Content>

<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ProyectoCuatrimestral.Usuarios" %>
<asp:Content ID="UsuariosContenido" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />
    
    <div class="card">
        <asp:Button ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" runat="server" />
    </div>

    <hr />

    <asp:GridView ID="UsuariosGrilla" CssClass="table" runat="server" AutoGenerateColumns="false" CellPadding="6">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Usuario" />
            <asp:BoundField DataField="PermisoAdmin" HeaderText="Administrador" />
            <asp:BoundField DataField="PermisoComprar" HeaderText="Puede Comprar" />
            <asp:BoundField DataField="PermisoVender" HeaderText="Puede Vender" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:Button CommandName="Modificar" ID="btnModificar" OnClick="btnModificar_Click" Text="Modificar" runat="server" />
                    <asp:Button CommandName="Borrar" ID="btnBorrar" OnClick="btnBorrar_Click" Text="Borrar" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

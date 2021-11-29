<%@ Page Title="Mis Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="ProyectoCuatrimestral.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>
    
    <hr />
    
    <div class="card">
        <asp:Button CssClass="btn btn-primary" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" runat="server" />
    </div>

    <hr />
    
    <asp:GridView ID="ProductosGrilla" CssClass="table" runat="server" AutoGenerateColumns="false" CellPadding="6">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="MarcaProducto" HeaderText="Marca" />
            <asp:BoundField DataField="Nombre" HeaderText="Título" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataFormatString="{0:C}" DataField="PrecioLista" HeaderText="Precio" />
            <asp:BoundField DataField="Unidades" HeaderText="Unidades (Stock)" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-secondary" CommandName="Ver y Modificar" ID="btnModificar" OnClick="btnModificar_Click" Text="Modificar" runat="server" />
                    <asp:Button CssClass="btn btn-danger" CommandName="Borrar" ID="btnBorrar" OnClick="btnBorrar_Click" Text="Borrar" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

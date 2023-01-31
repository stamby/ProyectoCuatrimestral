<%@ Page Title="Medicos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="ProyectoCuatrimestral.Medicos" %>
<asp:Content ID="MedicosContenido" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />
    
    <div class="card">
        <asp:Button CssClass="btn btn-primary" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" runat="server" />
    </div>

    <hr />

    <asp:GridView ID="MedicosGrilla" CssClass="table" runat="server" AutoGenerateColumns="false" CellPadding="6">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Apellido" HeaderText="Nombre" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Especialidad" HeaderText="Nombre" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-secondary" CommandName="Modificar" ID="btnModificar" OnClick="btnModificar_Click" Text="Modificar" runat="server" />
                    <asp:Button CssClass="btn btn-danger" CommandName="Borrar" ID="btnBorrar" OnClick="btnBorrar_Click" Text="Borrar" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

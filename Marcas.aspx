<%@ Page EnableEventValidation="false" Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="ProyectoCuatrimestral.Marcas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>-->
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />
    
    <div class="card">
        <asp:Button CssClass="btn btn-primary" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" runat="server" />
    </div>

    <hr />

    <asp:GridView ID="MarcasGrilla" CssClass="table" runat="server" AutoGenerateColumns="false" CellPadding="6">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Marca" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-secondary" CommandName="Modificar" ID="btnModificar" OnClick="btnModificar_Click" Text="Modificar" runat="server" />
                    <asp:Button CssClass="btn btn-danger" CommandName="Borrar" ID="btnBorrar" OnClick="btnBorrar_Click" Text="Borrar" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

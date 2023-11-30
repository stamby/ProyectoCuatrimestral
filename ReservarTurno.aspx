<%@ Page Title="Reservar Turno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReservarTurno.aspx.cs" Inherits="ProyectoCuatrimestral.ReservarTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />

    <div>
        <asp:Label Text="Filtrar por Médico:" runat="server" />
        <asp:DropDownList ID="ddlMedicos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged">
            <asp:ListItem Value="0">Todos</asp:ListItem>
        </asp:DropDownList>
    </div>

    <div>
        <asp:Label Text="Filtrar por Especialidad:" runat="server" />
        <asp:DropDownList ID="ddlEspecialidades" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged">
            <asp:ListItem Value="0">Todas</asp:ListItem>
        </asp:DropDownList>
    </div>

    <hr />

    <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="false" EnableViewState="true" AutoPostBack="true">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Medico.Especialidad.Nombre" HeaderText="Especialidad" />
            <asp:BoundField DataField="HoraDesde" HeaderText="De" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            <asp:BoundField DataField="HoraHasta" HeaderText="A" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            <asp:BoundField DataField="Medico" HeaderText="Médico" />
            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-primary" ID="btnReservar" OnClick="btnReservar_Click" Text="Reservar" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

<%@ Page EnableEventValidation="false" Title="Turnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendaPaciente.aspx.cs" Inherits="ProyectoCuatrimestral.AgendaPaciente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>-->
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />
    
    <div class="card">
        <asp:Button CssClass="btn btn-primary" ID="btnReservarTurno" Text="Reservar Turno" OnClick="btn_ReservarTurno_Click" runat="server" />
    </div>

    <hr />

    <asp:GridView ID="GrillaAgendaPaciente" CssClass="table" runat="server" AutoGenerateColumns="false" CellPadding="6">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="HoraDesde" HeaderText="De" />
            <asp:BoundField DataField="HoraHasta" HeaderText="A" />
            <asp:BoundField DataField="Medico.Nombre" HeaderText="Profesional" />
            <asp:BoundField DataField="Medico.Especialidad" HeaderText="Especialidad" />

            <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-danger" CommandName="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" Text="Cancelar" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblAbajo" Visible="false" Text="No posee ningún turno vigente." runat="server" />
</asp:Content>

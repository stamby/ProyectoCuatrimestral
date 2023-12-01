<%@ Page Title="Confirmar Reserva" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmarReserva.aspx.cs" Inherits="ProyectoCuatrimestral.ConfirmarReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />

    <div>
        <div><p>Confirmo que deseo presentarme en el área de <strong><%= turno.Medico.Especialidad.Nombre.ToUpper() %>:</strong></p></div>
        <br />
        <div>
            <asp:Label Text="Profesional:" runat="server" />
            <asp:Label ID="lblMedico" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="De:" runat="server" />
            <asp:Label ID="lblHoraDesde" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="A:" runat="server" />
            <asp:Label ID="lblHoraHasta" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="Paciente:" runat="server" />
            <asp:Label ID="lblPaciente" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="Obra Social:" runat="server" />
            <asp:Label ID="lblObraSocial" runat="server" />
        </div>
    </div>

    <hr />

    <div>
        <asp:Button CssClass="btn btn-primary" Text="Confirmar" ID="btnConfirmar" OnClick="btnConfirmar_Click" runat="server" />
        <asp:Button CssClass="btn btn-secondary" Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" runat="server" />
    </div>
</asp:Content>

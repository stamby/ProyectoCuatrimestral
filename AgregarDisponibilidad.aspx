<%@ Page Title="Agregar Disponibilidad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarDisponibilidad.aspx.cs" Inherits="ProyectoCuatrimestral.AgregarDisponibilidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>
    
    <hr />

    <div>
        <asp:Label Text="Agregar 1 (un) turno:" runat="server" />
        <asp:CheckBox ID="chkDomingo" Text="Domingos" Checked="true" runat="server" />
        <asp:CheckBox ID="chkLunes" Text="Lunes" Checked="true" runat="server" />
        <asp:CheckBox ID="chkMartes" Text="Martes" Checked="true" runat="server" />
        <asp:CheckBox ID="chkMiercoles" Text="Miércoles" Checked="true" runat="server" />
        <asp:CheckBox ID="chkJueves" Text="Jueves" Checked="true" runat="server" />
        <asp:CheckBox ID="chkViernes" Text="Viernes" Checked="true" runat="server" />
        <asp:CheckBox ID="chkSabado" Text="Sábados" Checked="true" runat="server" />
    </div>
    
    <br />

    <div>
        <asp:Label Text="Entre los días:" runat="server" />
        <asp:TextBox ID="txtDiaDesde" TextMode="Date" runat="server" />
        <asp:TextBox ID="txtDiaHasta" TextMode="Date" runat="server" />
    </div>

    <br />

    <div>
        <asp:Label Text="Comienzo del turno:" runat="server" />
        <asp:TextBox ID="txtHoraDesde" TextMode="Time" runat="server" />
    </div>
    
    <br/>
    
    <div>
        <asp:Label Text="Fin del turno:" runat="server" />
        <asp:TextBox ID="txtHoraHasta" TextMode="Time" runat="server" />
    </div>

    <hr />

    <div>
        <asp:Button CssClass="btn btn-primary" Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
    </div>
</asp:Content>

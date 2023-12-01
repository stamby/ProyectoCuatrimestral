<%@ Page Title="Mi Agenda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendaMedico.aspx.cs" Inherits="ProyectoCuatrimestral.AgendaMedico" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>-->
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />
    
    <div class="card">
        <asp:Button CssClass="btn btn-primary" ID="btnAgregar" Text="Agregar disponibilidad" OnClick="btnAgregar_Click" runat="server" />
    </div>

    <hr />

    <asp:Calendar ID="Calendario" FirstDayOfWeek="Sunday" runat="server"
        Height="100%" Width="100%" BorderWidth="1px" DayNameFormat="Full"
        OnDayRender="Calendario_DayRender" TodayDayStyle-ForeColor="#FF0000" >
    </asp:Calendar>
    
    <hr />

    <div>
        <asp:GridView ID="GrillaTurnos" CssClass="table" runat="server" AutoGenerateColumns="false" CellPadding="6" EnableViewState="true" AutoPostBack="true" OnRowCommand="GrillaTurnos_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Identificación" />
                <asp:BoundField DataField="HoraDesde" HeaderText="De" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                <asp:BoundField DataField="HoraHasta" HeaderText="A" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" NullDisplayText="<em>Sin reservar</em>" />
                <asp:BoundField DataField="Paciente.ObraSocial" HeaderText="Obra Social" NullDisplayText="<em>Sin reservar</em>" />
            </Columns>
        </asp:GridView>
        
        <asp:Label ID="lblAbajo" Text="Seleccione una fecha en el calendario para ver su disponibilidad." runat="server" />
    </div>
</asp:Content>
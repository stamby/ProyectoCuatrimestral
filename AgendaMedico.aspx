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
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                <asp:TemplateField HeaderText="Opciones">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-secondary" ID="btnVer" Text="Ver detalles" CommandName="VerTurno" runat="server" />
                        <asp:Button CssClass="btn btn-danger" ID="btnCancelarTurno" Text="Cancelar turno" CommandName="CancelarTurno" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <asp:Label ID="lblAbajo" Text="Seleccione una fecha en el calendario para ver su disponibilidad." runat="server" />
    </div>
</asp:Content>

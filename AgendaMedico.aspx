<%@ Page EnableEventValidation="false" Title="Mi Agenda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendaMedico.aspx.cs" Inherits="ProyectoCuatrimestral.AgendaMedico" %>

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

    <asp:Calendar ID="Calendario" runat="server"
        Height="100%" Width="100%" BorderWidth="1px" DayNameFormat="Full"
        OnDayRender="Calendario_DayRender" TodayDayStyle-ForeColor="#FF0000" >
    </asp:Calendar>

</asp:Content>

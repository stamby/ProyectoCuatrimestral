﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoCuatrimestral.Registro" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registro - Turnos para Atención</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <div class="container body-content">
            <div>
                <h1>Registrarse como Paciente</h1>
            </div>
            <hr />
            <div>
                <div>
                    <asp:Label Text="Nombre:" runat="server" />
                    <asp:TextBox ID="txtNombre" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label Text="Apellido:" runat="server" />
                    <asp:TextBox ID="txtApellido" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label Text="Obra Social:" runat="server" />
                    <asp:TextBox ID="txtObraSocial" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label Text="E-Mail:" runat="server" />
                    <asp:TextBox ID="txtUsuario" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label Text="Clave:" runat="server" />
                    <asp:TextBox ID="txtClave" TextMode="Password" runat="server" />
                </div>
                <br />
                <hr />
                <asp:Button CssClass="btn btn-secondary" ID="btnRegistrarse" Text="Registrarse" OnClick="btnRegistrarse_Click" runat="server" />
            </div>
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Turnos para Atención</p>
            </footer>
        </div>
    </form>
</body>
</html>

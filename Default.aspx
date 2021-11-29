<%@ Page Title="Catálogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoCuatrimestral._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1><%: Title %></h1>
    </div>

    <hr />

    <div>
        <% foreach (var item in listaProductos)
            { %>
        <div style="display: flex; flex-direction: row; margin: 10px;" class="card" style="width: 18rem;">
            <img src="<%: item.Ilustracion.ToString() %>" class="card-img-top" alt="...">
            <div class="card-body">
                <h3 class="card-title"><%: item.Nombre %></h3>
                <p class="card-text"><%: item.Descripcion %></p>
                <a href="#" class="btn btn-primary"><%: String.Format("{0:C}", item.PrecioLista) %></a>

            </div>
        </div>
         <% } %>
    </div>
    <%--  --%>
</asp:Content>

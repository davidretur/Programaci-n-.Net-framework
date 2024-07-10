<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ADOEstatusAlumnoWebForms.forms.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <dl>
            <dt>
                <asp:Label ID="lblid" runat="server" Text="id"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lbliddef" runat="server" Text=""></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblclave" runat="server" Text="clave"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblclavedef" runat="server" Text=""></asp:Label>
            </dd>
            <dt>
                <asp:Label ID="lblnombre" runat="server" Text="nombre"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblnombredef" runat="server" Text=""></asp:Label>
            </dd>
        </dl>
            <a href="index.aspx">Regresar a la lista</a>
    </div>
</asp:Content>

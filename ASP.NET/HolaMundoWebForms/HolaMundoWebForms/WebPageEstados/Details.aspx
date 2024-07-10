<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="HolaMundoWebForms.WebPageEstados.Details" %>
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
                <asp:Label ID="lblnombre" runat="server" Text="nombre"></asp:Label>
            </dt>
            <dd>
                <asp:Label ID="lblnombredef" runat="server" Text=""></asp:Label>
            </dd>
        </dl>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HolaMundoWebForms.WebPageEstados.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lblEstados" runat="server" Text="Estados"></asp:Label>
    </div>
    <div>
        <asp:DropDownList ID="ddlEstados" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" OnClick="BtnConsultar_Click" />
    </div>

</asp:Content>

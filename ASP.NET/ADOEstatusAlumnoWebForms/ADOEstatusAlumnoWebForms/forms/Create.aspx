<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ADOEstatusAlumnoWebForms.forms.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Agregar Estatus Alumnos"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox ID="TextBoxClave" runat="server"></asp:TextBox>
        <br />
    </div>
        <div>
        <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
        <br />
    </div>
    <br />
    <div>
     <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click1" />
    </div>
    <div>
        <asp:Label ID="LabelResultado" runat="server" Text="Label"></asp:Label>
    </div>



<div>
        <a href="index.aspx">Regresar a la lista</a>
</div>
</asp:Content>

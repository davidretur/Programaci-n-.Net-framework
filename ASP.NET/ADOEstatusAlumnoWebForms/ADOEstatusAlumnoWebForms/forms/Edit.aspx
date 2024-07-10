<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ADOEstatusAlumnoWebForms.forms.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div>
        <asp:Label ID="Label1" runat="server" Text="Actualizar Estatus Alumnos"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Id"></asp:Label>
        <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
        <br />
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
     <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" OnClick="ButtonActualizar_Click" />
    </div>
    <div>
        <asp:Label ID="LabelResultado" runat="server" Text="Label"></asp:Label>
    </div>



<div>
        
</div>
</asp:Content>

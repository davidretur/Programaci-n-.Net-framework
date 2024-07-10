<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ADOEstatusAlumnoWebForms.forms.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <div>
        <asp:Label ID="Label1" runat="server" Text="Actualizar Estatus Alumnos"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Id"></asp:Label>
        <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
        <br />
    </div>
     <br />
    <div>
     <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click"  />
    </div>
    <br />
    <div>
        <asp:Label ID="LabelResultado" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>

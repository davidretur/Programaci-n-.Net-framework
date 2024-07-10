<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.form.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      
    <div class="container mt-5">
    <h2>Estatus de alumnos</h2>
      <asp:Button runat="server" OnClick="Agregar_Click" CssClass="btn btn-sm btn-success" Text="Agregar" />
  </div>
      <div class="container mt-5">
          <asp:GridView ID="GVAlumno" runat="server" CssClass="table table-bordered table-dark" AutoGenerateColumns="false" AllowPaging="true"  PageSize="5" OnPageIndexChanging="GVAlumno_PageIndexChanging">
               <Columns>     
              <asp:BoundField DataField="id" HeaderText="id" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="segundoApellido" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="correo" HeaderText="Correo"/>
                    <asp:BoundField DataField="telefono" HeaderText="Telefono"/>      
                   <asp:BoundField DataField="estado" HeaderText="Estado" />
                   <asp:BoundField DataField="estatus" HeaderText="Estatus" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="btn-group-horizontal">
                               <asp:LinkButton runat="server" CommandArgument='<%# Eval("id") %>'
                                OnClick="Consultar_Click" CssClass="btn btn-info me-2"
                                > Consultar</asp:LinkButton>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("id") %>'
                                OnClick="Editar_Click" CssClass="btn btn-primary me-2"
                                > Editar</asp:LinkButton>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("id") %>'
                                OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger" OnClientClick=""
                                > Eliminar</asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                </Columns>
          </asp:GridView>
                  </div>
</asp:Content>

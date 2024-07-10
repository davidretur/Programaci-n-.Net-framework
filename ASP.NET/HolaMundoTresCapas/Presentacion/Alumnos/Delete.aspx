<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentacion.Alumnos.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                 <div class="container mt-5">
            <div class="card">
                <h2 class="card-header">Detalles del Alumno</h2>
                <div class="card-body">
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Id:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblid" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Nombre:</label>
                        <div class="col-sm-9">
                           <b>  <asp:Label ID="lblnombre" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Primer Apellido:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblprimerApellido" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Segundo Apellido:</label>
                        <div class="col-sm-9">
                             <b><asp:Label ID="lblsegundoApellido" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label> </b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Correo:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblcorreo" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Telefono:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lbltelefono" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                       <label class="col-sm-3 col-form-label">Fecha de Nacimiento:</label>
                        <div class="col-sm-9">
                            <b><asp:Label ID="lblFechaNacimiento" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Curp:</label>
                        <div class="col-sm-9">
                            <b><asp:Label ID="lblcurp" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Sueldo:</label> 
                        <div class="col-sm-9">
                            <b><asp:Label ID="lblsueldo" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Estado:</label> 
                        <div class="col-sm-9">
                            <b><asp:Label ID="lblEstado" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                    <div class="form-group row">
                       <label class="col-sm-3 col-form-label">Estatus:</label> 
                        <div class="col-sm-9">
                            <b><asp:Label ID="lblEstatus" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                            <asp:LinkButton runat="server" CommandArgument=''
                                OnClick="btnEliminar_Click" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Estas seguro de eliminar este alumno?')"
                                > Eliminar</asp:LinkButton>               
                </div>
            </div>
        </div>

</asp:Content>

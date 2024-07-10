<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Presentacion.Alumnos.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="row">        
    <div class="container mt-5 col-sm-6">
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
                    <asp:LinkButton runat="server" PostBackUrl="/Alumnos/index.aspx"  CssClass="btn btn-sm btn-warning">Volver</asp:LinkButton>
                    <!-- Button trigger modal -->
               <asp:Button ID="Button1" runat="server" OnClick="ConsultarISR_Click" CssClass="btn btn-primary me-2" Text="Calcular ISR" />
                  <!--   <asp:Button ID="Button2" runat="server" OnClick="ConsultarIMMS_Click" CssClass="btn btn-primary me-2" Text="Calcular IMSS" />-->
<input id="Button2" Class="btn btn-success me-2" type="button" value="Calcular IMSS"  onclick="CalculoImss()"/>
                </div>
            </div>
  </div>


            <div class="container mt-5 col-sm-6">
               
        </div>
     </div>

<!-- Modal -->
<div class="modal fade" id="modalIMSS" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">El resultado de Calcular IMSS es</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
                <asp:Panel ID="PanelImss" runat="server" CssClass="card">
                    <div class="card-body">
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Enfermedad Maternidad:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblEnfermedadMaternidad" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">InvalidezVida:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblInvalidezVida" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Retiro:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblRetiro" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Cesantía:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblCesantía" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Infonavit:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblInfonavit" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                     </div>
                </asp:Panel>   
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
       
      </div>
    </div>
  </div>
</div>

        <!-- Modal -->
<div class="modal fade isr" id="ModalISR" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">El resultado de Calcular el ISR es</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
  <asp:Panel ID="PanelISR" runat="server" CssClass="card">
                    <div class="card-body">
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Límite inferior:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lbllímiteinferior" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Límite superior:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lbllímitesuperior" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">CuotaFija:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblcuotaFija" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Excedente:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblexcedente" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">Subsidio:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblsubsidio" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                   <div class="form-group row">
                        <label class="col-sm-3 col-form-label">ISR:</label>
                        <div class="col-sm-9">
                           <b> <asp:Label ID="lblisr" runat="server" CssClass="col-sm-3 col-form-label"></asp:Label></b>
                        </div>
                    </div>
                     </div>
                </asp:Panel>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
       
      </div>
    </div>
  </div>
</div>

     </div>

<script type="text/javascript">


    function CalculoImss() {
        var urlws = '<%= ResolveUrl("http://localhost:61256/WSAlumnos.asmx/CalcularIMSS")%>';
        var id = $("#<%=lblid.ClientID%>").text();
        var idimms = { id: id };
        var parametros = JSON.stringify(idimms);
            $.ajax({
                type: 'POST',
                url: urlws,
                data: parametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: RecibeObjeto,
                error: errorGenerico
            });

        }

    function RecibeObjeto(resultado, estatus, jqXHR) {
        try {
            imss = resultado.d;
            if (imss != null) {
                $("#<%=lblEnfermedadMaternidad.ClientID%>").text(imss.enfermedadMaternidad);
                $("#<%=lblInvalidezVida.ClientID%>").text(imss.invalidezVida);
                $("#<%=lblRetiro.ClientID%>").text(imss.retiro);
                $("#<%=lblCesantía.ClientID%>").text(imss.cesantía);
                $("#<%=lblInfonavit.ClientID%>").text(imss.infonavit);
                $('#modalIMSS').modal('show');
            }
            else {
                alert('La respuesta recibida es incorrecta ' + resultado.d);
            }

        }
        catch (ex) {
            alert('Error al recibir los datos');
        }
    }


    function errorGenerico(jqXHR, estatus, error) {
        var msg = '';
        if (jqXHR.status === 0) {
            msg = 'No está conectado, favor de verificar su conexión.';
        }
        else if (jqXHR.status === 404) {
            msg = 'Página no encontrada [404]';
        }
        else if (jqXHR.status === 500) {
            msg = 'Error no hay conexión al servidor [500]';
        }
        else if (jqXHR.status === 'parseerror') {
            msg = 'El parseo del JSON es erróneo.';
        }
        else if (jqXHR.status === 'timeout') {
            $('body').addClass('loaded');
        }
        else if (jqXHR.status === 'abort') {
            msg = 'La petición Ajax fue abortada.';
        }
        else {
            msg = 'Error no conocido. ';
            console.log(exception);
        }
        alert(msg);
    }
</script>
</asp:Content>

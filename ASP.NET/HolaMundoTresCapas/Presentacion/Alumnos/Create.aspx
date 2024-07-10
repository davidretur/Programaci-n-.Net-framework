<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Presentacion.Alumnos.Create" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
    <h2>Agregar alumnos</h2>
    <div class="row">    
<div class="container mt-5 col-sm-6">
    <div class="mb-3">
        <label class="form-label">Nombre</label>
        <asp:TextBox ID="textnombre" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="textnombre"
    ErrorMessage="El nombre es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="textnombre"
    ValidationExpression="^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$"
    ErrorMessage="Ingrese un nombre válido (solo letras y espacios)" ForeColor="Red"></asp:RegularExpressionValidator>
    </div>
    <div class="mb-3">
        <label class="form-label">Primer Apellido</label>
        <asp:TextBox ID="textprimerApellido" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="textprimerApellido"
    ErrorMessage="El primer apellido es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="textprimerApellido"
    ValidationExpression="^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$"
    ErrorMessage="Ingrese un apellido válido (solo letras y espacios)" ForeColor="Red"></asp:RegularExpressionValidator>
    </div>
    <div class="mb-3">
        <label class="form-label">Segundo Apellido</label>
        <asp:TextBox ID="textsegundoApellido" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textsegundoApellido"
    ErrorMessage="El Segundo apellido es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textsegundoApellido"
    ValidationExpression="^[a-zA-Z\sáéíóúÁÉÍÓÚñÑ]+$"
    ErrorMessage="Ingrese un apellido válido (solo letras y espacios)" ForeColor="Red"></asp:RegularExpressionValidator>
    </div>
      <div class="mb-3">
        <label class="form-label">Fecha Nacimiento</label>
        <asp:TextBox ID="textfechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="textfechaNacimiento"
    ErrorMessage="El Fecha nacimiento es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RangeValidator ID="rvFecha" runat="server" ControlToValidate="textfechaNacimiento"
    MinimumValue="1990-01-01" MaximumValue="2000-12-31"
    Type="Date" ErrorMessage="La fecha debe estar entre el 01-ene-1990 y el 31-dic-2000"
    ForeColor="Red"></asp:RangeValidator>
<asp:CustomValidator ID="cvFechaNacimiento" runat="server"
    ErrorMessage=""
    ForeColor="Red" OnServerValidate="cvFechaNacimiento_ServerValidate"></asp:CustomValidator>
<asp:CustomValidator ID="cvCurpFecha" ControlToValidate="textcurp" runat="server" ErrorMessage="La fecha de nacimiento no coincide" ClientValidationFunction="CurpvsFechNav" CssClass="text-danger"></asp:CustomValidator>
    </div>
 </div>

<div class="container mt-5 col-sm-6">
    <div class="mb-3">
        <label class="form-label">Curp</label>
        <asp:TextBox ID="textcurp" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCURP" runat="server" ControlToValidate="textcurp"
    ErrorMessage="El CURP es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revCURP" runat="server" ControlToValidate="textcurp"
    ValidationExpression="[A-Z]{4}[0-9]{6}[HM][A-Z]{5}[A-Z0-9]{2}[0-9]"
    ErrorMessage="Ingrese un CURP válido de México" ForeColor="Red"></asp:RegularExpressionValidator>
    </div>
    <div class="mb-3">
        <label class="form-label">Correo</label>
        <asp:TextBox ID="textCorreo" runat="server" CssClass="form-control" TextMode ="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="textCorreo"
    ErrorMessage="El Correo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="mb-3">
        <label class="form-label">Telefono</label>
        <asp:TextBox ID="textTelefono" runat="server" CssClass="form-control" TextMode ="Phone"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ValidatorO" runat="server" ControlToValidate="textTelefono"
    ErrorMessage="El Telefono es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revTelefono" runat="server"
    ControlToValidate="textTelefono"
    ErrorMessage="El teléfono debe tener 10 dígitos."
    ValidationExpression="^\d{10}$"
    Display="Dynamic">
</asp:RegularExpressionValidator>
    </div>
      <div class="mb-3">
        <label class="form-label">Sueldo</label>
        <asp:TextBox ID="textSueldo" runat="server" CssClass="form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvSueldo" runat="server" ControlToValidate="textSueldo"
    ErrorMessage="El sueldo es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RangeValidator ID="rvSueldo" runat="server" ControlToValidate="textSueldo"
    MinimumValue="10000" MaximumValue="40000"
    Type="Integer" ErrorMessage="El sueldo debe estar entre 10,000 y 40,000 pesos"
    ForeColor="Red"></asp:RangeValidator>
    </div>

     <div class="input-group mb-3">
         <div class="input-group-prepend">
        <label class="input-group-text">Estado</label>
 </div>
          <asp:DropDownList ID="ddlEstado" runat="server" CssClass="custom-select"></asp:DropDownList>
    </div>
     <div class="input-group mb-3">
         <div class="input-group-prepend">
        <label class="input-group-text">Estatus</label>
 </div>
          <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="custom-select"></asp:DropDownList>
    </div>
    <br />
<div class="mb-3">
    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click" />
 </div> 
</div>
</div>
  <a class="nav-link" href="/Alumnos/index.aspx">Regresar a la lista</a>  
</div>


<script type ="text/javascript">
    function CurpvsFechNav(source, args) {
        var fechanacimiento = $("#<%=textfechaNacimiento.ClientID%>").val();
        var curpVsFecha = args.Value.substr(4, 6);
        var fechaFormCurp = fechanacimiento.substr(2, 2) + fechanacimiento.substr(5, 2) + fechanacimiento.substr(8, 2);
        args.IsValid = curpVsFecha == fechaFormCurp;
    }
</script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>    





</script>

    <div class="container my-5">
        <h4 class="text-center mb-4 fw-bold">🎉 Formulario de Registro</h4>

        <div class="row g-3 justify-content-center">

            <div class="col-12 col-md-6">
                <asp:Label ID="lblDni" runat="server" Text="DNI:" AssociatedControlID="txtDni" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-12 col-md-6">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" AssociatedControlID="txtNombre" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingresa tu Nombre" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
                <asp:RegularExpressionValidator ID="revSoloLetrasNombre" ErrorMessage="Solo se permiten letras y espacios." CssClass="validacion" ControlToValidate="txtNombre" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" Display="Dynamic" />

            </div>


            <div class="col-12 col-md-6">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido:" AssociatedControlID="txtApellido" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingresa tu Apellido" CssClass="validacion" ControlToValidate="txtApellido" runat="server" />
                <asp:RegularExpressionValidator ID="revSoloLetrasApellido" ErrorMessage="Solo se permiten letras y espacios." CssClass="validacion" ControlToValidate="txtApellido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" runat="server" Display="Dynamic" />
            </div>

            <div class="col-12 col-md-6">
                <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingresa tu E-mail" CssClass="validacion" ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="El formato del email es incorrecto (ej. ejemplo@dominio.com)." CssClass="validacion" Display="Dynamic" />

            </div>


            <div class="col-12 col-md-6">
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" AssociatedControlID="txtDireccion" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingresa tu Dirección" CssClass="validacion" ControlToValidate="txtDireccion" runat="server" />
            </div>


            <div class="col-12 col-md-6">
                <asp:Label ID="lblCP" runat="server" Text="Código Postal:" AssociatedControlID="txtCP" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" PlaceHolder="C.P."></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingresa tu Codigo Postal" CssClass="validacion" ControlToValidate="txtCP" runat="server" />
            </div>

            <div class="col-12 col-md-6">
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:" AssociatedControlID="txtCiudad" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingresa tu Ciudad" CssClass="validacion" ControlToValidate="txtCiudad" runat="server" />
            </div>


            <div class="col-12 text-center mt-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>


            <div class="col-12 text-center mt-2">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </div>

    <style>
        .btn.btn-primary {
            background-color: #324D85;
            border-color: none;
        }

            .btn.btn-primary:hover {
                background-color: #185ed6 !important;
                border-color: #185ed6 !important;
            }

        .validacion {
            font-size: 13px;
            color: red;
        }
    </style>

</asp:Content>

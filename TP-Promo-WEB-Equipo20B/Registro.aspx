<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center min-vh-100">
        <div style="text-align: center; width: 100%; max-width: 350px; padding-bottom: 100px;">
            <h4 class="mb-4 fw-bold">🆔 Ingresa tu DNI
            </h4>
            <div class="mb-3">
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control mb-1" ID="txtDni" PlaceHolder="DNI"></asp:TextBox>
              </div>  

                <asp:RequiredFieldValidator
                    ID="rfvDni"
                    runat="server"
                    ControlToValidate="txtDni"
                    ErrorMessage="El DNI es obligatorio."
                    CssClass="validacion"
                    Display="Dynamic"/>


                <asp:RegularExpressionValidator
                    ID="revDni"
                    ErrorMessage="Debe ingresar solo números, con un máximo de 8 dígitos."
                    ControlToValidate="txtDni"
                    ValidationExpression="^\d{1,8}$"
                    Display="Dynamic"
                    runat="server"
                    CssClass="validacion" />
            
            <div>
                <asp:Button ID="btnContinuar" OnClick="btnContinuar_Click" CssClass="btn btn-primary w-100" runat="server" Text="Continuar" />
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

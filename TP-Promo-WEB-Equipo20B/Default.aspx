<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%-- <div class="d-flex justify-content-center align-items-center vh-100">--%>
    <div class="full-screen-center">
        <p class="promo-title">¿Tenés un código? 🎉</p>
        <p class="promo-sub">
            Ingresalo acá y obtené beneficios exclusivos en nuestros servicios.
        </p>

        <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control mb-3" style="max-width: 200px; margin: 0 auto;"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="Ingresa tu voucher" CssClass="validacion" ControlToValidate="txtVoucher" runat="server" />

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary"/>
    </div>

    <style>
        .promo-title {
            font-weight: 700;
            font-size: 1.2rem;
        }

        .promo-sub {
            font-size: 1rem;
            color: #415673;
            margin-bottom: 15px;
        }

        .btn.btn-primary {
            background-color: #324D85;
            border-color: none;
        }

            .btn.btn-primary:hover {
                background-color: #185ed6 !important;
                border-color: #185ed6 !important;
            }

        .validacion{
            font-size: 13px;
            color: red;
        }
    </style>
</asp:Content>


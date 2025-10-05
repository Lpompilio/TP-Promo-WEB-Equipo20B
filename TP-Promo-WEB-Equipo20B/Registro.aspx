<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:Label ID="lblPrueba" runat="server" Text="Label"></asp:Label>--%>

    <script>
        function soloNumeros(e) {
            var charCode = e.charCode;
            if (charCode < 32) {
                return true;
            }
            // Permite solo dígitos (0-9)
            if (charCode >= 48 && charCode <= 57) {
                return true;
            }
            // Rechaza cualquier otra tecla
            return false;
        }
        function validarDni() {
            const txtDni = document.getElementById("txtDni");
            if (txtDni.value == "") {
                txtDni.classList.add("is-invalid")
                return false;
            }
            txtDni.classList.remove("is-invalid")
            return true;
        }

        <a href="Premios.aspx">Premios.aspx</a>
    </script>
    <div class="d-flex justify-content-center align-items-center min-vh-100">
        <div style="text-align: center; width: 100%; max-width: 350px; padding-bottom: 100px;">
            <h4 class="mb-4 fw-bold">🆔 Ingresa tu DNI
            </h4>
            <div class="mb-3">
                <asp:TextBox runat="server" ClientIDMode="Static" OnKeyPress="return soloNumeros(event)" CssClass="form-control mb-3" ID="txtDni" PlaceHolder="DNI"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnContinuar" OnClientClick="return validarDni()" OnClick="btnContinuar_Click" CssClass="btn btn-primary w-100" runat="server" Text="Continuar" />
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
    </style>

</asp:Content>

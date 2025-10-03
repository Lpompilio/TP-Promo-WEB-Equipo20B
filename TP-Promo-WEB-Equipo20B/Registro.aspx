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


    </script>

    <div class="d-flex justify-content-center vh-100">
        <div class="d-flex flex-column align-items-center">
            <div>
                <h4 class="my-3">Ingresa tu DNI
                </h4>
            </div>
            <div>
                <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                <asp:TextBox runat="server" ClientIDMode="Static" OnKeyPress="return soloNumeros(event)" CssClass="form-control mb-2" ID="txtDni" PlaceHolder="DNI" Width="300px"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="btnContinuar" OnClientClick="return validarDni()" OnClick="btnContinuar_Click" CssClass="btn btn-primary" runat="server" Text="Continuar" />
            </div>
        </div>
    </div>

</asp:Content>


<%--    </div>
    <div class="row g-3">
  <div class="col">
      <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" PlaceHolder="Nombre"></asp:TextBox>
  </div>
  <div class="col">
      <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" PlaceHolder="Apellido"  ></asp:TextBox>
  </div>
    </div>--%>
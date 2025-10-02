<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="text-center mt-5">
        <h2>¡Gracias por participar, <asp:Label ID="lblNombre" runat="server"></asp:Label>!</h2>
        <p>Tus datos se guardaron correctamente!</p>
        <a href="Default.aspx" class="btn btn-primary mt-3">Volver al inicio</a>
    </div>
</asp:Content>

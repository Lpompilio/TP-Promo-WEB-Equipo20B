<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4>Ingrese su código de voucher</h4>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    <br /><br />

    <asp:TextBox ID="txtVoucher" runat="server" Width="200px"></asp:TextBox>
    <br /><br />

    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />

</asp:Content>


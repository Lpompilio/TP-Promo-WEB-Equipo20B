<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center vh-100">
        <div class="d-flex flex-column align-items-center">
            <div>
                <h6 class="my-3">Ingrese su código de voucher
                </h6>
            </div>
            <div>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

                <asp:TextBox ID="txtVoucher" runat="server" Width="200px"></asp:TextBox>
                <br />
                <br />
            </div>
            <div>
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary"/>
            </div>
        </div>
    </div>
</asp:Content>


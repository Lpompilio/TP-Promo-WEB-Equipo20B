<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Premios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvPremios" runat="server" DataKeyNames="Codigo" OnSelectedIndexChanged="dgvPremios_SelectedIndexChanged" AutoGenerateColumns="false" AutoGenerateSelectButton="False">
    <Columns>
        <asp:BoundField DataField="Codigo" HeaderText="Código" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" />
        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />

    </Columns>
</asp:GridView>
</asp:Content>

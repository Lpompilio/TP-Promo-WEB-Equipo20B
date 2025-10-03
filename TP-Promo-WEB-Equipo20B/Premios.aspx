<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="TP_Promo_WEB_Equipo20B.Premios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvPremios" runat="server" DataKeyNames="Id" OnSelectedIndexChanged="dgvPremios_SelectedIndexChanged" AutoGenerateColumns="false" AutoGenerateSelectButton="False">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Codigo" HeaderText="Código" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" />
        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
    </Columns>

</asp:GridView>
<div class="container mt-5">   <!-- le damos margen superior -->
    <div class="row">
        <asp:Repeater ID="rptArticulos" runat="server" OnItemDataBound="rptArticulos_ItemDataBound">
            <ItemTemplate>
                <div class="col-md-4 col-sm-6 mb-4 d-flex">
                    <div class="card h-100 w-100">
                        <!-- Carousel o imagen -->
                        <asp:Literal ID="litCarousel" runat="server"></asp:Literal>

                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text flex-grow-1"><%# Eval("Descripcion") %></p>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item"><b>Precio:</b> $<%# Eval("Precio") %></li>
                        </ul>
                        <div class="card-body text-center">
                            <asp:Button ID="btnSeleccionar" runat="server" CommandArgument='<%# Eval("Id") %>'
                                CssClass="btn btn-primary" Text="Elegir" OnClick="btnSeleccionar_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
    </div>
</div>

                <style>
                .card img {
                    width: 100%;
                    height: 250px;        /* alto fijo para que todas queden iguales */
                    object-fit: contain;
                    background-color: #f8f9fa;  /* la imagen se ajusta sin recortarse */
                            }
            </style>



</asp:Content>

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
    <div class="container mt-5">
        <div class="row justify-content-center">
            <asp:Repeater ID="rptArticulos" runat="server" OnItemDataBound="rptArticulos_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-4 col-sm-6 mb-4">
                        <div class="card h-100 d-flex flex-column">
                            <!-- Carousel container -->
                            <div class="carousel-container">
                                <asp:Literal ID="litCarousel" runat="server"></asp:Literal>
                            </div>

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
        .carousel-container {
            height: 180px;
            overflow: hidden;
            background-color: #f8f9fa;
            position: relative;
        }

            .carousel-container .carousel {
                height: 100%;
            }

            .carousel-container .carousel-inner {
                height: 100%;
            }

            .carousel-container .carousel-item {
                height: 100%;
            }

            .carousel-container img,
            .card > img {
                width: 100% !important;
                height: 180px !important;
                object-fit: contain !important;
                object-position: center !important;
                background-color: #f8f9fa !important;
            }

        .card {
            display: flex;
            flex-direction: column;
            height: 100%;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            transition: transform 0.2s;
        }

            .card:hover {
                transform: translateY(-5px);
                box-shadow: 0 4px 8px rgba(0,0,0,0.15);
            }

        .card-body {
            display: flex;
            flex-direction: column;
            padding: 1rem;
        }

            .card-body:first-of-type {
                flex-grow: 1;
                min-height: 180px;
            }

            .card-body:last-of-type {
                flex-grow: 0;
                padding: 1rem;
            }

        .card-title {
            font-size: 1.1rem;
            font-weight: 600;
            margin-bottom: 0.75rem;
            line-height: 1.3;
        }

        .card-text {
            font-size: 0.9rem;
            color: #6c757d;
            margin-bottom: 0;
            overflow: hidden;
            display: -webkit-box;
            -webkit-line-clamp: 4;
            -webkit-box-orient: vertical;
            line-height: 1.5;
        }

        .list-group-item {
            padding: 0.75rem 1rem;
            background-color: #fff;
            border-top: 1px solid rgba(0,0,0,0.125);
        }

        .btn.btn-primary {
            background-color: #324D85;
            border-color: none;
        }

        .card-title {
            font-size: 1.1rem;
            font-weight: 600;
            margin-bottom: 0.5rem;
            min-height: 2.5rem;
        }

        .card-text {
            font-size: 0.9rem;
            color: #6c757d;
            margin-bottom: 0;
        }

        .list-group-item {
            padding: 0.75rem 1rem;
            background-color: #fff;
        }

        .btn.btn-primary:hover {
            background-color: #185ed6 !important;
            border-color: #185ed6 !important;
        }

        .carousel img {
            width: 100% !important;
            height: 180px !important;
            object-fit: contain !important;
        }

        .carousel-item img {
            width: 100% !important;
            height: 180px !important;
            object-fit: contain !important;
        }

        .carousel-control-prev,
        .carousel-control-next {
            width: 10%;
        }

        .carousel-indicators {
            margin-bottom: 0.5rem;
        }

        .row {
            display: flex;
            flex-wrap: wrap;
        }

        .col-md-4,
        .col-sm-6 {
            display: flex;
            margin-bottom: 1.5rem;
        }


        @media (max-width: 768px) {
            .carousel-container,
            .carousel-container img,
            .card > img {
                height: 150px;
            }

            .card-body:first-of-type {
                min-height: 160px;
            }

            .card-text {
                -webkit-line-clamp: 3;
            }
        }
    </style>



</asp:Content>

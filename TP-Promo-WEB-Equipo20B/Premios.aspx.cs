using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Promo_WEB_Equipo20B
{
    public partial class Premios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 

                ArticuloNegocio negocio = new ArticuloNegocio();
                var lista = negocio.Listar();
                rptArticulos.DataSource = lista;
                rptArticulos.DataBind();

            }
        }

        protected void dgvPremios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idArticulo = Convert.ToInt32(dgvPremios.SelectedDataKey.Value);
            Session["IdArticulo"] = idArticulo;
            Response.Redirect("Registro.aspx");
        }
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idArticulo = Convert.ToInt32(btn.CommandArgument);
            Session["IdArticulo"] = idArticulo;
            Response.Redirect("Registro.aspx");
        }

        protected string GenerarCarousel(List<Imagen> imagenes, int idArticulo)
        {
            if (imagenes == null || imagenes.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            sb.Append($"<div id='carousel-{idArticulo}' class='carousel slide' data-bs-ride='carousel'>");
            sb.Append("<div class='carousel-inner'>");

            for (int i = 0; i < imagenes.Count; i++)
            {
                var active = i == 0 ? "active" : "";
                sb.Append($"<div class='carousel-item {active}'>");
                sb.Append($"<img src='{imagenes[i].ImagenUrl}' class='d-block w-100' style='height:200px; object-fit:cover;' />");
                sb.Append("</div>");
            }

            sb.Append("</div>"); // fin carousel-inner

            // botones prev/next
            sb.Append($@"
        <button class='carousel-control-prev' type='button' data-bs-target='#carousel-{idArticulo}' data-bs-slide='prev'>
            <span class='carousel-control-prev-icon'></span>
            <span class='visually-hidden'>Anterior</span>
        </button>
        <button class='carousel-control-next' type='button' data-bs-target='#carousel-{idArticulo}' data-bs-slide='next'>
            <span class='carousel-control-next-icon'></span>
            <span class='visually-hidden'>Siguiente</span>
        </button>
    ");

            sb.Append("</div>"); // fin carousel

            return sb.ToString();
        }
        protected void rptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var articulo = (Articulo)e.Item.DataItem;
                var litCarousel = (Literal)e.Item.FindControl("litCarousel");

                if (articulo.Imagenes.Count > 0)
                {
                    string html = $"<div id='carousel{articulo.Id}' class='carousel slide' data-bs-ride='carousel'>";
                    html += "<div class='carousel-inner'>";

                    for (int i = 0; i < articulo.Imagenes.Count; i++)
                    {
                        string active = i == 0 ? "active" : "";
                        html += $"<div class='carousel-item {active}'>" +
                                $"<img src='{articulo.Imagenes[i].ImagenUrl}' class='d-block w-100' style='height:250px; object-fit:cover;' />" +
                                "</div>";
                    }

                    html += "</div>"; // fin carousel-inner

                    html += $"<button class='carousel-control-prev' type='button' data-bs-target='#carousel{articulo.Id}' data-bs-slide='prev'>" +
                            "<span class='carousel-control-prev-icon'></span>" +
                            "<span class='visually-hidden'>Anterior</span></button>";

                    html += $"<button class='carousel-control-next' type='button' data-bs-target='#carousel{articulo.Id}' data-bs-slide='next'>" +
                            "<span class='carousel-control-next-icon'></span>" +
                            "<span class='visually-hidden'>Siguiente</span></button>";

                    html += "</div>"; // fin carousel

                    litCarousel.Text = html;
                }
            }
        }


    }
}
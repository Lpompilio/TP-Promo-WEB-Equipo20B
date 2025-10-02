using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Promo_WEB_Equipo20B
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["IdArticulo"] != null)
            //{
            //    int idArticulo;
            //    if (int.TryParse(Session["IdArticulo"].ToString(), out idArticulo))
            //    {
            //        lblPrueba.Text = "El ID del artículo seleccionado es: " + idArticulo;
            //    }
            //    else
            //    {
            //        lblPrueba.Text = "El valor de Session no es un número válido.";
            //    }
            //}
            //else
            //{
            //    lblPrueba.Text = "No se seleccionó ningún artículo.";
            //}
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                lblError.Text = "Debe ingresar un DNI.";
                return;
            }
            dni = txtDni.Text.Trim();
            Response.Redirect("Formulario.aspx?dni=" + dni);

        }
    }
}
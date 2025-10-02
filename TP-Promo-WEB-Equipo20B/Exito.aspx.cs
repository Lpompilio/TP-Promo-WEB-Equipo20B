using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Promo_WEB_Equipo20B
{
    public partial class Exito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombre = Request.QueryString["Nombre"];
                if (!string.IsNullOrEmpty(nombre))
                {
                    lblNombre.Text = nombre;
                }
            }
        }
    }
}
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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
                dgvPremios.DataSource = negocio.listar();
                dgvPremios.DataBind();
            }
        }

        protected void dgvPremios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var algo = dgvPremios.SelectedRow.Cells[0].Text;
            var codigo = dgvPremios.SelectedDataKey.Value.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TP_Promo_WEB_Equipo20B
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string codigo = txtVoucher.Text;

            if (string.IsNullOrEmpty(codigo))
            {
                lblMensaje.Text = "Ingrese un código de voucher.";
                return;
            }

            VoucherNegocio negocio = new negocio.VoucherNegocio();

            Voucher voucher = negocio.ObtenerPorCodigo(codigo);

            if (voucher == null)
            { 
                lblMensaje.Text = "El código ingresado es inválido!";
                return;
            }

            if (voucher.YaUsado == true)
            {
                lblMensaje.Text = "El código ingresado ya fue utlizado!";
                return;
            }

            if (voucher != null & voucher.YaUsado==false)
            {
                Session["CodigoVoucher"] = codigo;
                Response.Redirect("Premios.aspx");
            }


        }
    }
}
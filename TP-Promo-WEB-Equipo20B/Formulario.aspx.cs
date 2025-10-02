using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Promo_WEB_Equipo20B
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dni = Request.QueryString["dni"];
                if (!string.IsNullOrEmpty(dni))
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente c = negocio.ObtenerClientePorDni(dni);

                    if (c != null)
                    {
                        txtDni.Text = dni;
                        txtNombre.Text = c.Nombre;
                        txtApellido.Text = c.Apellido;
                        txtEmail.Text = c.Email;
                        txtDireccion.Text = c.Direccion;
                        txtCiudad.Text = c.Ciudad;
                        txtCP.Text = c.CP;
                    }
                    else {
                        txtDni.Text = dni;
                        txtNombre.Text = "";
                        txtApellido.Text = "";
                        txtEmail.Text = "";
                        txtDireccion.Text = "";
                        txtCiudad.Text = "";
                        txtCP.Text = "";
                    }
                }
            }
        }
    }
}
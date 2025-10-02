using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

                    txtDni.Text = dni;

                    if (c != null)
                    {
                        txtNombre.Text = c.Nombre;
                        txtApellido.Text = c.Apellido;
                        txtEmail.Text = c.Email;
                        txtDireccion.Text = c.Direccion;
                        txtCiudad.Text = c.Ciudad;
                        txtCP.Text = c.CP.ToString();
                    }
                    else {
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Documento = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                CP = int.TryParse(txtCP.Text.Trim(), out int cpValue) ? cpValue : 0
            };

            ClienteNegocio negocio = new ClienteNegocio();
            negocio.GuardarCliente(cliente);

            Response.Redirect("Exito.aspx?Nombre=" + cliente.Nombre);
        }
    }
}
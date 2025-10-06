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
                    else
                    {
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

        public void btnGuardar_Click(object sender, EventArgs e)
        {
            try
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
                int idcliente = negocio.GuardarCliente(cliente);

                string codigoVoucher = Session["CodigoVoucher"] as string;
                int? idArticulo = Session["IdArticulo"] != null ? (int?)Convert.ToInt32(Session["IdArticulo"]) : null;


                if (string.IsNullOrEmpty(codigoVoucher))
                {
                    lblError.Text = "No se encontró un código de voucher válido. Por favor, ingrésalo primero.";
                    return;
                }

                if (!idArticulo.HasValue)
                {
                    lblError.Text = "No se encontró el premio seleccionado. Por favor, intenta nuevamente.";
                    return;
                }

                VoucherNegocio voucherNegocio = new VoucherNegocio();
                bool asignado = voucherNegocio.AsignarVoucherACliente(
                    codigoVoucher,
                    idcliente,
                    idArticulo.Value
                );

                if (asignado)
                {
                    EmailService emailService = new EmailService();
                    string asunto = $"Confirmación de registro y canje del código {codigoVoucher}";
                    string cuerpo = $"Gracias por registrarte, {cliente.Nombre} {cliente.Apellido}. " +
                                    $"Tu participación fue registrada correctamente.";

                    emailService.armarCorreo(txtEmail.Text, asunto, cuerpo);
                    emailService.enviarEmail();

                    Response.Redirect("Exito.aspx?Nombre=" + cliente.Nombre);
                }
                else
                {
                    lblError.Text = "No se pudo asignar el voucher. Es posible que ya haya sido usado.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Net.Mail;
using System.Net;

namespace negocio
{
    public class VoucherNegocio
    {
        public Voucher ObtenerPorCodigo(string codigo)
        {
            Voucher voucher = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, FechaCanje FROM Vouchers WHERE CodigoVoucher = @Codigo");
                datos.setearParametro("@Codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    voucher = new Voucher();

                    voucher.CodigoVoucher = datos.Lector["CodigoVoucher"].ToString();
                    voucher.FechaCanje = datos.Lector["FechaCanje"] == DBNull.Value ? (DateTime?)null : (DateTime)datos.Lector["FechaCanje"];

                }

                if (voucher != null && voucher.FechaCanje != null)
                {
                    voucher.YaUsado = true;
                }

                return voucher;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public bool AsignarVoucherACliente(string codigoVoucher, int idCliente, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"UPDATE Vouchers 
                               SET IdCliente = @idCliente, 
                                   FechaCanje = @fecha, 
                                   IdArticulo = @idArticulo 
                               WHERE CodigoVoucher = @codigo 
                               AND (IdCliente IS NULL OR IdCliente = 0)");
                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@fecha", DateTime.Now);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.setearParametro("@codigo", codigoVoucher);

                datos.ejecutarAccion(); // no devuelve nada
                return true; // si no lanzó excepción, asumimos que se guardó
            }
            catch (Exception ex)
            {
                throw new Exception("Error al asignar voucher: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }





    }
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("programacionpruena@gmail.com", "egvn uzla wqmq qtlb");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@commerceprogramacioniii.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }
        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

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
                               SET 
                                   FechaCanje = GETDATE(), 
                                   IdArticulo = @IdArticulo 
                               WHERE CodigoVoucher = @CodigoVoucher 
                               AND IdCliente IS NULL");


                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@CodigoVoucher", codigoVoucher);

                datos.ejecutarAccion(); 

                return true; 
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


    }
}



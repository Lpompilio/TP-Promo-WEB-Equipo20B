using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {

        public Cliente ObtenerClientePorDni(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = new Cliente();

            try
            {
                datos.setearConsulta("SELECT Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @Dni");
                datos.setearParametro("@Dni", dni);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente.Documento = dni;
                    cliente.Nombre = datos.Lector["Nombre"].ToString();
                    cliente.Apellido = datos.Lector["Apellido"].ToString();
                    cliente.Email = datos.Lector["Email"].ToString();
                    cliente.Direccion = datos.Lector["Direccion"].ToString();
                    cliente.Ciudad = datos.Lector["Ciudad"].ToString();
                    cliente.CP = datos.Lector["CP"].ToString();

                return cliente;
                }
                else {

                return cliente;
            }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}


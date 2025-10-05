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
                    cliente.CP = Convert.ToInt32(datos.Lector["CP"]);

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

        public void GuardarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                bool existe = false;
                datos.setearConsulta("SELECT 1 FROM Clientes WHERE Documento = @Dni");
                datos.setearParametro("@Dni", cliente.Documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    existe = true;
                }

                datos.CerrarConexion();

                if (existe)
                {
                    datos = new AccesoDatos();
                    datos.setearConsulta(@"UPDATE Clientes 
                                   SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, 
                                       Direccion = @Direccion, Ciudad = @Ciudad, CP = @CP 
                                   WHERE Documento = @Dni");

                    datos.setearParametro("@Dni", cliente.Documento);
                    datos.setearParametro("@Nombre", cliente.Nombre);
                    datos.setearParametro("@Apellido", cliente.Apellido);
                    datos.setearParametro("@Email", cliente.Email);
                    datos.setearParametro("@Direccion", cliente.Direccion);
                    datos.setearParametro("@Ciudad", cliente.Ciudad);
                    datos.setearParametro("@CP", cliente.CP);

                    datos.ejecutarAccion();
                }
                else
                {
                    datos = new AccesoDatos();
                    datos.setearConsulta(@"INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)
                                   VALUES (@Dni, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");

                    datos.setearParametro("@Dni", cliente.Documento);
                    datos.setearParametro("@Nombre", cliente.Nombre);
                    datos.setearParametro("@Apellido", cliente.Apellido);
                    datos.setearParametro("@Email", cliente.Email);
                    datos.setearParametro("@Direccion", cliente.Direccion);
                    datos.setearParametro("@Ciudad", cliente.Ciudad);
                    datos.setearParametro("@CP", cliente.CP);

                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar cliente", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}

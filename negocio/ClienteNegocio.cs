using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int GuardarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            int clienteId = 0;

            try
            {
                // 1️⃣ Verificar si el cliente ya existe
                datos.setearConsulta("SELECT Id FROM Clientes WHERE Documento = @Dni");
                datos.setearParametro("@Dni", cliente.Documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    // Cliente existe
                    clienteId = Convert.ToInt32(datos.Lector["Id"]);

                    datos.CerrarConexion();

                    // Actualizamos datos del cliente existente
                    datos = new AccesoDatos();
                    datos.setearConsulta(@"UPDATE Clientes 
                                   SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, 
                                       Direccion = @Direccion, Ciudad = @Ciudad, CP = @CP 
                                   WHERE Id = @Id");
                    datos.setearParametro("@Id", clienteId);
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
                    // Cliente no existe → insertamos y obtenemos Id
                    datos.CerrarConexion(); // cerramos lector previo
                    datos = new AccesoDatos();

                    // Abrimos la conexión explícitamente
                    datos.conexion.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
        INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)
        OUTPUT INSERTED.Id
        VALUES (@Dni, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)", datos.conexion))
                    {
                        cmd.Parameters.AddWithValue("@Dni", cliente.Documento);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        cmd.Parameters.AddWithValue("@Ciudad", cliente.Ciudad);
                        cmd.Parameters.AddWithValue("@CP", cliente.CP);

                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                            clienteId = Convert.ToInt32(resultado);
                        else
                            throw new Exception("No se pudo obtener el Id del cliente insertado.");
                    }
                }

                return clienteId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar cliente: " + ex.Message, ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


    }
}

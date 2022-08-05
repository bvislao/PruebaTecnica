using System.Data;
using System.Data.SqlClient;
using TiendaAPI.Models;
using TiendaAPI.Repository.Interfaces;

namespace TiendaAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly String _conexion;
        public ClienteRepository(String conexion)
        {
            _conexion = conexion;
        }

        public int Create(Cliente cliente)
        {
            int resultado = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                  
                    using (SqlCommand cmd = new SqlCommand("usp_ClienteInsert", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = cliente.nombre;
                        cmd.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = cliente.apellidos;
                        cmd.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = cliente.telefono;
                        cmd.Parameters.Add("@correoElectronico", System.Data.SqlDbType.VarChar).Value = cliente.correoElectronico;
                        cmd.Parameters.Add("@documentoIdentidad", System.Data.SqlDbType.VarChar).Value = cliente.documentoIdentidad;
                        cmd.Parameters.Add("@activo", System.Data.SqlDbType.Bit).Value = cliente.activo;
                        resultado = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = -1;
                throw;
            }
            return resultado;
        }

        public int Delete(int Id)
        {
            int resultado = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    
                    using (SqlCommand cmd = new SqlCommand("usp_ClienteDelete", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@clienteId", System.Data.SqlDbType.Int).Value = Id;
                        resultado = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = -1;
                throw;
            }
            return resultado;
        }

        public List<Cliente> getAll()
        {
            List<Cliente> resultado = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ClienteSelectALL", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            resultado = new List<Cliente>();
                            while (dr.Read())
                            {
                                var obj = new Cliente();
                                obj.clienteId = dr.IsDBNull(dr.GetOrdinal("clienteId")) ? 0 : dr.GetInt32(dr.GetOrdinal("clienteId"));
                                obj.nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? "-" : dr.GetString(dr.GetOrdinal("nombre"));
                                obj.apellidos = dr.IsDBNull(dr.GetOrdinal("apellidos")) ? "-" : dr.GetString(dr.GetOrdinal("apellidos"));
                                obj.telefono = dr.IsDBNull(dr.GetOrdinal("telefono")) ? "" : dr.GetString(dr.GetOrdinal("telefono"));
                                obj.correoElectronico = dr.IsDBNull(dr.GetOrdinal("correoElectronico")) ? "" : dr.GetString(dr.GetOrdinal("correoElectronico"));
                                obj.documentoIdentidad = dr.IsDBNull(dr.GetOrdinal("documentoIdentidad")) ? "" : dr.GetString(dr.GetOrdinal("documentoIdentidad"));
                                obj.activo = dr.IsDBNull(dr.GetOrdinal("activo")) ? false : dr.GetBoolean(dr.GetOrdinal("activo"));
                                resultado.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = null;
                throw;
            }
            return resultado;
        }

        public Cliente getById(int Id)
        {
            Cliente resultado = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ClienteSelect", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@clienteId", System.Data.SqlDbType.Int).Value = Id;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                resultado = new Cliente();
                                resultado.clienteId = Id;
                                resultado.nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? "-" : dr.GetString(dr.GetOrdinal("nombre"));
                                resultado.apellidos = dr.IsDBNull(dr.GetOrdinal("apellidos")) ? "-" : dr.GetString(dr.GetOrdinal("apellidos"));
                                resultado.telefono = dr.IsDBNull(dr.GetOrdinal("telefono")) ? "" : dr.GetString(dr.GetOrdinal("telefono"));
                                resultado.correoElectronico = dr.IsDBNull(dr.GetOrdinal("correoElectronico")) ? "" : dr.GetString(dr.GetOrdinal("correoElectronico"));
                                resultado.documentoIdentidad = dr.IsDBNull(dr.GetOrdinal("documentoIdentidad")) ? "" : dr.GetString(dr.GetOrdinal("documentoIdentidad"));
                                resultado.activo = dr.IsDBNull(dr.GetOrdinal("activo")) ? false : dr.GetBoolean(dr.GetOrdinal("activo"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = null;
                throw;
            }
            return resultado;
        }

        public int Update(Cliente cliente)
        {
            int resultado = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                     
                    using (SqlCommand cmd = new SqlCommand("usp_ClienteUpdate", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@clienteId", System.Data.SqlDbType.Int).Value = cliente.clienteId;
                        cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = cliente.nombre;
                        cmd.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = cliente.apellidos;
                        cmd.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = cliente.telefono;
                        cmd.Parameters.Add("@correoElectronico", System.Data.SqlDbType.VarChar).Value = cliente.correoElectronico;
                        cmd.Parameters.Add("@documentoIdentidad", System.Data.SqlDbType.VarChar).Value = cliente.documentoIdentidad;
                        cmd.Parameters.Add("@activo", System.Data.SqlDbType.Bit).Value = cliente.activo;
                        resultado = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = -1;
                throw;
            }
            return resultado;
        }
    }
}

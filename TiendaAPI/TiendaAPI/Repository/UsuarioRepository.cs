using System.Data;
using System.Data.SqlClient;
using TiendaAPI.Models;
using TiendaAPI.Repository.Interfaces;

namespace TiendaAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly String _conexion;
        public UsuarioRepository(String conexion)
        {
            _conexion = conexion;
        }

        public int CreateUsuario(Usuarios usuario)
        {
            int resultado = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("", cn))
                    {
                        cmd.Parameters.Add("", System.Data.SqlDbType.Int).Value = "";
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

        public int DeleteUsuario(int usuarioId)
        {
            int resultado = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("", cn))
                    {
                        cmd.Parameters.Add("", System.Data.SqlDbType.Int).Value = "";
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

        public Usuarios getUsuarioById(int usuarioId)
        {
            Usuarios resultado = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("", cn))
                    {
                        cmd.Parameters.Add("", System.Data.SqlDbType.Int).Value = "";
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

        public List<Usuarios> getUsuariosAll()
        {
            List<Usuarios> resultado = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("", cn))
                    {
                        cmd.Parameters.Add("", System.Data.SqlDbType.Int).Value = "";
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

        public Usuarios Login(string username, string password)
        {
            Usuarios resultado = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    
                    using (SqlCommand cmd = new SqlCommand("usp_UsuarioLogin", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@documentoIdentidad", System.Data.SqlDbType.VarChar).Value = username;
                        cmd.Parameters.Add("@passwordUsuario", System.Data.SqlDbType.VarChar).Value = password;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            
                            while (dr.Read())
                            {
                                resultado = new Usuarios();
                                resultado.documentoIdentidad = dr.IsDBNull(dr.GetOrdinal("documentoIdentidad")) ? "-" : dr.GetString(dr.GetOrdinal("documentoIdentidad"));
                                resultado.usuarioId = dr.IsDBNull(dr.GetOrdinal("usuarioId")) ? 0 : dr.GetInt32(dr.GetOrdinal("usuarioId"));
                                resultado.nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? "-" : dr.GetString(dr.GetOrdinal("nombre"));
                                resultado.apellidos = dr.IsDBNull(dr.GetOrdinal("apellidos")) ? "-" : dr.GetString(dr.GetOrdinal("apellidos"));
                                resultado.telefono = dr.IsDBNull(dr.GetOrdinal("telefono")) ? "-" : dr.GetString(dr.GetOrdinal("telefono"));
                                resultado.correoElectronica = dr.IsDBNull(dr.GetOrdinal("correoElectronico")) ? "-" : dr.GetString(dr.GetOrdinal("correoElectronico"));
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

        public int UpdateUsuario(Usuarios usuario)
        {
            int resultado = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("", cn))
                    {
                        cmd.Parameters.Add("", System.Data.SqlDbType.Int).Value = "";
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

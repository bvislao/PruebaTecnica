using System.Data;
using System.Data.SqlClient;
using TiendaAPI.Models;
using TiendaAPI.Repository.Interfaces;

namespace TiendaAPI.Repository
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly String _conexion;
        public ProductosRepository(String conexion)
        {
            _conexion = conexion;
        }

        public int Create(Productos usuario)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ProductosInsert", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@nombreProducto", System.Data.SqlDbType.VarChar).Value = usuario.nombreProducto;
                        cmd.Parameters.Add("@precioVenta", System.Data.SqlDbType.Decimal).Value = usuario.precioVenta;
                        cmd.Parameters.Add("@precioEnvioMinimo", System.Data.SqlDbType.Decimal).Value = usuario.precioEnvioMinimo;
                        cmd.Parameters.Add("@activo", System.Data.SqlDbType.Bit).Value = usuario.activo;
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

                    using (SqlCommand cmd = new SqlCommand("usp_ProductosDelete", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@productoId", System.Data.SqlDbType.Int).Value = Id;
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

        public List<Productos> getAll()
        {
            List<Productos> resultado = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ProductosSelectALL", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open(); SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            resultado = new List<Productos>();
                            while (dr.Read())
                            {
                                var obj = new Productos();
                                obj.productoId = dr.IsDBNull(dr.GetOrdinal("productoId")) ? 0 : dr.GetInt32(dr.GetOrdinal("productoId"));
                                obj.nombreProducto = dr.IsDBNull(dr.GetOrdinal("nombreProducto")) ? "-" : dr.GetString(dr.GetOrdinal("nombreProducto"));
                                obj.precioVenta = dr.IsDBNull(dr.GetOrdinal("precioVenta")) ? 0 : dr.GetDecimal(dr.GetOrdinal("precioVenta"));
                                obj.precioEnvioMinimo = dr.IsDBNull(dr.GetOrdinal("precioEnvioMinimo")) ? 0 : dr.GetDecimal(dr.GetOrdinal("precioEnvioMinimo"));
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

        public Productos getById(int Id)
        {
            Productos resultado = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ProductosSelect", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@productoId", System.Data.SqlDbType.Int).Value = Id;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                resultado = new Productos();
                                resultado.productoId = Id;
                                resultado.nombreProducto = dr.IsDBNull(dr.GetOrdinal("nombreProducto")) ? "-" : dr.GetString(dr.GetOrdinal("nombreProducto"));
                                resultado.precioVenta = dr.IsDBNull(dr.GetOrdinal("precioVenta")) ? 0 : dr.GetDecimal(dr.GetOrdinal("precioVenta"));
                                resultado.precioEnvioMinimo = dr.IsDBNull(dr.GetOrdinal("precioEnvioMinimo")) ? 0 : dr.GetDecimal(dr.GetOrdinal("precioEnvioMinimo"));
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

        public int Update(Productos usuario)
        {
            int resultado = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(_conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ProductosUpdate", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.Add("@productoId", System.Data.SqlDbType.Int).Value = usuario.productoId;
                        cmd.Parameters.Add("@nombreProducto", System.Data.SqlDbType.VarChar).Value = usuario.nombreProducto;
                        cmd.Parameters.Add("@precioVenta", System.Data.SqlDbType.Decimal).Value = usuario.precioVenta;
                        cmd.Parameters.Add("@precioEnvioMinimo", System.Data.SqlDbType.Decimal).Value = usuario.precioEnvioMinimo;
                        cmd.Parameters.Add("@activo", System.Data.SqlDbType.Bit).Value = usuario.activo;
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

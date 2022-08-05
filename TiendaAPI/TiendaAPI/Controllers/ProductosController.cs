using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Models;
using TiendaAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly String conexion;
        public ProductosController(IConfiguration configuration)
        {
            conexion = configuration.GetValue<string>("ConnectionStrings:cn");
        }


        [HttpPost]
        [Route("create-product")]
        public ResponseAPI<object> CrearProducto(Productos obj)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                int resultado = new ProductosRepository(conexion).Create(obj);
                if (resultado > 0)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = new ProductosRepository(conexion).getAll() ;

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "ocurrio un error";
                    result.responsedata = null;
                }

            }
            catch (Exception ex)
            {
                result.statusCode = 400;
                result.message = ex.Message;
                result.responsedata = null;
            }
            return result;
        }

        [HttpPost]
        [Route("update-product")]
        public ResponseAPI<object> UpdateProducto(Productos obj)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                int resultado = new ProductosRepository(conexion).Update(obj);
                if (resultado > 0)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = new ProductosRepository(conexion).getById(obj.productoId);

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "ocurrio un error";
                    result.responsedata = null;
                }

            }
            catch (Exception ex)
            {
                result.statusCode = 400;
                result.message = ex.Message;
                result.responsedata = null;
            }
            return result;
        }


        [HttpPost]
        [Route("delete-product")]
        public ResponseAPI<object> DeleteProducto(int Id)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                int resultado = new ProductosRepository(conexion).Delete(Id);
                if (resultado > 0)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = null;

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "ocurrio un error";
                    result.responsedata = null;
                }

            }
            catch (Exception ex)
            {
                result.statusCode = 400;
                result.message = ex.Message;
                result.responsedata = null;
            }
            return result;
        }


        [HttpPost]
        [Route("getall-product")]
        public ResponseAPI<object> getAllProductos()
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                var resultado = new ProductosRepository(conexion).getAll();
                if (resultado != null)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = resultado;

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "ocurrio un error";
                    result.responsedata = null;
                }

            }
            catch (Exception ex)
            {
                result.statusCode = 400;
                result.message = ex.Message;
                result.responsedata = null;
            }
            return result;
        }


        [HttpPost]
        [Route("getbyId-product")]
        public ResponseAPI<object> getbyIdProductos(int Id)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                var resultado = new ProductosRepository(conexion).getById(Id);
                if (resultado != null)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = resultado;

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "ocurrio un error";
                    result.responsedata = null;
                }

            }
            catch (Exception ex)
            {
                result.statusCode = 400;
                result.message = ex.Message;
                result.responsedata = null;
            }
            return result;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Models;
using TiendaAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly String conexion;
        public ClienteController(IConfiguration configuration)
        {
            conexion = configuration.GetValue<string>("ConnectionStrings:cn");
        }

        [HttpPost]
        [Route("create-client")]
        public ResponseAPI<object> CrearCliente(Cliente obj)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                int resultado = new ClienteRepository(conexion).Create(obj);
                if (resultado >  0)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = obj;

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "Cliente ya existe";
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
        [Route("delete-client")]
        public ResponseAPI<object> DeleteCliente(int Id)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                int resultado = new ClienteRepository(conexion).Delete(Id);
                if (resultado > 0)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = Id;

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "No se elimino o no existe";
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
        [Route("update-client")]
        public ResponseAPI<object> UpdateCliente(Cliente obj)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                int resultado = new ClienteRepository(conexion).Update(obj);
                if (resultado > 0)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = new ClienteRepository(conexion).getById(obj.clienteId);

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "Ocurrio un inconveniente....";
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
        [Route("clients")]
        public ResponseAPI<object> Clientes()
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                var resultado = new ClienteRepository(conexion).getAll();
                if (resultado != null)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = resultado;

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "Ocurrio un inconveniente....";
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
        [Route("clients-byid")]
        public ResponseAPI<object> ClientesById(int id)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                var resultado = new ClienteRepository(conexion).getById(id);
                if (resultado != null)
                {
                    result.statusCode = 200;
                    result.message = "OK";
                    result.responsedata = resultado;

                }
                else
                {
                    result.statusCode = 500;
                    result.message = "Ocurrio un inconveniente....";
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

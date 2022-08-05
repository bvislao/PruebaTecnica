using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Models;
using TiendaAPI.Repository;
using TiendaAPI.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly String conexion;
        public UsuarioController(IConfiguration configuration)
        {
            conexion = configuration.GetValue<string>("ConnectionStrings:cn");
        }

        [HttpGet]
        [Route("login")]
        public ResponseAPI<object> LoginUsuario(string usuario, string? password)
        {
            ResponseAPI<object> result = new ResponseAPI<object>();
            try
            {
                var obj = new UsuarioRepository(conexion).Login(usuario, password);
                if (obj != null)
                {
                    if (obj.activo)
                    {
                        result.statusCode = 200;
                        result.message = "Logeado OK";
                        result.responsedata = obj;
                    }
                    else
                    {
                        result.statusCode = 400;
                        result.message = "Usuario Inactivo";
                        result.responsedata = obj;
                    }
                }
                else
                {
                    result.statusCode = 400;
                    result.message = "Usuario o contraseña incorrecta";
                    result.responsedata = obj;
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

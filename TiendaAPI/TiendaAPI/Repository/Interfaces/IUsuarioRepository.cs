using TiendaAPI.Models;

namespace TiendaAPI.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuarios Login(string username, string password);
        int CreateUsuario(Usuarios usuario);
        int UpdateUsuario(Usuarios usuario);
        List<Usuarios> getUsuariosAll();
        Usuarios getUsuarioById(int usuarioId);
        int DeleteUsuario(int usuarioId);




    }
}

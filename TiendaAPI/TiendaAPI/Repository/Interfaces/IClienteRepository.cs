using TiendaAPI.Models;

namespace TiendaAPI.Repository.Interfaces
{
    public interface IClienteRepository
    {
        int Create(Cliente cliente);
        int Update(Cliente cliente);
        List<Cliente> getAll();
        Cliente getById(int Id);
        int Delete(int Id);
    }
}

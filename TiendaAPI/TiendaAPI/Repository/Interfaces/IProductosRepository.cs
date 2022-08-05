using TiendaAPI.Models;

namespace TiendaAPI.Repository.Interfaces
{
    public interface IProductosRepository
    {
        int Create(Productos usuario);
        int Update(Productos usuario);
        List<Productos> getAll();
        Productos getById(int Id);
        int Delete(int Id);
    }
}

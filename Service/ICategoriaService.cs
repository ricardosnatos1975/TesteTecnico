using TesteTecnico.Models;

namespace TesteTecnico.Services
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetAllCategorias();
        Task<Categoria> GetCategoriaById(int id);
        Task CreateCategoria(Categoria categoria);
        Task UpdateCategoria(Categoria categoria);
        Task DeleteCategoria(int id);
    }
}

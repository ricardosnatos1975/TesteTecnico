using TesteTecnico.Models;

namespace TesteTecnico.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task CreateAsync(Categoria categoria);
        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int id);
    }
}

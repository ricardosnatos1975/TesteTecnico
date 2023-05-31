using TesteTecnico.Models;

namespace TesteTecnico.Repositorio
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task CreateAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
    }
}

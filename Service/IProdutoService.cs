using TesteTecnico.Models;

namespace TesteTecnico.Services
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetAllProdutos();
        Task<Produto> GetProdutoById(int id);
        Task CreateProduto(Produto produto);
        Task UpdateProduto(Produto produto);
        Task DeleteProduto(int id);
    }
}

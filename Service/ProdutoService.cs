using TesteTecnico.Models;
using TesteTecnico.Repositorio;

namespace TesteTecnico.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepository;

        public ProdutoService(IProdutoRepositorio produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task CreateProduto(Produto produto)
        {
            await _produtoRepository.CreateAsync(produto);
        }

        public async Task UpdateProduto(Produto produto)
        {
            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task DeleteProduto(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }
    }
}

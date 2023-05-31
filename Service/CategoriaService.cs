using TesteTecnico.Models;
using TesteTecnico.Repositorio;

namespace TesteTecnico.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepositorio _categoriaRepository;

        public CategoriaService(ICategoriaRepositorio categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<Categoria>> GetAllCategorias()
        {
            return await _categoriaRepository.GetAllAsync();
        }

        public async Task<Categoria> GetCategoriaById(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }

        public async Task CreateCategoria(Categoria categoria)
        {
            await _categoriaRepository.CreateAsync(categoria);
        }

        public async Task UpdateCategoria(Categoria categoria)
        {
            await _categoriaRepository.UpdateAsync(categoria);
        }

        public async Task DeleteCategoria(int id)
        {
            await _categoriaRepository.DeleteAsync(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteTecnico.Models;
using TesteTecnico.Repositorio;

namespace TesteTecnico.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutosController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepositorio.GetAllAsync();
            return View(produtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepositorio.CreateAsync(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoRepositorio.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _produtoRepositorio.UpdateAsync(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoRepositorio.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produtoRepositorio.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TesteTecnico.Models;
using TesteTecnico.Repositorio;

namespace TesteTecnico.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            var categoria = await _categoriaRepositorio.GetAllAsync();
            return View(categoria);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaRepositorio.CreateAsync(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaRepositorio.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoriaRepositorio.UpdateAsync(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaRepositorio.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaRepositorio.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

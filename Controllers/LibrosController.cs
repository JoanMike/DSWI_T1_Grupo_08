using DSWI_T1_Grupo_08.Models;
using DSWI_T1_Grupo_08.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSWI_T1_Grupo_08.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IAutorService _autorService;

        public LibrosController(ILibroService libroService, IAutorService autorService)
        {
            _libroService = libroService;
            _autorService = autorService;
        }

        public async Task<IActionResult> Index()
        {
            var autores = await _autorService.obtenerTodos();
            ViewBag.Autores = autores.ToDictionary(a => a.AutorId, a => a.Nombre);
            return View(await _libroService.obtenerTodos());
        }

        public async Task<IActionResult> Create()
        {
            await CargarAutores();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro libro)
        {
            ModelState.Remove("Autor");
            if (!ModelState.IsValid)
            {
                await CargarAutores(libro.AutorId);
                return View(libro);
            }

            await _libroService.crear(libro);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var libro = await _libroService.obtenerPorId(id);
            if (libro == null) return NotFound();

            await CargarAutores(libro.AutorId);
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro libro)
        {
            if (id != libro.LibroId) return BadRequest();
            ModelState.Remove("Autor");
            if (!ModelState.IsValid)
            {
                await CargarAutores(libro.AutorId);
                return View(libro);
            }

            await _libroService.editar(libro);
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarAutores(int? seleccionado = null)
        {
            var autores = await _autorService.obtenerTodos();
            ViewBag.AutorId = new SelectList(autores, "AutorId", "Nombre", seleccionado);
        }
    }
}

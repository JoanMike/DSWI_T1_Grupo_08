using DSWI_T1_Grupo_08.Models;
using DSWI_T1_Grupo_08.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_Grupo_08.Controllers
{
    public class AutoresController : Controller
    {
        private readonly IAutorService _service;

        public AutoresController(IAutorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.obtenerTodos());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autore autor)
        {
            ModelState.Remove("Libros");
            if (!ModelState.IsValid) return View(autor);

            await _service.crear(autor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var autor = await _service.obtenerPorId(id);
            if (autor == null) return NotFound();
            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Autore autor)
        {
            if (id != autor.AutorId) return BadRequest();
            ModelState.Remove("Libros");
            if (!ModelState.IsValid) return View(autor);

            await _service.editar(autor);
            return RedirectToAction(nameof(Index));
        }
    }
}
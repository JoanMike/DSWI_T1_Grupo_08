using DSWI_T1_Grupo_08.Services;
using DSWI_T1_Grupo_08.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_Grupo_08.Controllers
{
    public class NotaFinalController : Controller
    {
        private readonly NotaFinalService _notaFinalService;

        public NotaFinalController(NotaFinalService notaFinalService)
        {
            _notaFinalService = notaFinalService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new NotaFinalVm());
        }

        [HttpPost]
        public IActionResult Index(NotaFinalVm vm)
        {
            if (ModelState.IsValid)
            {
                vm.Resultado = _notaFinalService.calcularNotaFinal(vm.Entrada);
            }

            return View(vm);
        }
    }
}

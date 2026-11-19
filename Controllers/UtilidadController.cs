using DSWI_T1_Grupo_08.Services;
using DSWI_T1_Grupo_08.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_Grupo_08.Controllers
{
    public class UtilidadController : Controller
    {
        private readonly UtilidadService _utilidadService;

        public UtilidadController(UtilidadService utilidadService)
        {
            _utilidadService = utilidadService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UtilidadVm());
        }

        [HttpPost]
        public IActionResult Index(UtilidadVm vm)
        {
            if (ModelState.IsValid)
            {
                vm.Resultado = _utilidadService.calcularUtilidad(vm.Entrada);
            }

            return View(vm);
        }
    }
}

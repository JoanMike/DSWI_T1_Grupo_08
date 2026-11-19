using DSWI_T1_Grupo_08.DTOs;

namespace DSWI_T1_Grupo_08.ViewModels
{
    public class NotaFinalVm
    {
        public RegistrarNotasDto Entrada { get; set; } = new RegistrarNotasDto();
        public NotaFinalResultDto? Resultado { get; set; }
    }
}

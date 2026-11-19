using DSWI_T1_Grupo_08.DTOs;

namespace DSWI_T1_Grupo_08.ViewModels
{
    public class UtilidadVm
    {
        public CalcularUtilidadDto Entrada { get; set; } = new CalcularUtilidadDto();
        public UtilidadResultDto? Resultado { get; set; }
    }
}

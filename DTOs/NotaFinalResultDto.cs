namespace DSWI_T1_Grupo_08.DTOs
{
    public class NotaFinalResultDto
    {
        public decimal promedio { get; set; }
        public string categoria { get; set; } = string.Empty;
        public decimal porcentajeBeca { get; set; }
        public decimal porcentajeAsistencia { get; set; }
        public bool asistenciaSuficiente { get; set; }
        public string observacion { get; set; } = string.Empty;
    }
}

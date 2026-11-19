namespace DSWI_T1_Grupo_08.DTOs
{
    public class UtilidadResultDto
    {
        public decimal salarioMensual { get; set; }
        public int aniosTrabajados { get; set; }
        public string tramo { get; set; } = string.Empty;
        public decimal porcentajeUtilidad { get; set; }
        public decimal montoUtilidad { get; set; }
        public decimal totalRecibido { get; set; }
    }
}

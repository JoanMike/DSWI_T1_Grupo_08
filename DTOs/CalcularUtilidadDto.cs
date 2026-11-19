using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_Grupo_08.DTOs
{
    public class CalcularUtilidadDto
    {
        [Required(ErrorMessage = "Ingrese el salario mensual.")]
        [Range(typeof(decimal), "0.01", "99999999.99", ErrorMessage = "El salario mensual debe ser mayor a cero.")]
        public decimal? salarioMensual { get; set; }

        [Required(ErrorMessage = "Ingrese los años trabajados.")]
        [Range(0, 60, ErrorMessage = "Los años trabajados deben estar entre 0 y 60.")]
        public int? aniosTrabajados { get; set; }
    }
}

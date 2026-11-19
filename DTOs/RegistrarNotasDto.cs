using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_Grupo_08.DTOs
{
    public class RegistrarNotasDto
    {
        [Required(ErrorMessage = "Ingrese la primera nota.")]
        [Range(typeof(decimal), "0", "20", ErrorMessage = "La primera nota debe estar entre 0 y 20.")]
        public decimal? nota1 { get; set; }

        [Required(ErrorMessage = "Ingrese la segunda nota.")]
        [Range(typeof(decimal), "0", "20", ErrorMessage = "La segunda nota debe estar entre 0 y 20.")]
        public decimal? nota2 { get; set; }

        [Required(ErrorMessage = "Ingrese la tercera nota.")]
        [Range(typeof(decimal), "0", "20", ErrorMessage = "La tercera nota debe estar entre 0 y 20.")]
        public decimal? nota3 { get; set; }

        [Required(ErrorMessage = "Ingrese el porcentaje de asistencia.")]
        [Range(typeof(decimal), "0", "100", ErrorMessage = "La asistencia debe estar entre 0 y 100.")]
        public decimal? porcentajeAsistencia { get; set; }
    }
}

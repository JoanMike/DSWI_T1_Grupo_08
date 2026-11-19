using DSWI_T1_Grupo_08.DTOs;

namespace DSWI_T1_Grupo_08.Services
{
    public class NotaFinalService
    {
        public NotaFinalResultDto calcularNotaFinal(RegistrarNotasDto dto)
        {
            decimal nota1 = dto.nota1 ?? throw new ArgumentException("Ingrese la primera nota.");
            decimal nota2 = dto.nota2 ?? throw new ArgumentException("Ingrese la segunda nota.");
            decimal nota3 = dto.nota3 ?? throw new ArgumentException("Ingrese la tercera nota.");
            decimal asistencia = dto.porcentajeAsistencia
                ?? throw new ArgumentException("Ingrese el porcentaje de asistencia.");

            if (nota1 < 0 || nota1 > 20 || nota2 < 0 || nota2 > 20 || nota3 < 0 || nota3 > 20)
            {
                throw new ArgumentException("Las notas deben estar entre 0 y 20.");
            }
            if (asistencia < 0 || asistencia > 100)
            {
                throw new ArgumentException("La asistencia debe estar entre 0 y 100.");
            }

            decimal promedio = Math.Round((nota1 + nota2 + nota3) / 3m, 2, MidpointRounding.AwayFromZero);

            string categoria;
            decimal porcentajeBeca;
            string observacion;

            if (promedio >= 18m)
            {
                categoria = "Excelente";
                porcentajeBeca = 50m;
                observacion = "Obtiene una beca del 50%.";
            }
            else if (promedio >= 14m)
            {
                categoria = "Bueno";
                porcentajeBeca = 25m;
                observacion = "Obtiene una beca del 25%.";
            }
            else if (promedio >= 11m)
            {
                categoria = "Regular";
                porcentajeBeca = 0m;
                observacion = "No recibe beca.";
            }
            else
            {
                categoria = "Reprobado";
                porcentajeBeca = 0m;
                observacion = "Debe repetir el curso.";
            }

            // con menos de 70% de asistencia queda reprobado
            bool asistenciaSuficiente = asistencia >= 70m;
            if (!asistenciaSuficiente)
            {
                categoria = "Reprobado";
                porcentajeBeca = 0m;
                observacion = "Asistencia menor al 70%: debe repetir el curso sin beca.";
            }

            return new NotaFinalResultDto
            {
                promedio = promedio,
                categoria = categoria,
                porcentajeBeca = porcentajeBeca,
                porcentajeAsistencia = asistencia,
                asistenciaSuficiente = asistenciaSuficiente,
                observacion = observacion
            };
        }
    }
}

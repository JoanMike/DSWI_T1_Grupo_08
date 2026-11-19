using DSWI_T1_Grupo_08.DTOs;

namespace DSWI_T1_Grupo_08.Services
{
    public class UtilidadService
    {
        public UtilidadResultDto calcularUtilidad(CalcularUtilidadDto dto)
        {
            decimal salario = dto.salarioMensual
                ?? throw new ArgumentException("Ingrese el salario mensual.");
            int anios = dto.aniosTrabajados
                ?? throw new ArgumentException("Ingrese los años trabajados.");

            if (salario <= 0)
            {
                throw new ArgumentException("El salario mensual debe ser mayor a cero.");
            }
            if (anios < 0)
            {
                throw new ArgumentException("Los años trabajados no pueden ser negativos.");
            }

            // porcentaje según los años trabajados
            decimal porcentaje;
            string tramo;

            if (anios < 1)
            {
                porcentaje = 5m;
                tramo = "Menos de 1 año";
            }
            else if (anios < 2)
            {
                porcentaje = 7m;
                tramo = "1 año o más y menos de 2 años";
            }
            else if (anios < 5)
            {
                porcentaje = 10m;
                tramo = "2 años o más y menos de 5 años";
            }
            else if (anios < 10)
            {
                porcentaje = 15m;
                tramo = "5 años o más y menos de 10 años";
            }
            else
            {
                porcentaje = 20m;
                tramo = "10 años o más";
            }

            decimal monto = Math.Round(salario * porcentaje / 100m, 2, MidpointRounding.AwayFromZero);

            return new UtilidadResultDto
            {
                salarioMensual = salario,
                aniosTrabajados = anios,
                tramo = tramo,
                porcentajeUtilidad = porcentaje,
                montoUtilidad = monto,
                totalRecibido = salario + monto
            };
        }
    }
}

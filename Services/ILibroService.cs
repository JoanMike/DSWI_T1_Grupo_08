using DSWI_T1_Grupo_08.Models;

namespace DSWI_T1_Grupo_08.Services
{
    public interface ILibroService
    {
        Task<List<Libro>> obtenerTodos();
        Task<Libro?> obtenerPorId(int id);
        Task crear(Libro libro);
        Task editar(Libro libro);
    }
}

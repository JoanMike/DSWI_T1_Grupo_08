using DSWI_T1_Grupo_08.Models;

namespace DSWI_T1_Grupo_08.Repositories
{
    public interface ILibroRepository
    {
        Task<List<Libro>> obtenerTodos();
        Task<Libro?> obtenerPorId(int id);
    }
}
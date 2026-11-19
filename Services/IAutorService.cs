using DSWI_T1_Grupo_08.Models;

namespace DSWI_T1_Grupo_08.Services
{
    public interface IAutorService
    {
        Task<List<Autore>> obtenerTodos();
        Task<Autore?> obtenerPorId(int id);
        Task crear(Autore autor);
        Task editar(Autore autor);
    }
}

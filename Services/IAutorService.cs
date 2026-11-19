using DSWI_T1_Grupo_08.Models;
using DSWI_T1_Grupo_08.Repositories;

namespace DSWI_T1_Grupo_08.Services
{
    public interface IAutorService
    {
        Task<List<Autore>> obtenerTodos();
        Task<Autore?> obtenerPorId(int id);
        Task crear(Autore autor);
        Task editar(Autore autor);
    }

    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _repository;

        public AutorService(IAutorRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Autore>> obtenerTodos() => _repository.obtenerTodos();
        public Task<Autore?> obtenerPorId(int id) => _repository.obtenerPorId(id);
        public Task crear(Autore autor) => _repository.crear(autor);
        public Task editar(Autore autor) => _repository.editar(autor);
    }
}
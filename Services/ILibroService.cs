using DSWI_T1_Grupo_08.Models;
using DSWI_T1_Grupo_08.Repositories;

namespace DSWI_T1_Grupo_08.Services
{
    public interface ILibroService
    {
        Task<List<Libro>> obtenerTodos();
        Task<Libro?> obtenerPorId(int id);
        Task crear(Libro libro);
        Task editar(Libro libro);
    }

    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _repository;

        public LibroService(ILibroRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Libro>> obtenerTodos() => _repository.obtenerTodos();
        public Task<Libro?> obtenerPorId(int id) => _repository.obtenerPorId(id);
        public Task crear(Libro libro) => _repository.crear(libro);
        public Task editar(Libro libro) => _repository.editar(libro);
    }
}
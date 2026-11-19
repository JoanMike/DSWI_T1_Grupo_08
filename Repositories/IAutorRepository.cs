using DSWI_T1_Grupo_08.Data;
using DSWI_T1_Grupo_08.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo_08.Repositories
{
    public interface IAutorRepository
    {
        Task<List<Autore>> obtenerTodos();
        Task<Autore?> obtenerPorId(int id);
        Task crear(Autore autor);
        Task editar(Autore autor);
    }

    public class AutorRepository : IAutorRepository
    {
        private readonly LibreriaBDContext _context;

        public AutorRepository(LibreriaBDContext context)
        {
            _context = context;
        }

        public async Task<List<Autore>> obtenerTodos()
        {
            return await _context.Autores
                .FromSqlRaw("EXEC sp_Autores_Listar")
                .ToListAsync();
        }

        public async Task<Autore?> obtenerPorId(int id)
        {
            var lista = await _context.Autores
                .FromSqlRaw("EXEC sp_Autores_ObtenerPorId @AutorID", new SqlParameter("@AutorID", id))
                .ToListAsync();

            return lista.FirstOrDefault();
        }

        public async Task crear(Autore autor)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Autores_Crear @Nombre, @Nacionalidad",
                new SqlParameter("@Nombre", autor.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Nacionalidad", autor.Nacionalidad ?? (object)DBNull.Value));
        }

        public async Task editar(Autore autor)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Autores_Editar @AutorID, @Nombre, @Nacionalidad",
                new SqlParameter("@AutorID", autor.AutorId),
                new SqlParameter("@Nombre", autor.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Nacionalidad", autor.Nacionalidad ?? (object)DBNull.Value));
        }
    }
}
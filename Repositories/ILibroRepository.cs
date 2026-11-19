using DSWI_T1_Grupo_08.Data;
using DSWI_T1_Grupo_08.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_Grupo_08.Repositories
{
    public interface ILibroRepository
    {
        Task<List<Libro>> obtenerTodos();
        Task<Libro?> obtenerPorId(int id);
        Task crear(Libro libro);
        Task editar(Libro libro);
    }

    public class LibroRepository : ILibroRepository
    {
        private readonly LibreriaBDContext _context;

        public LibroRepository(LibreriaBDContext context)
        {
            _context = context;
        }

        public async Task<List<Libro>> obtenerTodos()
        {
            return await _context.Libros
                .FromSqlRaw("EXEC sp_Libros_Listar")
                .ToListAsync();
        }

        public async Task<Libro?> obtenerPorId(int id)
        {
            var lista = await _context.Libros
                .FromSqlRaw("EXEC sp_Libros_ObtenerPorId @LibroID", new SqlParameter("@LibroID", id))
                .ToListAsync();

            return lista.FirstOrDefault();
        }

        public async Task crear(Libro libro)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Libros_Crear @Titulo, @Genero, @AñoPublicacion, @ISBN, @AutorID",
                new SqlParameter("@Titulo", libro.Titulo ?? (object)DBNull.Value),
                new SqlParameter("@Genero", libro.Genero ?? (object)DBNull.Value),
                new SqlParameter("@AñoPublicacion", libro.AñoPublicacion ?? (object)DBNull.Value),
                new SqlParameter("@ISBN", libro.Isbn ?? (object)DBNull.Value),
                new SqlParameter("@AutorID", libro.AutorId ?? (object)DBNull.Value));
        }

        public async Task editar(Libro libro)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Libros_Editar @LibroID, @Titulo, @Genero, @AñoPublicacion, @ISBN, @AutorID",
                new SqlParameter("@LibroID", libro.LibroId),
                new SqlParameter("@Titulo", libro.Titulo ?? (object)DBNull.Value),
                new SqlParameter("@Genero", libro.Genero ?? (object)DBNull.Value),
                new SqlParameter("@AñoPublicacion", libro.AñoPublicacion ?? (object)DBNull.Value),
                new SqlParameter("@ISBN", libro.Isbn ?? (object)DBNull.Value),
                new SqlParameter("@AutorID", libro.AutorId ?? (object)DBNull.Value));
        }
    }
}
using LibreriaWebAPI.Context;
using LibreriaWebAPI.Dtos.DtoLibro;
using LibreriaWebAPI.Model;
using LibreriaWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibreriaWebAPI.Repository
{
    public class LibroRepository:ILibroRepository
    {
        private readonly LibroDbContext _context;

        public LibroRepository(LibroDbContext libroDbContext)
        {
            _context=libroDbContext;
        }

        public async Task<int> AddBookAsync(Libro libro)
        {
             _context.Add(libro);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteBook(string isbn)
        {
            var entity = await _context.libros.FirstOrDefaultAsync(l => l.ISBN == isbn);
            _context.libros.Remove(entity);
            var response=await _context.SaveChangesAsync();
            if (response != 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Libro>> GetAllBooksAsync()
        {
            return await _context.libros.Include(l=>l.Autor).Include(l=>l.Genero).ToListAsync();
        }

        public async Task<Libro> UpdateBook(DtoLibroUpdate libro)
        {
            var entity= await _context.libros.FirstOrDefaultAsync(x=>x.ISBN==libro.Isbn);
            entity.ISBN=libro.Isbn;
            entity.Titulo=libro.Titulo;
            entity.AutorId=libro.AutorId;
            entity.Fecha_publicacion=libro.Fecha_publicacion;
            entity.GeneroId=libro.GeneroId;
            _context.Update(entity);
            _context.SaveChangesAsync();
            return entity;
        }
    }
}

using LibreriaWebAPI.Dtos.DtoLibro;
using LibreriaWebAPI.Model;

namespace LibreriaWebAPI.Repository.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetAllBooksAsync();
        Task<int> AddBookAsync(Libro libro);
        Task<Libro> UpdateBook(DtoLibroUpdate libro);
        Task<bool> DeleteBook(string isbn);
    }
}

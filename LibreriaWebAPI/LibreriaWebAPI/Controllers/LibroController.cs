using LibreriaWebAPI.Dtos.DtoLibro;
using LibreriaWebAPI.Model;
using LibreriaWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;

        public LibroController(ILibroRepository libroRepository)
        {
            _libroRepository=libroRepository;
        }

        [HttpGet("/GetAllBooks")]
        public async Task< IActionResult> GetAllBooks()
        {
            try
            {
                var books =  await _libroRepository.GetAllBooksAsync();
                List<DtoLibro>dtoLibros = new List<DtoLibro>(); 
                foreach (var book in books)
                {
                    dtoLibros.Add(new DtoLibro
                    {
                        ISBN=book.ISBN,
                        Titulo=book.Titulo,
                        Autor=book.Autor.DescripcionAutor,
                        AutorId=book.AutorId,
                        Fecha_publicacion=book.Fecha_publicacion,
                        Genero=book.Genero.DescripcionGenero,
                        GeneroId=book.GeneroId,
                    });
                }
                if (dtoLibros == null || dtoLibros.Count==0 ) 
                {
                    return NotFound("No se encontraron libros");                
                }
               return Ok(dtoLibros);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost("/PostBook")]
        public async Task<IActionResult> PostBook([FromBody] DtoLibroPost bookPost)
        {
            try
            {
                Libro libro = new Libro
                {
                    ISBN = bookPost.Isbn,
                    Titulo = bookPost.Titulo,
                    AutorId = bookPost.AutorId,
                    Fecha_publicacion = bookPost.Fecha_publicacion,
                    GeneroId = bookPost.GeneroId
                };

                var libroAdd = await _libroRepository.AddBookAsync(libro);
                if (libroAdd == null)
                {
                    return BadRequest("No se pudo agregar el libro");
                }
                return Ok(libroAdd);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error: {ex.Message}");
            }
        }

        [HttpPut("/UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] DtoLibroUpdate libro)
        {
            try
            {
                var response=await _libroRepository.UpdateBook(libro);
                if(response == null)
                {
                    return BadRequest("No se pudo modificar el libro");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error: {ex.Message}");
            }
        }

        [HttpDelete("{isbn}")]

        public async Task<IActionResult> DeleteBook(string isbn)
        {
            try
            {
                var response = await _libroRepository.DeleteBook(isbn);
                if (response == false)
                {
                    return BadRequest("No se pudo eliminar el libro");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error: {ex.Message}");
            }
            
        }

    }
}

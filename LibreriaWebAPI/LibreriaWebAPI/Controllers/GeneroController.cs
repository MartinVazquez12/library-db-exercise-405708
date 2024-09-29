using LibreriaWebAPI.Dtos.DtoAutor;
using LibreriaWebAPI.Dtos.DtoGenero;
using LibreriaWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
    
        
        [HttpGet("/GetGenerosLibros")]
        public async Task<IActionResult> GetAutores()
        {
            try
            {
                var generos=await _generoRepository.GetAllGenerosAsync();
        
                List<DtoGenero> dtoGeneros = new List<DtoGenero>();
                foreach (var genero in generos)
                {
                    var dtoGenero = new DtoGenero
                    {
                        IdGenero = genero.IdGenero,
                        DescripcionGenero = genero.DescripcionGenero

                    };
                    dtoGeneros.Add(dtoGenero);

                }
                if (dtoGeneros == null || dtoGeneros.Count == 0)
                {
                    return NotFound("No se encontraron generos");
                }
                return Ok(dtoGeneros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

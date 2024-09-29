using LibreriaWebAPI.Dtos.DtoAutor;
using LibreriaWebAPI.Dtos.DtoLibro;
using LibreriaWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository=autorRepository;
        }

        [HttpGet("/GetAutores")]
        public async Task<IActionResult> GetAutores()
        {
            try
            {
                var autores= await _autorRepository.GetAllAutoresAsync();

                List<DtoAutor>lstDtosAutor = new List<DtoAutor>();
                foreach (var autor in autores)
                {
                    var dtoAutor = new DtoAutor
                    {
                        IdAutor = autor.IdAutor,
                        DescripcionAutor=autor.DescripcionAutor
                    };
                    lstDtosAutor.Add(dtoAutor);
                }
                if (lstDtosAutor == null || lstDtosAutor.Count == 0)
                {
                    return NotFound("No se encontraron autores");
                }
                return Ok(lstDtosAutor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

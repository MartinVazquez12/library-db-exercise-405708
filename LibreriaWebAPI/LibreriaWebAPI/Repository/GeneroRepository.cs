using LibreriaWebAPI.Context;
using LibreriaWebAPI.Model;
using LibreriaWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibreriaWebAPI.Repository
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly LibroDbContext _dbContext;

        public GeneroRepository(LibroDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task<List<Genero>> GetAllGenerosAsync()
        {
            return await _dbContext.Generos.ToListAsync();
        }
    }
}

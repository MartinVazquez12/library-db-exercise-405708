using LibreriaWebAPI.Context;
using LibreriaWebAPI.Model;
using LibreriaWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibreriaWebAPI.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LibroDbContext _dbContext;

        public AutorRepository(LibroDbContext dbContext) 
        { 
            _dbContext=dbContext;
        }

        public async Task<List<Autor>> GetAllAutoresAsync()
        {
            return await _dbContext.Autores.ToListAsync();
        }
    }
}

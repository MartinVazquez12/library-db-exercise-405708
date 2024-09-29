using LibreriaWebAPI.Model;

namespace LibreriaWebAPI.Repository.Interfaces
{
    public interface IGeneroRepository
    {
        Task<List<Genero>> GetAllGenerosAsync();
    }
}

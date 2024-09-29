using LibreriaWebAPI.Model;

namespace LibreriaWebAPI.Repository.Interfaces
{
    public interface IAutorRepository
    {
        Task<List<Autor>> GetAllAutoresAsync();

    }
}

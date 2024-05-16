using ChurchManagement.Core.Entidades;

namespace ChurchManagement.Core.Interfaces
{
    public interface ICargoRepository 
    {
        Task<List<Cargo>> GetAllAsync();
        Task<Cargo> GetByIdAsync(int id);
        Task AddAsync(Cargo cargo);
        Task DeleteAsync (int id);
        Task SaveChangesAsync();
    }
}

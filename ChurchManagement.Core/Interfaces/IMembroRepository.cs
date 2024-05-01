using ChurchManagement.Core.Entidades;

namespace ChurchManagement.Core.Interfaces
{
    public interface IMembroRepository
    {
        Task<List<Membro>> GetAllAsync();
        Task<Membro> GetByIdAsync(int id);
        Task<Membro> GetByCargo(int id);
        Task<Membro> GetByNameAsync(string nome);
        Task AddAsync(Membro membro);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}

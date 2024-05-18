using ChurchManagement.Core.Entidades;

namespace ChurchManagement.Core.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<List<Departamento>> GetAllAsync();
        Task<Departamento> GetByIdAsync(int id);
        Task AddAsync(Departamento departamento);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}

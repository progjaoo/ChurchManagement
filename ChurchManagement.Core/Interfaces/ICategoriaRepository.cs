using ChurchManagement.Core.Entidades;

namespace ChurchManagement.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<CategoriaDespesa>> GetAllAsync();
        Task<CategoriaDespesa> GetByIdAsync(int id);
        Task AddAsync(CategoriaDespesa categoriaDespesa);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}

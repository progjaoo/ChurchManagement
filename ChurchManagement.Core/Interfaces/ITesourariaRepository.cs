using ChurchManagement.Core.Entidades;

namespace ChurchManagement.Core.Interfaces
{
    public interface ITesourariaRepository
    {
        Task<Tesouraria> GetCaixaAsync();
        Task<Tesouraria> GetByIdAsync(int id);
        Task AddAsync(Tesouraria tesouraria);
        Task UpdateAsync(Tesouraria tesouraria); 
        Task SaveChangesAsync();
    }
}

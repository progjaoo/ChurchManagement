using ChurchManagement.Core.Entidades;

namespace ChurchManagement.Core.Interfaces
{
    public interface ITransacaoTesourariaRepository
    {
        Task<List<TransacaoTesouraria>> GetAllAsync();
        Task<TransacaoTesouraria> GetByIdAsync(int id);
        Task AddAsync(TransacaoTesouraria transacao);
        Task SaveChangesAsync();
    }
}

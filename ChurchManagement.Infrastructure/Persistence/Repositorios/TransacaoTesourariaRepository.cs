using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagement.Infrastructure.Persistence.Repositorios
{
    public class TransacaoTesourariaRepository : ITransacaoTesourariaRepository
    {
        private readonly ChurchManagementContext _dbcontext;
        public TransacaoTesourariaRepository(ChurchManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<TransacaoTesouraria>> GetAllAsync()
        {
            return await _dbcontext.TransacaoTesouraria.ToListAsync();
        }
        public async Task AddAsync(TransacaoTesouraria transacao)
        {
            await _dbcontext.AddAsync(transacao);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<TransacaoTesouraria> GetByIdAsync(int id)
        {
            return await _dbcontext.TransacaoTesouraria.SingleOrDefaultAsync(t => t.IdTesourariaTransacao == id);
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}

using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagement.Infrastructure.Persistence.Repositorios
{
    public class TesourariaRepository : ITesourariaRepository
    {
        private readonly ChurchManagementContext _dbcontext;
        public TesourariaRepository(ChurchManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Tesouraria tesouraria)
        {
            await _dbcontext.AddAsync(tesouraria);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Tesouraria> GetByIdAsync(int id)
        {
            return await _dbcontext.Tesouraria.SingleOrDefaultAsync(t => t.IdTesouraria == id);
        }

        public async Task<Tesouraria> GetCaixaAsync()
        {
            return await _dbcontext.Tesouraria.SingleOrDefaultAsync(t => t.IdTesouraria == 1);
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tesouraria tesouraria)
        {
            _dbcontext.Set<Tesouraria>().Update(tesouraria);
            await _dbcontext.SaveChangesAsync();
        }
    }
}

using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace ChurchManagement.Infrastructure.Persistence.Repositorios
{
    public class MembroRepository : IMembroRepository
    {
        private readonly ChurchManagementContext _dbcontext;
        public MembroRepository(ChurchManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Membro>> GetAllAsync()
        {
            return await _dbcontext.Membros.ToListAsync();
        }
        public async Task<Membro> GetByCargo(int id)
        {
            return await _dbcontext.Membros.SingleOrDefaultAsync(m => m.IdCargo == id);
        }
        public async Task<Membro> GetByIdAsync(int id)
        {
            return await _dbcontext.Membros.SingleOrDefaultAsync(m => m.IdMembro == id);
        }
        public async Task<Membro> GetByNameAsync(string nome)
        {
            return await _dbcontext.Membros.SingleOrDefaultAsync(m => m.NomeCompleto == nome);
        }
        public async Task AddAsync(Membro membro)
        {
            await _dbcontext.Membros.AddAsync(membro);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var paciente = await _dbcontext.Membros.FindAsync(id);
            _dbcontext.Membros.Remove(paciente);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}

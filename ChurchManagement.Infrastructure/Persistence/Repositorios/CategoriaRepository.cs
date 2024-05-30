using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagement.Infrastructure.Persistence.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ChurchManagementContext _dbcontext;
        public CategoriaRepository(ChurchManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<CategoriaDespesa>> GetAllAsync()
        {
            return await _dbcontext.CategoriaDespesas.ToListAsync();
        }

        public async Task<CategoriaDespesa> GetByIdAsync(int id)
        {
            return await _dbcontext.CategoriaDespesas.SingleOrDefaultAsync(c => c.IdCategoria == id);
        }
        public async Task AddAsync(CategoriaDespesa categoriaDespesa)
        {
            await _dbcontext.AddAsync(categoriaDespesa);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbcontext.CategoriaDespesas.FindAsync(id);
            _dbcontext.CategoriaDespesas.Remove(category);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}

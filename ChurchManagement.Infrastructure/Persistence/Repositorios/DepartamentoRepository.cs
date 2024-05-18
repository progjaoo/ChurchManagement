using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagement.Infrastructure.Persistence.Repositorios
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ChurchManagementContext _dbcontext;
        public DepartamentoRepository(ChurchManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Departamento>> GetAllAsync()
        {
            return await _dbcontext.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetByIdAsync(int id)
        {
            return await _dbcontext.Departamentos.SingleOrDefaultAsync(d => d.IdDepartamento == id);
        }
        public async Task AddAsync(Departamento departamento)
        {
            await _dbcontext.AddAsync(departamento);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var departamento = await _dbcontext.Departamentos.FindAsync(id);
            _dbcontext.Departamentos.Remove(departamento);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}

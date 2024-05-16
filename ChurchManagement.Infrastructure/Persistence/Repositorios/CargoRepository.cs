using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagement.Infrastructure.Persistence.Repositorios
{
    public class CargoRepository : ICargoRepository
    {
        private readonly ChurchManagementContext _dbcontext;
        public CargoRepository(ChurchManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Cargo>> GetAllAsync()
        {
            return await _dbcontext.Cargos.ToListAsync();
        }

        public async Task<Cargo> GetByIdAsync(int id)
        {
            return await _dbcontext.Cargos.SingleOrDefaultAsync(c => c.IdCargo == id);
        }
        public async Task AddAsync(Cargo cargo)
        {
            await _dbcontext.AddAsync(cargo);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cargo = await _dbcontext.Cargos.FindAsync(id);
            _dbcontext.Cargos.Remove(cargo);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}

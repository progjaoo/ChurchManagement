using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagement.Infrastructure.Persistence.Repositorios
{
    public class PostRepository : IPostRepository
    {
        private readonly ChurchManagementContext _dbcontext;
        public PostRepository(ChurchManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Post>> GetAllAsync()
        {
            return await _dbcontext.Posts.ToListAsync();
        }
        public async Task<Post> GetByIdAsync(int id)
        {
            return await _dbcontext.Posts.SingleOrDefaultAsync(p => p.IdPost == id);
        }
        public async Task AddAsync(Post post)
        {
            await _dbcontext.AddAsync(post);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var del = await _dbcontext.Posts.FindAsync(id);
            _dbcontext.Posts.Remove(del);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}

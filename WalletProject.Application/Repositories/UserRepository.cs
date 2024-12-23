using WalletProject.Core.Entities;
using WalletProject.Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WalletProject.Infrastructure.Persistence;

namespace WalletProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WalletDbContext _dbContext;

        public UserRepository(WalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.Include(u => u.Wallets).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.Include(u => u.Wallets).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WalletProject.Application.Repositories.Interfaces;
using WalletProject.Infrastructure.Persistence;
using WalletProject.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WalletProject.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletDbContext _dbContext;

        public WalletRepository(WalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateWalletAsync(WalletUser walletUser)
        {
            await _dbContext.Wallets.AddAsync(walletUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<WalletUser>> GetAllAsync()
        {
            return await _dbContext.Wallets.ToListAsync();
        }

        public async Task<WalletUser> GetByIdAsync(int id)
        {
            var walletUser = await _dbContext.Wallets.FindAsync(id);

            if (walletUser == null)
                throw new Exception($"Wallet não encontrada.");

            return walletUser;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletProject.Core.Entities;

namespace WalletProject.Application.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task CreateWalletAsync(WalletUser walletUser);
        Task<List<WalletUser>> GetAllAsync();
        Task<WalletUser> GetByIdAsync(int id);
    }
}

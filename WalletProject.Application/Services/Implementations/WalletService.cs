using WalletProject.Application.Services.Interfaces;
using WalletProject.Application.Repositories.Interfaces;
using WalletProject.Application.InputModels;
using WalletProject.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace WalletProject.Application.Services.Implementations
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task CreateWallet(CreateWalletInputModel inputModel)
        {
            if (inputModel == null)
                throw new ArgumentNullException(nameof(inputModel));

            var walletUser = new WalletUser
            {
                UserId = inputModel.UserId,
                Value = inputModel.Value,
                Bank = inputModel.Bank,
                LastUpdated = DateTime.UtcNow
            };

            await _walletRepository.CreateWalletAsync(walletUser);
        }

        public async Task<List<WalletUser>> GetAll()
        {
            return await _walletRepository.GetAllAsync();
        }

        public async Task<WalletUser> GetByIdAsync(int id)
        {
            var walletUser = await _walletRepository.GetByIdAsync(id);

            if (walletUser == null)
                throw new Exception($"Carteira não encontrada.");

            return walletUser;
        }
    }
}

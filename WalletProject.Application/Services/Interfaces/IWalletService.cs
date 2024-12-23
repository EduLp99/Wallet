using WalletProject.Application.InputModels;
using WalletProject.Core.Entities;

namespace WalletProject.Application.Services.Interfaces;
public interface IWalletService
{
    Task CreateWallet(CreateWalletInputModel inputModel);
    Task<List<WalletUser>> GetAll();
    Task<WalletUser> GetByIdAsync(int id);
}
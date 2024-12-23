using WalletProject.Application.InputModels;
using WalletProject.Core.Entities;
namespace WalletProject.Application.Services.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task CreateUser(CreateUserInputModel model);
}
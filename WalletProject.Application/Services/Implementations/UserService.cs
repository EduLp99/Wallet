using WalletProject.Application.Services.Interfaces;
using WalletProject.Application.Repositories.Interfaces;
using WalletProject.Application.InputModels;
using WalletProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WalletProject.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(CreateUserInputModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var user = new User
            {
                Name = model.Name,
                BirthDate = model.BirthDate,
                Cpf = model.Cpf,
            };

            await _userRepository.CreateUserAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            return user;
        }
    }
}

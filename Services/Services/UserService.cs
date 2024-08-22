using Infra.Entities;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using BCrypt.Net;

namespace Services.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync(cancellationToken);
        }

        public async Task<User> GetByEmailAsync(CancellationToken cancellationToken, string userName)
        {
            return await _userRepository.GetByEmailAsync(cancellationToken, userName);
        }

        public async Task<User> RegisterUserAsync(User user, string password)
        {
            try{
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

               await  _userRepository.CreateAsync(user);

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}

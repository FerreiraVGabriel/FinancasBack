using Infra.Entities;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using BCrypt.Net;
using System.Threading;

namespace Services.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync(cancellationToken);
        }

        public async Task<User> GetByEmailAsync(CancellationToken cancellationToken, string userName)
        {
            return await _userRepository.GetByEmailAsync(cancellationToken, userName);
        }

        public async Task<User> RegisterUserAsync(CancellationToken cancellationToken, User user, string password)
        {
            try{
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

                await  _userRepository.CreateAsync(user);
                await _unitOfWork.Commit(cancellationToken);

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

    }
}

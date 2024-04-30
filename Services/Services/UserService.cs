using Infra.Entities;
using Infra.Interface;
using Services.Interfaces;

namespace Services.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAll(cancellationToken);
        }
    }
}

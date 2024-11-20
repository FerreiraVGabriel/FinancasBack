using Infra.Entities;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using BCrypt.Net;
using System.Threading;
using Services.Erros;
using OneOf;
using AutoMapper;
using Api.Dtos.Output;
using Api.Dtos.Input;

namespace Services.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync(cancellationToken);
        }

        public async Task<User> GetByEmailAsync(CancellationToken cancellationToken, string userName)
        {
            return await _userRepository.GetByEmailAsync(cancellationToken, userName);
        }

        public async Task<OneOf<UserOutputDTO, BaseError>> RegisterUserAsync(CancellationToken cancellationToken, UserInputDTO userInputDTO)
        {
            try
            {
                User user = new User();
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userInputDTO.Password);
                user.Email = userInputDTO.Email;

                await  _userRepository.CreateAsync(user);
                await _unitOfWork.Commit(cancellationToken);
                UserOutputDTO userOutputDTO = _mapper.Map<UserOutputDTO>(user);

                return userOutputDTO;
            }
            catch (Exception ex)
            {
                return new CreateUserError();
            }
            
        }

    }
}

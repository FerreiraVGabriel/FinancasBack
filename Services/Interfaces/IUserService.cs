using Api.Dtos.Input;
using Api.Dtos.Output;
using Infra.Entities;
using OneOf;
using Services.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<User> GetByEmailAsync(CancellationToken cancellationToken, string userName);
        Task<OneOf<UserOutputDTO, BaseError>> RegisterUserAsync(CancellationToken cancellationToken, UserInputDTO userInputDTO);
    }
}

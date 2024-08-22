using Infra.Entities;
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
        Task<User> RegisterUserAsync(User user, string password);
    }
}

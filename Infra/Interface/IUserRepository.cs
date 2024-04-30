using Infra.Entities;

namespace Infra.Interface
{
    public interface IUserRepository: IBaseBaseRepository<User>
    {
        Task<User> GetByEmail(string email, CancellationToken cancellationToken);
    }
}

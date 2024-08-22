using Infra.Entities;

namespace Infra.Interface
{
    public interface IUserRepository: IBaseBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(CancellationToken cancellationToken, string userName);
    }
}

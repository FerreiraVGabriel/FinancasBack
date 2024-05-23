using Infra.Entities;

namespace Infra.Interface
{
    public interface IUserRepository: IBaseBaseRepository<User>
    {
        Task<User?> GetByUserName(CancellationToken cancellationToken, string userName);
    }
}

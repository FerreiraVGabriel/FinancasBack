using Infra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IBaseBaseRepository<T> where T : Base
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(int id, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}

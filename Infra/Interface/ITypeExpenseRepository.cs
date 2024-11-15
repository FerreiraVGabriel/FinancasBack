using Infra.Entities;
using Infra.Entities.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface ITypeExpenseRepository : IBaseBaseRepository<TypeExpense>
    {
        Task<PaginatedList<TypeExpense>> GetPaginationAsync(SearchParams searchParams);
    }
}

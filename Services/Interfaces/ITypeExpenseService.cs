using Infra.Entities.Params;
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
    public interface ITypeExpenseService
    {
        Task<OneOf<PaginatedList<TypeExpense>, BaseError>> GetPaginationAsync(CancellationToken cancellationToken, SearchParams searchParams);
    }
}

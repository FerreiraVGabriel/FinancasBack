using Infra.Entities;
using Infra.Entities.Params;
using Infra.Interface;
using Infra.Repository;
using OneOf;
using Services.Erros;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    internal class TypeExpenseService : ITypeExpenseService
    {
        private readonly ITypeExpenseRepository _typeExpenseRepository;

        public TypeExpenseService(ITypeExpenseRepository typeExpenseRepository)
        {
            _typeExpenseRepository = typeExpenseRepository;
        }

        public async Task<OneOf<PaginatedList<TypeExpense>, BaseError>> GetPaginationAsync(CancellationToken cancellationToken, SearchParams searchParams)
        {
            return await _typeExpenseRepository.GetPaginationAsync(searchParams);
        }
    }
}

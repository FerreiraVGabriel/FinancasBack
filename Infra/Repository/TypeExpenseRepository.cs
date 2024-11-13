using Infra.Context;
using Infra.Entities;
using Infra.Entities.Params;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using 

namespace Infra.Repository
{
    public class TypeExpenseRepository : BaseRepository<TypeExpense>, ITypeExpenseRepository
    {
        private readonly AppDbContext _context;
        public TypeExpenseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaginatedList<TypeExpense>> GetPaginationAsync(SearchParams searchParams)
        {
            var query = _context.TypeExpense.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchParams.SearchTerm))
                query = query.Where(a => a.Name.Contains(searchParams.SearchTerm));

            var bets = await query
                .OrderByDescending(c => c.DateCreated)
                    .ThenBy(c => c.Id)
                .Skip((searchParams.PageNumber - 1) * searchParams.PageSize)
            .Take(searchParams.PageSize)
            .ToListAsync();

            int totalItems = await query.CountAsync();

            var paginatedList = new PaginatedList<TypeExpense>();
            paginatedList.Items = bets;
            paginatedList.TotalPages = (int)Math.Ceiling(totalItems / (double)searchParams.PageSize);
            paginatedList.PageIndex = searchParams.PageNumber;


            return paginatedList;
        }
    }
}

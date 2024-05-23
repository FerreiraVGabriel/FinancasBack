using Infra.Context;
using Infra.Entities;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) :base(context) 
        {
            _context = context;
        }

        public async Task<User?> GetByUserName(CancellationToken cancellationToken, string userName)
        {
            var user = await _context.Users
                                     .Where(u => u.UserName == userName)
                                     .FirstOrDefaultAsync(cancellationToken);
            return user;
        }

    }
}

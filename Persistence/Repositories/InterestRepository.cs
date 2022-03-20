using Application.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class InterestRepository : GenericRepository<Interest> , IInterestRepository
    {
        private readonly AppDbContext _appDbContext;
        public InterestRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<IReadOnlyList<Interest>> GetAllInterestByUser(string userId)
        {
            return await _appDbContext.Set<Interest>().Include(s => s.User).Where(s => s.UserId.Equals(userId)).ToListAsync<Interest>();
        }
    }
}

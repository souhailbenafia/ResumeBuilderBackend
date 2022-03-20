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
    public class SocialNetworkRepository : GenericRepository<SocialNetwork>, ISocialNetworkRepository
    {
        private readonly AppDbContext _context;
        public SocialNetworkRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        

        public async Task<IReadOnlyList<SocialNetwork>> GetAllSocialNetworkByUser(string userId)
        {
            return await _context.Set<SocialNetwork>().Include(s => s.User).Where(s => s.UserId.Equals(userId)).ToListAsync<SocialNetwork>();
        }
    }
}

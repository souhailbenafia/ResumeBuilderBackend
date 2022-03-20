using Application.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ExperianceRepository : GenericRepository<Experience>, IExperianceRepository
    {
        private readonly AppDbContext _appDbContext;
        public ExperianceRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<IReadOnlyList<Experience>> GetAllExperienceByUser(string userId)
        {
            return await _appDbContext.Set<Experience>().Include(s => s.User).Where(s => s.UserId.Equals(userId)).ToListAsync<Experience>();

        }
      


    }
}

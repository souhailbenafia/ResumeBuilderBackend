using Application.Persistence;
using Domain.Entities;

using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        private readonly AppDbContext _context;
        public EducationRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;   
        }

        public async Task<IReadOnlyList<Education>> GetAllEducationByUser(string userId)
        {
            return await _context.Set<Education>().Include(s => s.User).Where(s => s.UserId.Equals(userId)).ToListAsync<Education>();
        }

        
    }
}

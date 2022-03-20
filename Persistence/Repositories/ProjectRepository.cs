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
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

    

        public async Task<IReadOnlyList<Project>> GetAllProjectByUser(string userId)
        {
            return await _context.Set<Project>().Include(s => s.User).Where(s => s.UserId.Equals(userId)).ToListAsync<Project>();
        }
    }
}

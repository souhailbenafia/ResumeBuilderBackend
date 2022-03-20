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
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        private readonly AppDbContext _context;
        public SkillRepository(AppDbContext dbContext) : base(dbContext)
        { 
            _context = dbContext;
        }

       

        public async  Task<IReadOnlyList<Skill>> GetAllSkillsByUser(string userId)
        {
            return await _context.Set<Skill>().Include(s => s.User).Where(s => s.UserId.Equals(userId)).ToListAsync<Skill>();
        }
    }
}

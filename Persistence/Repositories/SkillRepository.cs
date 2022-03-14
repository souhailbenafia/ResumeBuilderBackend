using Application.Persistence;
using Domain.Entities;
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

       
    }
}

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
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        private readonly AppDbContext _context;
        public LanguageRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IReadOnlyList<Language>> GetAllLanguageByUser(string userId)
        {
            return await _context.Set<Language>().Include(s => s.User).Where(s => s.UserId.Equals(userId)).ToListAsync<Language>();
        }
    }
}

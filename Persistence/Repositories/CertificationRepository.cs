using Application.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CertificationRepository : GenericRepository<Certification>, ICertificationRepository
    {
        private readonly AppDbContext _appDbContext;
        public CertificationRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<IReadOnlyList<Certification>> GetAllCertificationByUser(string userId)
        {
            return await _appDbContext.Set<Certification>().Include(s => s.User).Where(s=>s.UserId.Equals(userId)).ToListAsync<Certification>();

        }
    }
}

using Application.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class InfoRepository : GenericRepository<Info>, IInfoRepository
    {
        private readonly AppDbContext _appDbContext;
        public InfoRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

      
        

        async Task<IReadOnlyList<Info>> IInfoRepository.GetAllCertificationByUser(string userId)
        {
            return await _appDbContext.Set<Info>().Include(s => s.User).Where(s => s.UserId.Equals(userId)).ToListAsync<Info>();
        }
    }
}

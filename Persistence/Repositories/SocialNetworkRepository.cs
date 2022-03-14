using Application.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SocialNetworkRepository : GenericRepository<SocialNetwork>, ISocialNetworkRepository
    {
        private readonly AppDbContext _appDbContext;
        public SocialNetworkRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }

    }
}

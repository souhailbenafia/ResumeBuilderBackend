using Application.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        private readonly AppDbContext _context;
        public EducationRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;   
        }
    }
}

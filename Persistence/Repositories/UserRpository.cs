using Application.Persistence;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRpository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRpository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }



        public async Task<User> GetUserDetailById(string id)
        {
            var UserDetails = await _appDbContext.Users
                .Include(u =>u.Skills)
                .Include(u=>u.Educations)
                .Include(u => u.Experiences)            
                .Include(u => u.Interests)
                .Include(u => u.SocialNetworks)
                .Include(u => u.Languages)
                .Include(u => u.Projects)
                .FirstOrDefaultAsync(u => u.Id == id);

            return UserDetails;
        }

        public async Task<List<User>> GetUsers()
        {
       var users = await _appDbContext.Users.ToListAsync();
            return users;
        }
    }
}

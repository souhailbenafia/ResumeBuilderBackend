using Application.DTOs.User;
using Application.Features.User.Request.Queries;
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

        public async Task<List<User>> GetAllUser()
        
        {
            var UserDetails = await _appDbContext.Users.
                Where(u=>u.Roles.Any(u=>u.RoleId == "Employee"))
                .Include(u => u.Info)
                .Include(u => u.Skills)
                .ToListAsync();
            return UserDetails;
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
                .Include(u => u.Info)
                .FirstOrDefaultAsync(u => u.Id == id);

            return UserDetails;
        }

        public async Task<List<User>> GetUsers()
        {
       var users = await _appDbContext.Users.ToListAsync();
            return users;
        }

       

      public async Task<PagedList<User>> GetUsersP(UserParameters userParameters)
        {
            return  PagedList<User>.ToPagedList(FindAll().OrderBy(on => on.FirstName),
        userParameters.PageNumber,
        userParameters.PageSize);
        }

        PagedList<User> IUserRepository.GetUsersP(UserParameters userParameters)
        {
            throw new NotImplementedException();
        }
    }
}

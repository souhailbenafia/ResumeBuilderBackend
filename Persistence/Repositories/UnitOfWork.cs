
using AutoMapper;
using Application.Persistence;
using Microsoft.AspNetCore.Http;
using Persistence;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private  EducationRepository _educationRepository;
        private  CertificationRepository _certificationRepository;
        private  ExperianceRepository _experianceRepository;
        private  InterestRepository _InterestRepository;
        private  LanguageRepository _LanguageRepository;
        private  ProjectRepository _ProjectRepository;
        private  SkillRepository _SkillRepository;
        private  SocialNetworkRepository _SocialNetworkRepository;
        private  UserRpository _UserRepository;

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
      


        public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public ICertificationRepository certificationRepository => _certificationRepository ??= new CertificationRepository(_context);

        public IEducationRepository educationRepository => _educationRepository ??= new EducationRepository(_context);


        public IExperianceRepository experianceRepository => _experianceRepository  = new ExperianceRepository(_context);


        public IInterestRepository interestRepository => _InterestRepository ??= new InterestRepository(_context);


        public ILanguageRepository languageRepository => _LanguageRepository ??= new LanguageRepository(_context);


        public IProjectRepository projectRepository => _ProjectRepository ??= new ProjectRepository(_context);


        public ISkillRepository skillRepository => _SkillRepository ??= new SkillRepository(_context);


        public ISocialNetworkRepository socialNetworkRepository => _SocialNetworkRepository ??= new SocialNetworkRepository(_context);


        public IUserRepository userRepository => _UserRepository ??= new UserRpository(_context);

        public object CustomClaimTypes { get; private set; }





        /*  public ILeaveAllocationRepository LeaveAllocationRepository => 
              _leaveAllocationRepository ??= new LeaveAllocationRepository(_context);
          public ILeaveTypeRepository LeaveTypeRepository => 
              _leaveTypeRepository ??= new LeaveTypeRepository(_context);
          public ILeaveRequestRepository LeaveRequestRepository => 
              _leaveRequestRepository ??= new LeaveRequestRepository(_context);*/

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save() 
        {
            /*  var username = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

              await  _context.SaveChangesAsync(username);*/
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

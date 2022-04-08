using Domain.Entities;
using Domain.Entities.Identity;

using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Persistence.Configurations.Entities;
using Application.Persistence;
using Persistence.Configurations.Entities.Identity;

namespace Persistence
{
    public class AppDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>, IUnitOfWork
    {

        public const string Schema = "dbo";

        private readonly IMediator _mediator;

       
        #region DbSet

        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        public DbSet<Info> Infos { get; set; }

        public ICertificationRepository certificationRepository => throw new NotImplementedException();

        public IEducationRepository educationRepository => throw new NotImplementedException();

        public IExperianceRepository experianceRepository => throw new NotImplementedException();

        public IInterestRepository interestRepository => throw new NotImplementedException();

        public ILanguageRepository languageRepository => throw new NotImplementedException();

        public IProjectRepository projectRepository => throw new NotImplementedException();

        public ISkillRepository skillRepository => throw new NotImplementedException();

        public ISocialNetworkRepository socialNetworkRepository => throw new NotImplementedException();

        public IUserRepository userRepository => throw new NotImplementedException();
        public IInfoRepository infoRepository => throw new NotImplementedException();


        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Context" /> class.
        /// </summary>
        /// <param name="options">Creation options. Useful when using InMemory driver for testing.</param>
        /// <param name="mediator"><see cref="IMediator"/> instance.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        #region Configuration

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Schema
            builder.HasDefaultSchema(Schema);

            base.OnModelCreating(builder);

            // Configuration
            builder.ApplyConfiguration(new CertificationConfiguration());
            builder.ApplyConfiguration(new InfoConfiguration());
            builder.ApplyConfiguration(new EducationConfiguration());
            builder.ApplyConfiguration(new ExperienceConfiguration());
            builder.ApplyConfiguration(new InterestConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new SkillConfiguration());
            builder.ApplyConfiguration(new LanguageConfiguration());
            builder.ApplyConfiguration(new SocialNetworkConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());

            // Identity
            builder.Entity<User>()
                .ToTable("Users");

            builder.Entity<Role>()
                .ToTable("Roles");

            builder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins");

            builder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims");

            builder.Entity<UserRole>()
                .ToTable("UserRoles");

            builder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims");

            builder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens");
        }

        #endregion

        #region IUnitOfWork

        /// <inheritdoc />
        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            // Dispatch domain events
            //await _mediator.DispatchEvents(this);
            // Commit changes
            return await base.SaveChangesAsync(cancellationToken);
        }

        public Task Save()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}



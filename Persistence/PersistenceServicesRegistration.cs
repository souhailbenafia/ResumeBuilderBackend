using Application.Persistence;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Persistence;


namespace Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("ConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<IEducationRepository , EducationRepository>();
            services.AddScoped<IExperianceRepository , ExperianceRepository>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUserRepository, UserRpository>();
            services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
            services.AddScoped<IInfoRepository, InfoRepository > ();


            return services;
        }
    }
}

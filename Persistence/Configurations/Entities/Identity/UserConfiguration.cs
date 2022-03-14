using Domain.Entities.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Configurations.Entities.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

          builder.HasMany(c => c.Certifications)
            .WithOne(e => e.User);

            builder.HasMany(c => c.Educations)
            .WithOne(e => e.User);

            builder.HasMany(c => c.Experiences)
            .WithOne(e => e.User);

            builder.HasMany(c => c.Projects)
            .WithOne(e => e.User);

            builder.HasMany(c => c.Interests)
            .WithOne(e => e.User);

            builder.HasMany(c => c.Skills)
            .WithOne(e => e.User);

            builder.HasMany(c => c.Languages)
            .WithOne(e => e.User);

            builder.HasMany(c => c.SocialNetworks)
            .WithOne(e => e.User);
        }
    }
}

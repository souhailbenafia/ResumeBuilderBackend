using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities
{
    public class InfoConfiguration : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.User)
            .WithOne(b => b.Info) 
            .HasForeignKey<Info>(p=> p.UserId);
        }
    }
}

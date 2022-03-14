using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities
{
    public class SocialNetworkConfiguration : IEntityTypeConfiguration<SocialNetwork>
    {
        public void Configure(EntityTypeBuilder<SocialNetwork> builder)
    {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.User)
            .WithMany(b => b.SocialNetworks)
            .HasForeignKey(p => p.UserId);
        }
    }
}

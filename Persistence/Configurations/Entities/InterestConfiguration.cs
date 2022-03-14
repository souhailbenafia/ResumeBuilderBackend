using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities
{
    public class InterestConfiguration : IEntityTypeConfiguration<Interest>
    {
        public void Configure(EntityTypeBuilder<Interest> builder)
    {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.User)
            .WithMany(b => b.Interests)
            .HasForeignKey(p => p.UserId);
        }
    }
}

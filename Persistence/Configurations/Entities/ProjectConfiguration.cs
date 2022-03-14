using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
    {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.User)
                        .WithMany(b => b.Projects)
                        .HasForeignKey(p => p.UserId);
        }
    }
}

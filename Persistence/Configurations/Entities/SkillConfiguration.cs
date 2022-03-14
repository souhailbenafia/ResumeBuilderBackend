using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
    {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.User)
             .WithMany(b => b.Skills)
             .HasForeignKey(p => p.UserId);
        }
}
}

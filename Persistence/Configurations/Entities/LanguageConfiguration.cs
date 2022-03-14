using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
    {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.User)
            .WithMany(b => b.Languages)
            .HasForeignKey(p => p.UserId);
        }
    }
}

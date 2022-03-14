using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities
{
    public class CertificationConfiguration : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.User)
          .WithMany(b => b.Certifications)
          .HasForeignKey(p => p.UserId);

        }
    }
}

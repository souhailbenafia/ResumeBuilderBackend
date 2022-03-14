using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations.Entities.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(c => c.User).WithOne().HasForeignKey<UserRole>(c => c.UserId);
            builder.HasOne(c => c.Role).WithOne().HasForeignKey<UserRole>(c => c.RoleId);
        }
    }
}

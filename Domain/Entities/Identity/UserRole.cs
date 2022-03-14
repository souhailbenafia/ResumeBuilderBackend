using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class UserRole : IdentityUserRole<string>
    {

        public virtual User User { get; private set; }

        public virtual Role Role { get; private set; }

    }
}

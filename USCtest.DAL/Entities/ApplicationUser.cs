using Microsoft.AspNetCore.Identity;

namespace USCtest.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}

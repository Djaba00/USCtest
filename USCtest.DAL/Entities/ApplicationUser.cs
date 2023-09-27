using Microsoft.AspNetCore.Identity;

namespace USCtest.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}

namespace VoteSystem.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public User()
        {
            this.RateSystems = new HashSet<RateSystem>();
            this.UserAnswers = new HashSet<UserAnswer>();
        }

        public ICollection<RateSystem> RateSystems { get; set; }

        public ICollection<UserAnswer> UserAnswers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
          
            return userIdentity;
        }
    }
}

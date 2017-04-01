using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VoteSystem.Data.Models;

namespace VoteSystem.Authentication.Models
{
    public class AspNetUser : IdentityUser
    {
        public AspNetUser()
        {
            this.Participants = new HashSet<Participant>();
        }

        public int FN { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Participant> Participants { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AspNetUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
          
            return userIdentity;
        }
    }
}

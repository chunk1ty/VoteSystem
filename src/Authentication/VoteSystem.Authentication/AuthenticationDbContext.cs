using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using VoteSystem.Authentication.Models;
using VoteSystem.Data.Models;

namespace VoteSystem.Authentication
{
    public class AuthenticationDbContext : IdentityDbContext<AspNetUser>
    {
        public AuthenticationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AuthenticationDbContext Create()
        {
            return new AuthenticationDbContext();
        }
    }
}

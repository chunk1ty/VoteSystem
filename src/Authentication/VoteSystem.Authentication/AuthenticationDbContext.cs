//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Identity.EntityFramework;
//using VoteSystem.Authentication.Models;
//using VoteSystem.Common.Constants;

//namespace VoteSystem.Authentication
//{
//    public class AuthenticationDbContext : IdentityDbContext<AspNetUser>
//    {
//        public AuthenticationDbContext()
//            : base(ConnectionStings.VoteSystemDbConnection, throwIfV1Schema: false)
//        {
//        }

//        public static AuthenticationDbContext Create()
//        {
//            return new AuthenticationDbContext();
//        }
//    }
//}

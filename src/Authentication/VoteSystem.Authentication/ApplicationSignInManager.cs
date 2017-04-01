using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using VoteSystem.Authentication.Contracts;
using VoteSystem.Authentication.Models;

namespace VoteSystem.Authentication
{
    public class ApplicationSignInManager : SignInManager<AspNetUser, string>, ISignInService
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
           : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AspNetUser aspNetUser)
        {
            return aspNetUser.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
    }
}
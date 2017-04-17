using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using VoteSystem.Data.Ef.Models;

namespace VoteSystem.Services.Identity.Contracts
{
    public interface ISignInService : IDisposable
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        Task<bool> HasBeenVerifiedAsync();

        Task SignInAsync(AspNetUser user, bool isPersistent, bool rememberBrowser);

        Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser);

        Task<string> GetVerifiedUserIdAsync();

        Task<bool> SendTwoFactorCodeAsync(string provider);

        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersistent);
    }
}

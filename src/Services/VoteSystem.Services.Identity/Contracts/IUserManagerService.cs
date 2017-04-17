using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using VoteSystem.Data.Ef.Models;

namespace VoteSystem.Services.Identity.Contracts
{
    public interface IUserManagerService : IDisposable
    {
        IIdentityMessageService SmsService { get; set; }

        Task<IdentityResult> CreateAsync(AspNetUser user, string password);

        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);

        Task<bool> IsEmailConfirmedAsync(string userId);

        Task<AspNetUser> FindByNameAsync(string userName);

        Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);

        Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId);

        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);

        Task<IdentityResult> CreateAsync(AspNetUser user);

        Task<string> GenerateChangePhoneNumberTokenAsync(string userId, string phoneNumber);

        Task<string> GetPhoneNumberAsync(string userId);

        Task<bool> GetTwoFactorEnabledAsync(string userId);

        Task<IList<UserLoginInfo>> GetLoginsAsync(string userId);

        Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login);

        Task<AspNetUser> FindByIdAsync(string userId);

        Task<IdentityResult> SetTwoFactorEnabledAsync(string userId, bool enabled);

        Task<IdentityResult> ChangePhoneNumberAsync(string userId, string phoneNumber, string token);

        Task<IdentityResult> SetPhoneNumberAsync(string userId, string phoneNumber);

        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);

        Task<IdentityResult> AddPasswordAsync(string userId, string password);

        AspNetUser FindById(string userId);

        Task<string> GeneratePasswordResetTokenAsync(string userId);

        Task<IdentityResult> UpdateAsync(AspNetUser user);

        Task SendEmailAsync(string userId, string subject, string body);

        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
    }
}

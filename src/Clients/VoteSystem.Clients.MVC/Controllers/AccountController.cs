using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using VoteSystem.Authentication;
using VoteSystem.Authentication.Contracts;
using VoteSystem.Authentication.Models;
using VoteSystem.Clients.MVC.Infrastructure.NotificationSystem;
using VoteSystem.Clients.MVC.ViewModels.Account;
using VoteSystem.Data.Models;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private readonly ISignInService signInService;
        private IUserManagerService userManagerService;

        public AccountController()
        {   
        }

        public AccountController(ISignInService signInService, IUserManagerService userManagerService)
        {
            this.signInService = signInService;
            this.userManagerService = userManagerService;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public async Task<ActionResult> Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await this.userManagerService.FindByNameAsync(User.Identity.Name);
                if (user == null)
                {
                    ViewBag.ReturnUrl = returnUrl;
                    return this.View();
                }

                bool isEmailConfirmed = await this.userManagerService.IsEmailConfirmedAsync(user.Id);

                if (isEmailConfirmed)
                {
                    return this.RedirectToAction("Index", "Home");
                }
            }

            ViewBag.ReturnUrl = returnUrl;
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await this.signInService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    var user = await this.userManagerService.FindByNameAsync(model.Email);

                    if (user != null)
                    {
                        if (!await this.userManagerService.IsEmailConfirmedAsync(user.Id))
                        {
                            this.AddNotification("Потвърдете имейлът си за да влезете.", NotificationType.ERROR);

                            return this.RedirectToAction<AccountController>(c => c.Login(string.Empty));
                        }
                    }

                    return this.RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                case SignInStatus.RequiresVerification:
                    return this.RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError(string.Empty, "Невалиден имейл или парола.");
                    return this.View(model);
            }
        }
        
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the aspNetUser has already logged in via username/password or external login
            if (!await this.signInService.HasBeenVerifiedAsync())
            {
                return this.View("Error");
            }

            return this.View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }
       
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a aspNetUser enters incorrect codes for a specified amount of time then the aspNetUser account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await this.signInService.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return this.RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError(string.Empty, "Invalid code.");
                    return this.View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {                
                var user = new AspNetUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FN = model.FacultyNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                user.VoteSystemUser = new VoteSystemUser();
                user.VoteSystemUser.Email = model.Email;

                var result = await this.userManagerService.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await this.SendEmalForNewUser(user);

                    this.AddNotification("Проверете имейлът си за да активирате акаунта.", NotificationType.WARNING);

                    return this.RedirectToAction<AccountController>(c => c.Login(string.Empty));
                }

                this.AddErrors(result);
            }
            
            return this.View(model);
        }

        public async Task<ActionResult> UserProfile()
        {
            string userId = User.Identity.GetUserId();

            var user = await this.userManagerService.FindByIdAsync(userId);

            UserInfoViewModel userVM = new UserInfoViewModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FacultyNumber = user.FN
            };           

            return View(userVM);
        }
        
        public async Task<ActionResult> EditUserProfile()
        {
            string userId = User.Identity.GetUserId();

            var user = await this.userManagerService.FindByIdAsync(userId);

            UserInfoViewModel userVM = new UserInfoViewModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FacultyNumber = user.FN
            };

            return View(userVM);
        }

        [HttpPost]
        public async Task<ActionResult> EditUserProfile(UserInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            string userId = User.Identity.GetUserId();

            var user = await this.userManagerService.FindByIdAsync(userId);
            
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.FN = model.FacultyNumber;

            await this.userManagerService.UpdateAsync(user);

            this.AddNotification("Успешно променихте вашите данни.", NotificationType.SUCCESS);

            return this.RedirectToAction("UserProfile");
        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return this.View("Error");
            }

            var result = await this.userManagerService.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                this.AddNotification("Успешно активирахте вашият акаунт.", NotificationType.SUCCESS);
            }
            else
            {
                this.AddNotification("Неуспешно активирахте вашият акаунт.", NotificationType.ERROR);
            }

            return this.RedirectToAction<AccountController>(c => c.Login(string.Empty));
        }
       
        [AllowAnonymous]
        public ActionResult ForgotPassword(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return this.View();
        }
       
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManagerService.FindByNameAsync(model.Email);

                if (user == null || !(await this.userManagerService.IsEmailConfirmedAsync(user.Id)))
                {
                    this.AddNotification("Въведеният имейл не съществува.", NotificationType.ERROR);

                    return this.RedirectToAction<AccountController>(c => c.Login(string.Empty));
                }
               
                await SendEmailForForgotPassword(user);

                this.AddNotification("Проверете вашият имейл за въвеждане на нова парола.", NotificationType.INFO);

                return this.RedirectToAction<AccountController>(c => c.Login(string.Empty));
            }
           
            return this.View(model);
        }
        
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? this.View("Error") : this.View();
        }
       
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManagerService.FindByNameAsync(model.Email);

            if (user == null)
            {                
                this.ModelState.AddModelError("IncorectEmail", "Имейл адресът не съществува.");

                return this.View(model);
            }

            var result = await this.userManagerService.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                this.AddNotification("Успешно променихте вашата парола.", NotificationType.SUCCESS);

                return this.RedirectToAction<AccountController>(c => c.Login(string.Empty));
            }
           
            this.ModelState.AddModelError(string.Empty, "Невалиден имейл адрес или токен.");

            return this.View(model);
           
        }
        
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }
       
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await this.signInService.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return this.View("Error");
            }

            var userFactors = await this.userManagerService.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return this.View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }
       
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            // Generate the token and send it
            if (!await this.signInService.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return this.View("Error");
            }

            return this.RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }
       
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await this.AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return this.RedirectToAction("Login");
            }

            // Sign in the aspNetUser with this external login provider if the aspNetUser already has a login
            var result = await this.signInService.ExternalSignInAsync(loginInfo, isPersistent: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return this.RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return this.View("Lockout");
                case SignInStatus.RequiresVerification:
                    return this.RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the aspNetUser does not have an account, then prompt the aspNetUser to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return this.View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }
        
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the aspNetUser from the external login provider
                var info = await this.AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return this.View("ExternalLoginFailure");
                }

                var user = new AspNetUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await this.userManagerService.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await this.userManagerService.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return this.RedirectToLocal(returnUrl);
                    }
                }

                this.AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return this.RedirectToAction("Index", "Home");
        }

        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return this.View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.userManagerService != null)
                {
                    this.userManagerService.Dispose();
                    this.userManagerService = null;
                }

                if (this.userManagerService != null)
                {
                    this.userManagerService.Dispose();
                    this.userManagerService = null;
                }
            }

            base.Dispose(disposing);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            return this.RedirectToAction("Index", "Home");
        }

        // TODO extract in another service ?
        private async Task SendEmailForForgotPassword(AspNetUser aspNetUser)
        {
            string code = await this.userManagerService.GeneratePasswordResetTokenAsync(aspNetUser.Id);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = aspNetUser.Id, code = code }, protocol: Request.Url.Scheme);

            UriBuilder url = new UriBuilder(callbackUrl);
            url.Port = -1;
            callbackUrl = url.Uri.ToString();

            await this.userManagerService.SendEmailAsync(aspNetUser.Id, "Забравена парола.", "Въведете новата парола като натиснете: <a href=\"" + callbackUrl + "\">тук.</a>");
        }

        // TODO extract in another service ?
        private async Task SendEmalForNewUser(AspNetUser aspNetUser)
        {
            await this.signInService.SignInAsync(aspNetUser, isPersistent: false, rememberBrowser: false);

            string code = await this.userManagerService.GenerateEmailConfirmationTokenAsync(aspNetUser.Id);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = aspNetUser.Id, code = code }, protocol: Request.Url.Scheme);

            UriBuilder url = new UriBuilder(callbackUrl);
            url.Port = -1;
            callbackUrl = url.Uri.ToString();

            await this.userManagerService.SendEmailAsync(aspNetUser.Id, "Потвърждаване на имейл.", "Моля потвърдете вашият имейл като натиснете <a href=\"" + callbackUrl + "\">тук.</a>");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                this.LoginProvider = provider;
                this.RedirectUri = redirectUri;
                this.UserId = userId;
            }

            public string LoginProvider { get; set; }

            public string RedirectUri { get; set; }

            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = this.RedirectUri };
                if (this.UserId != null)
                {
                    properties.Dictionary[XsrfKey] = this.UserId;
                }

                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, this.LoginProvider);
            }
        }
    }
}
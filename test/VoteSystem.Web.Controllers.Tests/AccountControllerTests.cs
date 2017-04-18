using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using VoteSystem.Clients.MVC.Controllers;
using VoteSystem.Clients.MVC.ViewModels.Account;
using VoteSystem.Data.Ef.Factories;
using VoteSystem.Data.Entities.Factories;
using VoteSystem.Services.Identity.Contracts;

namespace VoteSystem.Web.Controllers.Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        [Test]
        public void ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange
            var mockedIdentityUserManagerService = new Mock<IIdentityUserManagerService>();
            var mockedIdentitySignInService = new Mock<IIdentitySignInService>();
            var mockedAspNetUserFactor = new Mock<IAspNetUserFactory>();
            var mockedVoteSystemUserFactory = new Mock<IVoteSystemUserFactory>();

            var accountController = new AccountController(
                mockedIdentitySignInService.Object,
                mockedIdentityUserManagerService.Object,
                mockedAspNetUserFactor.Object,
                mockedVoteSystemUserFactory.Object);

            accountController.ModelState.AddModelError("", "dummy error");

            LoginViewModel model = new LoginViewModel();
            string returnUrl = "url";

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(model, returnUrl))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }

        [Test]
        public void ReturnActionResult_WhenInvoked()
        {
            // Arrange
            var mockedIdentityUserManagerService = new Mock<IIdentityUserManagerService>();
            var mockedIdentitySignInService = new Mock<IIdentitySignInService>();
            var mockedAspNetUserFactor = new Mock<IAspNetUserFactory>();
            var mockedVoteSystemUserFactory = new Mock<IVoteSystemUserFactory>();

            var accountController = new AccountController(
                mockedIdentitySignInService.Object,
                mockedIdentityUserManagerService.Object,
                mockedAspNetUserFactor.Object,
                mockedVoteSystemUserFactory.Object);

            LoginViewModel model = new LoginViewModel();
            string returnUrl = "url";

            //Act & Assert
            Assert.IsInstanceOf<Task<ActionResult>>(accountController.Login(model, returnUrl));
        }

    }
}

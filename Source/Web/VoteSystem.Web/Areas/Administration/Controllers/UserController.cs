namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;
    using VoteSystem.Web.ViewModels;

    public class UserController : AdministrationController
    {
        private IUserService users;

        public UserController(IUserService users)
        {
            this.users = users;
        }
        
        public ActionResult Index()
        {
            var users = this.users
                .GetAll()
                .To<UserViewModel>()
                .ToList();

            return View(users);
        }
    }
}
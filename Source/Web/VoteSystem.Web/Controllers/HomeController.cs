namespace VoteSystem.Web.Controllers
{
    using Common;
    using System.Web.Mvc;

    using VoteSystem.Services.Data.Contracts;

    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.RedirectToAction("Index", "Administration", new { area = "Administration" });
            }

            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {            
            return this.View();
        }

        public ActionResult Intro()
        {
            return this.View();
        }
    }
}
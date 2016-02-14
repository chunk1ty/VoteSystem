namespace VoteSystem.Web.Controllers
{
    using Common;
    using Infrastructure.Mapping;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels;
    using VoteSystem.Services.Data.Contracts;

    [Authorize]
    public class HomeController : BaseController
    {
        private IRateSystemService rateSystems;

        public HomeController(IRateSystemService rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        public ActionResult Index(string notificationMessage)
        {
            //if (User.IsInRole(GlobalConstants.AdministratorRoleName))
            //{
            //    return this.RedirectToAction("Index", "Administration", new { area = "Administration" });
            //}

            var systems = this.rateSystems
                            .GetAll()
                            .To<RateSystemViewModel>()
                            .ToList();

            ViewBag.NotificationMessage = notificationMessage;

            return this.View(systems);
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
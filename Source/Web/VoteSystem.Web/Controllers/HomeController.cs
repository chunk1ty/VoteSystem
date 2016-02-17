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

        public ActionResult Index()
        {
            var systems = this.rateSystems
                            .AllActive()
                            .To<RateSystemViewModel>()
                            .ToList();

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
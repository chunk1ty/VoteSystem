namespace VoteSystem.Web.Controllers
{
    using System.Web.Mvc;

    using VoteSystem.Services.Data.Contracts;

    [Authorize]
    public class HomeController : BaseController
    {
        private IRateSystemService voteSystems;

        public HomeController(IRateSystemService voteSystems)
        {
            this.voteSystems = voteSystems;
        }

        public ActionResult Index()
        {
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
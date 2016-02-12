namespace VoteSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data.Contracts;

    [Authorize]
    public class HomeController : Controller
    {
        private IVoteSystemServices voteSystems;

        public HomeController(IVoteSystemServices voteSystems)
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
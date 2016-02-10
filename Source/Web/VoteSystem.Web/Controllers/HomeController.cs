namespace VoteSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data.Contracts;

    public class HomeController : Controller
    {
        private IVoteSystemServices voteSystems;

        public HomeController(IVoteSystemServices voteSystems)
        {
            this.voteSystems = voteSystems;
        }

        public ActionResult Index()
        {
            var result = this.voteSystems.GetAll().ToList();
            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
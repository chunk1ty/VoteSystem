namespace VoteSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    
    using VoteSystem.Data;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new VoteSystemDbContext();
            var usersCount = db.Users.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
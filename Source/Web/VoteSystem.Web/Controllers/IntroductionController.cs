namespace VoteSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class IntroductionController : Controller
    {
        public ActionResult Intro()
        {
            return this.View();
        }
    }
}
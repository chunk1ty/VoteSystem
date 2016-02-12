namespace VoteSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class IntroductionController : Controller
    {
        // GET: Introduction
        public ActionResult Intro()
        {
            return this.View();
        }
    }
}
namespace VoteSystem.Web.Controllers
{   
    using System.Web.Mvc;

    using Services.Data.Contracts;

    public class IntroductionController : Controller
    {
        private IVoteSystemService voteSystems;
        private IQuestionService questions;

        public IntroductionController(IVoteSystemService voteSystems, IQuestionService questions)
        {
            this.voteSystems = voteSystems;
            this.questions = questions;
        }

        public ActionResult Intro()
        {
            return this.View();
        }
    }
}
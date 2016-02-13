namespace VoteSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Data.Contracts;
    using System.Linq;

    using VoteSystem.Web.Infrastructure.Mapping;
    using ViewModels;
    using Data.Models;
    public class IntroductionController : Controller
    {
        private IRateSystemService rateSystems;
        private IQuestionService questions;

        public IntroductionController(IRateSystemService rateSystems, IQuestionService questions)
        {
            this.rateSystems = rateSystems;
            this.questions = questions;
        }

        public ActionResult Intro()
        {
            var system = rateSystems
                .GetAll()
                .To<RateSystemViewModel>();


            var toDbModel = system.To<RateSystem>().ToList();

            return this.View(system);
        }
    }
}
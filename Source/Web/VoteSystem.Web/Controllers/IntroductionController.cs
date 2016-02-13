namespace VoteSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Data.Contracts;
    using System.Linq;

    using VoteSystem.Web.Infrastructure.Mapping;
    using ViewModels;
    using Data.Models;
    using VoteSystem.Services.Web;

    public class IntroductionController : Controller
    {
        private IRateSystemService rateSystems;
        private IQuestionService questions;
        private ICacheService cache;

        public IntroductionController(IRateSystemService rateSystems, IQuestionService questions, ICacheService cache)
        {
            this.rateSystems = rateSystems;
            this.questions = questions;
            this.cache = cache;
        }

        public ActionResult Intro()
        {
            var system = this.cache.Get(
                "rateSystems",
                () => rateSystems.GetAll().To<RateSystemViewModel>().ToList(),
                1 * 60);

            return this.View(system);
        }
    }
}
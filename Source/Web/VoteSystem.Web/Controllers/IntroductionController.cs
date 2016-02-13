namespace VoteSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Services.Web.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;
    using VoteSystem.Web.ViewModels;

    public class IntroductionController : BaseController
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
            //TODO create cache from BaseController property
            var system = this.cache.Get(
                "rateSystems",
                () => this.rateSystems.GetAll().To<RateSystemViewModel>().ToList(),
                1 * 60);

            return this.View(system);
        }
    }
}
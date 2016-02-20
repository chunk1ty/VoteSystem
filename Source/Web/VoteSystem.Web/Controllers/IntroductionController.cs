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

        public IntroductionController(IRateSystemService rateSystems, IQuestionService questions)
        {
            this.rateSystems = rateSystems;
            this.questions = questions;
        }

        public ActionResult Index()
        {
            var system = this.Cache.Get(
                "rateSystems",
                () => this.rateSystems.GetAll().To<RateSystemViewModel>().ToList(),
                1 * 60);

            return this.View(system);
        }
    }
}
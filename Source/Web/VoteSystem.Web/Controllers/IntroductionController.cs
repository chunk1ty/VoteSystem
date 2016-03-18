namespace VoteSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Introduction;
    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;
    using VoteSystem.Web.ViewModels;

    public class IntroductionController : BaseController
    {
        private IRateSystemService rateSystems;       

        public IntroductionController(IRateSystemService rateSystems)
        {
            this.rateSystems = rateSystems;            
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            //var system = this.Cache.Get(
            //    "rateSystems",
            //    () => this.rateSystems.GetAll().To<RateSystemViewModel>().ToList(),
            //    1 * 60);

            return this.View(new FeedbackViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(FeedbackViewModel model)
        {
            //var system = this.Cache.Get(
            //    "rateSystems",
            //    () => this.rateSystems.GetAll().To<RateSystemViewModel>().ToList(),
            //    1 * 60);

            return this.RedirectToAction("Index");
        }
    }
}
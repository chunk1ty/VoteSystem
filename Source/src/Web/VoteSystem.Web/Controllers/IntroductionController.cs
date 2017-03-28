namespace VoteSystem.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Threading.Tasks;
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(FeedbackViewModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return this.View(model);
            }

            EmailService email = new EmailService();

            await email.SendFeedbackEmailAsync(model);

            return this.RedirectToAction("Index");
        }
    }
}
using System.Threading.Tasks;
using System.Web.Mvc;
using VoteSystem.Authentication;
using VoteSystem.Clients.MVC.ViewModels.Introduction;
using VoteSystem.Data.Services.Contracts;
using FeedbackViewModel = VoteSystem.Clients.MVC.ViewModels.Introduction.FeedbackViewModel;

namespace VoteSystem.Clients.MVC.Controllers
{
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

            await email.SendFeedbackEmailAsync(null);

            return this.RedirectToAction("Index");
        }
    }
}
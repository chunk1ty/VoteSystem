using System.Threading.Tasks;
using System.Web.Mvc;

using VoteSystem.Authentication;
using VoteSystem.Data.Services.Contracts;

using FeedbackViewModel = VoteSystem.Clients.MVC.ViewModels.Introduction.FeedbackViewModel;

namespace VoteSystem.Clients.MVC.Controllers
{
    public class IntroductionController : BaseController
    {
        private IVoteSystemService voteSystemService;       

        public IntroductionController(IVoteSystemService voteSystemService)
        {
            this.voteSystemService = voteSystemService;            
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            //var system = this.Cache.Get(
            //    "voteSystemService",
            //    () => this.voteSystemService.GetAll().To<RateSystemViewModel>().ToList(),
            //    1 * 60);
            voteSystemService.GetAll();

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
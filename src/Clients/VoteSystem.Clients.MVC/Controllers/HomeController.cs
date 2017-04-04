using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private IVoteSystemService voteSystems;

        public HomeController(IVoteSystemService voteSystems)
        {
            this.voteSystems = voteSystems;
        }

        public ActionResult Index()
        {
            //var systems = this.voteSystems
            //                .AllActive(User.Identity.GetUserId())
            //                .To<RateSystemViewModel>()
            //                .ToList();

            //return this.View(systems);
            return this.View();
        }
    }
}
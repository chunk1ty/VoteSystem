using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Services.Data.Contracts;
using VoteSystem.Web.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private IRateSystemService rateSystems;

        public HomeController(IRateSystemService rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        public ActionResult Index()
        {
            var systems = this.rateSystems
                            .AllActive(User.Identity.GetUserId())
                            .To<RateSystemViewModel>()
                            .ToList();

            return this.View(systems);
        }
    }
}
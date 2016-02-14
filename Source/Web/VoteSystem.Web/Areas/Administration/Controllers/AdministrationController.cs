namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using ViewModels;
    using VoteSystem.Common;
    using Web.Controllers;
    using VoteSystem.Web.Infrastructure.Mapping;
    using Data.Models;
    using System.Linq;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        private IRateSystemService rateSystems;

        public AdministrationController(IRateSystemService rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RateSystemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = this.Mapper.Map<RateSystem>(model);
            }

            return this.View();
        }
    }
}
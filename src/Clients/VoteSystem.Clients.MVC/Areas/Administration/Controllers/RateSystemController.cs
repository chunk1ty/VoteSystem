using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class RateSystemController : AdministrationController
    {
        private IRateSystemService rateSystems;

        public RateSystemController(IRateSystemService rateSystems)
        {
            this.rateSystems = rateSystems;
        }

        [HttpGet]
        public ActionResult Index()
        {
            //var allVoteSystems = this.rateSystems
            //                            .GetAll()
            //                            .To<RateSystemViewModel>()
            //                            .ToList();

            //return this.View(allVoteSystems);

            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RateSystemViewModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return this.View(model);
            }

            if (model.StarDateTime >= model.EndDateTime)
            {
                this.ModelState.AddModelError(string.Empty, "Началната дата не може да е по голяма от крайната дата.");
                return this.View(model);
            }

            //var modelDb = this.Mapper.Map<Survey>(model);
            //this.rateSystems.Add(modelDb);

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int rateSystemId)
        {
            //var rateSystem = this.rateSystems.GetById(rateSystemId);
            //var rateSystemVM = this.Mapper.Map<RateSystemViewModel>(rateSystem);

            //return this.View(rateSystemVM);

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RateSystemViewModel model)
        {
            //if (!ModelState.IsValid || model == null)
            //{
            //    return this.View(model);
            //}

            //if (model.StarDateTime >= model.EndDateTime)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Start date can not be greater than end date.");
            //    return this.View(model);
            //}

            //var rateSystemDb = this.rateSystems.GetById(model.Id);

            //if (rateSystemDb == null)
            //{
            //    this.ModelState.AddModelError(string.Empty, "The rate system is not found");
            //    return this.View(model);
            //}

            //rateSystemDb.Name = model.RateSystemName;
            //rateSystemDb.StarDateTime = model.StarDateTime;
            //rateSystemDb.EndDateTime = model.EndDateTime;

            //this.rateSystems.Update(rateSystemDb);

            return this.RedirectToAction<RateSystemController>(c => c.Index());
        }
    }
}
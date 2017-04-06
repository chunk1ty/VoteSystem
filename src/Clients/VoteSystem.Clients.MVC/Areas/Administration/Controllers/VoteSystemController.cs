using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using VoteSystem.Clients.MVC.Areas.Administration.Models;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class VoteSystemController : AdminController
    {
        private readonly IVoteSystemService _voteSystemService;

        public VoteSystemController(IVoteSystemService voteSystemService)
        {
            _voteSystemService = voteSystemService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allVoteSystems = _voteSystemService
                                                .GetAll()
                                                .To<VoteSystemViewModel>()
                                                .ToList();

            return this.View(allVoteSystems);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoteSystemCreateViewModel model)
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

            var voteSystemAsDbObject = Mapper.Map<Data.Entities.VoteSystem>(model);
            _voteSystemService.Add(voteSystemAsDbObject);

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int rateSystemId)
        {
            //var rateSystem = this.voteSystemService.GetById(rateSystemId);
            //var rateSystemVM = this.Mapper.Map<VoteSystemViewModel>(rateSystem);

            //return this.View(rateSystemVM);

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoteSystemViewModel model)
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

            //var rateSystemDb = this.voteSystemService.GetById(model.Id);

            //if (rateSystemDb == null)
            //{
            //    this.ModelState.AddModelError(string.Empty, "The rate system is not found");
            //    return this.View(model);
            //}

            //rateSystemDb.Name = model.Name;
            //rateSystemDb.StarDateTime = model.StarDateTime;
            //rateSystemDb.EndDateTime = model.EndDateTime;

            //this.voteSystemService.Update(rateSystemDb);

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }
    }
}
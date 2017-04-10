using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using VoteSystem.Clients.MVC.Areas.Administration.Models.VoteSystem;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
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
        public ActionResult Create(VoteSystemPostViewModel model)
        {
            if (!ValidatePostRequest(model))
            {
                return View(model);
            }

            var voteSystemAsDbObject = Mapper.Map<Data.Entities.VoteSystem>(model);
            _voteSystemService.Add(voteSystemAsDbObject);

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int voteSystemId)
        {
            var voteSystem = _voteSystemService.GetById(voteSystemId);

            var voteSystemAsViewModel = Mapper.Map<VoteSystemPostViewModel>(voteSystem);

            return View(voteSystemAsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoteSystemPostViewModel model)
        {
            if (!ValidatePostRequest(model))
            {
                return View(model);
            }

            var voteSystemAsDbObject = Mapper.Map<Data.Entities.VoteSystem>(model);

            _voteSystemService.Update(voteSystemAsDbObject);

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult Delete(int voteSystemId)
        {
            _voteSystemService.Delete(voteSystemId);

            return Content("DELETED");
        }

        [HttpGet]
        public ActionResult Result(int voteSystemId)
        {
            return View(voteSystemId);
        }

        private bool ValidatePostRequest(VoteSystemPostViewModel model)
        {
            var isValid = true;

            if (!ModelState.IsValid || model == null)
            {
                isValid =  false;
            }

            if (model.StarDateTime >= model.EndDateTime)
            {
                ModelState.AddModelError(string.Empty, "Началната дата не може да е по голяма от крайната дата.");
                isValid = false;
            }

            return isValid;
        }
    }
}
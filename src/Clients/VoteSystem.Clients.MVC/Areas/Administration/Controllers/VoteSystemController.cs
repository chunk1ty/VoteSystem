using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;

using VoteSystem.Clients.MVC.Areas.Administration.ViewModels.VoteSystem;
using VoteSystem.Clients.MVC.Infrastructure.Attributes;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.Infrastructure.NotificationSystem;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class VoteSystemController : AdminController
    {
        private readonly IVoteSystemService _voteSystemService;
        private readonly IQuestionService _questionService;

        public VoteSystemController(IVoteSystemService voteSystemService, IQuestionService questionService)
        {
            _voteSystemService = voteSystemService ?? throw new ArgumentNullException(nameof(voteSystemService));
            _questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
        }

        [HttpGet]
        public ViewResult Index()
        {
            var allVoteSystems = _voteSystemService
                                                .All()
                                                .To<VoteSystemViewModel>()
                                                .ToList();

            return View(allVoteSystems);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoteSystemViewModel model)
        {
            if (!ValidatePostRequest(model))
            {
                return View(model);
            }

            try
            {
                var voteSystemAsDbObject = Mapper.Map<Data.Entities.VoteSystem>(model);
                _voteSystemService.Add(voteSystemAsDbObject);

                this.AddNotification("Успешно създадохте система за гласуване!", NotificationType.Success);
            }
            catch (Exception ex)
            {
                // TODO add logic logic
                this.AddNotification("Възникна грешка при създаването на системата!", NotificationType.Error);
            }

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int voteSystemId)
        {
            if (voteSystemId <= 0)
            {
                // TODO redirect to page 404
                return Content("voteSystemId cannot be negative number or 0");
            }

            var voteSystem = _voteSystemService.GetById(voteSystemId);
            var voteSystemAsViewModel = Mapper.Map<VoteSystemViewModel>(voteSystem);

            return View(voteSystemAsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoteSystemViewModel model)
        {
            if (!ValidatePostRequest(model))
            {
                return View(model);
            }

            try
            {
                var voteSystemAsDbObject = Mapper.Map<Data.Entities.VoteSystem>(model);
                _voteSystemService.Update(voteSystemAsDbObject);

                this.AddNotification("Успешно редактирахте системата за гласуване!", NotificationType.Success);
            }
            catch (Exception ex)
            {
                this.AddNotification("Възникна грешка при редактирането на системата", NotificationType.Error);
            }

            return this.RedirectToAction<VoteSystemController>(c => c.Index());
        }

        [HttpPost]
        public ContentResult Delete(int voteSystemId)
        {
            if (voteSystemId <= 0)
            {
                // TODO redirect to page 404
                return Content("voteSystemId cannot be negative number or 0");
            }

            _voteSystemService.Delete(voteSystemId);

            return Content("DELETED");
        }

        [HttpGet]
        public ActionResult Result(int voteSystemId)
        {
            if (voteSystemId <= 0)
            {
                // TODO redirect to page 404
                return Content("voteSystemId cannot be negative number or 0");
            }

            return View(voteSystemId);
        }

        [HttpGet]
        [AjaxOnly]
        public JsonResult GetVoteSystemResultsById(int voteSystemId)
        {
            if (voteSystemId <= 0)
            {
                return Json("-1", JsonRequestBehavior.AllowGet);
            }

            var result = _questionService
                                .GetQuestionResultByVoteSystemId(voteSystemId)
                                .ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private bool ValidatePostRequest(VoteSystemViewModel model)
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
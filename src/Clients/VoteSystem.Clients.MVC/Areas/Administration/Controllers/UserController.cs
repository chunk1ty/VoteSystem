using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using VoteSystem.Authentication;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Clients.MVC.Infrastructure.NotificationSystem;
using VoteSystem.Clients.MVC.ViewModels;
using VoteSystem.Common;
using VoteSystem.Common.Constants;
using VoteSystem.Data.Services.Contracts;

namespace VoteSystem.Clients.MVC.Areas.Administration.Controllers
{
    public class UserController : AdministrationController
    {
        private IUserService users;
        private IParticipantService participants;
        private IRateSystemService rateSystems;

        public UserController(IUserService users, IParticipantService participants, IRateSystemService rateSystems)
        {
            this.users = users;
            this.participants = participants;
            this.rateSystems = rateSystems;
        }
        
        public ActionResult Add(int rateSystemId)
        {
            //var users = this.users
            //    .GetAllUnselectUsers(rateSystemId)
            //    .To<UserViewModel>()
            //    .ToList();

            //var userSelectedVM = new UserSelectedViewModel()
            //{
            //    Users = users,
            //    RateSystemId = rateSystemId
            //};           

            //return this.View(userSelectedVM);
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(UserSelectedViewModel model)
        {
            //var getSelectedUsers = model.GetSelectedUsers();

            //if (getSelectedUsers.Count == 0)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Трябва да изберете най-малко един учасник.");
            //    return this.View(model);
            //}

            //foreach (var participant in getSelectedUsers)
            //{
            //    var currentParticipant = new Participant()
            //    {
            //        RateSystemId = model.RateSystemId,
            //        // TODO fix it later
            //        //UserId = participant.Id
            //    };

            //    this.participants.Add(currentParticipant);
            //}

            //// TODO use dbContext.savechanges
            ////this.participants.SaveChanges();

            //this.AddNotification("Успешно добавихте учасници!", NotificationType.SUCCESS);

            return this.RedirectToAction<UserController>(c => c.Add(model.RateSystemId));
        }

        public ActionResult Remove(int rateSystemId)
        {
            //var users = this.users
            //    .GetAllSelectUsers(rateSystemId)
            //    .To<UserViewModel>()
            //    .ToList();

            //var userSelectedVM = new UserSelectedViewModel()
            //{
            //    Users = users,
            //    RateSystemId = rateSystemId
            //};

            //return this.View(userSelectedVM);
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(UserSelectedViewModel model)
        {
            //var getSelectedUsers = model.GetSelectedUsers();

            //if (getSelectedUsers.Count == 0)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Трябва да изберете най-малко един учасник.");
            //    return this.View(model);
            //}

            //foreach (var participant in getSelectedUsers)
            //{
            //    var currentParticipant = this.participants.GetParticipantByRateSystemIdAndUserId(model.RateSystemId, participant.Id);

            //    if (currentParticipant == null)
            //    {
            //        throw new ArgumentNullException("Participant can not be found!");
            //    }

            //    this.participants.Remove(currentParticipant);
            //}

            // TODO use dbContext.savechanges
            //this.participants.SaveChanges();

            return this.RedirectToAction<UserController>(c => c.Remove(model.RateSystemId));
        }

        public ActionResult Preview(int rateSystemId)
        {
            //var users = this.users
            //    .GetAllSelectUsers(rateSystemId)
            //    .To<UserViewModel>()
            //    .ToList();

            //var userSelectedVM = new UserSelectedViewModel()
            //{
            //    Users = users,
            //    RateSystemId = rateSystemId
            //};

            //return this.View(userSelectedVM);
            return this.View();
        }

        public async Task<ActionResult> SentEmails(int rateSystemId)
        {
            //var users = this.users
            //    .GetAllSelectUsers(rateSystemId)
            //    .Select(x => x.Email).ToList();

            //var rateSystem = this.rateSystems.GetById(rateSystemId);

            //EmailService email = new EmailService();
            //await email.SendAddedParticipantsAsync(users, rateSystem);

            //this.AddNotification("Успешно изпратихте имейли на всички учасници!", NotificationType.SUCCESS);

            return this.PartialView(PartialViewConstants.SuccessNotificationPartial);
        }
    }
}
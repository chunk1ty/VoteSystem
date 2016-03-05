namespace VoteSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using VoteSystem.Services.Data.Contracts;
    using VoteSystem.Web.Infrastructure.Mapping;
    using VoteSystem.Web.ViewModels;

    public class UserController : AdministrationController
    {
        private IUserService users;

        public UserController(IUserService users)
        {
            this.users = users;
        }
        
        public ActionResult Index()
        {
            var users = this.users
                .GetAll()
                .To<UserViewModel>()
                .ToList();

            var userSelectedVM = new UserSelectedViewModel()
            {
                Users = users
            };           

            return View(userSelectedVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserSelectedViewModel model)
        {
            // get the ids of the items selected:
            var getSelectedUsers = model.GetSelectedUsers();

            // Use the ids to retrieve the records for the selected people
            // from the database:
            //var selectedPeople = from x in Db.People
            //                     where selectedIds.Contains(x.Id)
            //                     select x;

            //// Process according to your requirements:
            //foreach (var person in selectedPeople)
            //{
            //    System.Diagnostics.Debug.WriteLine(
            //        string.Format("{0} {1}", person.firstName, person.LastName));
            //}

            // Redirect somewhere meaningful (probably to somewhere showing 
            // the results of your processing):

            return this.RedirectToAction<UserController>(c => c.Index());
        }
    }
}
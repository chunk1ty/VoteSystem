namespace VoteSystem.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class UserSelectedViewModel
    {
        public UserSelectedViewModel()
        {
            this.Users = new List<UserViewModel>();
        }

        public IList<UserViewModel> Users { get; set; }

        public IList<UserViewModel> GetSelectedUsers()
        {
            return this.Users
                        .Where(u => u.IsSelect)
                        .ToList();
        }
    }
}
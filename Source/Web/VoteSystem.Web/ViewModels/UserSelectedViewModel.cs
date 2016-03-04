namespace VoteSystem.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class UserSelectedViewModel
    {
        public UserSelectedViewModel()
        {
            this.Users = new HashSet<UserViewModel>();
        }

        public IEnumerable<UserViewModel> Users { get; set; }

        public IList<string> GetSelectedUsers()
        {
            return this.Users
                        .Where(u => u.IsSelect)
                        .Select(u => u.Id)
                        .ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace VoteSystem.Clients.MVC.Areas.Administration.Models.User
{
    public class UserSelectedViewModel
    {
        public UserSelectedViewModel()
        {
            this.Users = new List<UserViewModel>();
        }

        public int VoteSystemId { get; set; }

        public IList<UserViewModel> Users { get; set; }

        public IList<UserViewModel> GetSelectedUsers()
        {
            return this.Users
                        .Where(u => u.IsSelect)
                        .ToList();
        }
    }
}
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Data.Entities;

namespace VoteSystem.Clients.MVC.Areas.Administration.Models.User
{
    public class UserViewModel : IMapFrom<VoteSystemUser>
    {
        public string Id { get; set; }

        public bool IsSelect { get; set; }

        public int FN { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsVoted { get; set; }
    }
}
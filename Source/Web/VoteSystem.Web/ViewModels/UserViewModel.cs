namespace VoteSystem.Web.ViewModels
{
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public bool IsSelect { get; set; }

        public int FN { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
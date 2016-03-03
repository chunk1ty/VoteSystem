﻿namespace VoteSystem.Web.ViewModels
{
    using VoteSystem.Web.Infrastructure.Mapping;
    using VoteSystem.Data.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string FN { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
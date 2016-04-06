﻿namespace VoteSystem.Web.ViewModels
{
    using System.Linq;
    using AutoMapper;
    using VoteSystem.Data.Models;
    using VoteSystem.Web.Infrastructure.Mapping;  

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public bool IsSelect { get; set; }

        public int FN { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsVoted { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            //configuration.CreateMap<User, UserViewModel>()
            //    .ForMember(
            //        x => x.IsVoted,
            //        y => y.MapFrom(
            //            z => z.Participants.IsVoted));
        }
    }
}
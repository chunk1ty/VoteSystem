using AutoMapper;
using VoteSystem.Authentication.Models;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;

namespace VoteSystem.Clients.MVC.ViewModels
{
    public class UserViewModel : IMapFrom<AspNetUser>, IHaveCustomMappings
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
            //configuration.CreateMap<AspNetUser, UserViewModel>()
            //    .ForMember(
            //        x => x.IsVoted,
            //        y => y.MapFrom(
            //            z => z.Participants.IsVoted));
        }
    }
}
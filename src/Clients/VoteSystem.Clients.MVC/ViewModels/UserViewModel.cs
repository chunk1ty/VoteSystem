using AutoMapper;
using VoteSystem.Clients.MVC.Infrastructure.Mapping;
using VoteSystem.Data.Models;

namespace VoteSystem.Clients.MVC.ViewModels
{
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
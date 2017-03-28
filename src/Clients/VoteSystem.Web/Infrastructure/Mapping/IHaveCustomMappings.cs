using AutoMapper;

namespace VoteSystem.Clients.MVC.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfiguration configuration);
    }
}

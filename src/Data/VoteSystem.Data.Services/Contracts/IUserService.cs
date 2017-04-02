using System.Linq;
using VoteSystem.Data.DtoModels;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<VoteSystemUserDto> GetAllUnselectUsers(int rateSystemId);

        IQueryable<VoteSystemUserDto> GetAllSelectUsers(int rateSystemId);
    }
}

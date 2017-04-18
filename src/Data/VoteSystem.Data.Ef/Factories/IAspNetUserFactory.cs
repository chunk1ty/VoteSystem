using VoteSystem.Data.Ef.Models;

namespace VoteSystem.Data.Ef.Factories
{
    public interface IIAspNetUserFactory
    {
        AspNetUser CreateAuthUser();
    }
}

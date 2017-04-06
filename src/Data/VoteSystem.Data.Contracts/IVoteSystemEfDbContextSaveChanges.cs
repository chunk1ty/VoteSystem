namespace VoteSystem.Data.Contracts
{
    public interface IVoteSystemEfDbContextSaveChanges
    {
        int SaveChanges();

        void Dispose();
    }
}

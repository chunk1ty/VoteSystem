namespace VoteSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using VoteSystem.Data.Models;

    public interface IVoteSystemDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Question> Questions { get; set; }

        IDbSet<RateSystem> RateSystems { get; set; }

        IDbSet<QuestionAnswer> QuestionAnswers { get; set; }

        IDbSet<UserAnswer> UserAnswers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
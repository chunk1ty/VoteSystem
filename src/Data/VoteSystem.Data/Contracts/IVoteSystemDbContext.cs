using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using VoteSystem.Data.Models;

namespace VoteSystem.Data.Contracts
{
    public interface IVoteSystemDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Participant> Participants { get; set; }

        IDbSet<ParticipantAnswer> ParticipantAnswers { get; set; }

        IDbSet<Question> Questions { get; set; }

        IDbSet<Survey> RateSystems { get; set; }

        IDbSet<QuestionAnswer> QuestionAnswers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
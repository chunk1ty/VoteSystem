﻿using System.Data.Entity;

using VoteSystem.Data.Contracts;
using VoteSystem.Data.Ef.Contracts;
using VoteSystem.Data.Entities;

namespace VoteSystem.Data.Ef.Repositories
{
    public class EfAnswerRepository : IQuestionAnswerRepository
    {
        private readonly IVoteSystemDbContext _voteSystemDbContext;

        public EfAnswerRepository(IVoteSystemDbContext voteSystemDbContext)
        {
            _voteSystemDbContext = voteSystemDbContext;
        }

        public void Add(Answer questionAndAnswers)
        {
            var entry = _voteSystemDbContext.Entry(questionAndAnswers);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                _voteSystemDbContext.QuestionAnswers.Add(questionAndAnswers);
            }
        }
    }
}
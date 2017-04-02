﻿using System.Linq;
using VoteSystem.Data.DtoModels;
using VoteSystem.Data.Models;

namespace VoteSystem.Data.Services.Contracts
{
    public interface IRateSystemService
    {
        void Add(SurveyDto system);

        void Delete(int rateSystemId);

        void Update(SurveyDto system);

        IQueryable<SurveyDto> GetAll();

        IQueryable<SurveyDto> AllActive(string userId);

        SurveyDto GetById(int rateSystemId);
    }
}

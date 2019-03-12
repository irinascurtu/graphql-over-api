﻿using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public class TalksRepository
    {
        private readonly ConferenceDbContext dbContext;

        public TalksRepository(ConferenceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<Talk>> GetAll()
        {
            return dbContext.Talks.Include(s => s.Speaker).ToListAsync(); ;
        }


        public Task<List<Talk>> GetAllForSpeaker(int speakerId)
        {
            return dbContext.Talks.Where(x => x.SpeakerId == speakerId).ToListAsync();
        }

        public Talk GetById(int id)
        {
            var ss = dbContext.Talks.Include(s => s.Speaker).FirstOrDefault(x => x.Id == id);
            return ss;
        }

    }

}

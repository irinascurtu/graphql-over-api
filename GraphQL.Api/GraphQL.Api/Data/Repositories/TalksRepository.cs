using GraphQL.Api.Data.Entities;
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
            return dbContext.Talks.ToListAsync();
        }

        public Task<List<Talk>> GetAllForSpeaker(int speakerId)
        {
            return dbContext.Talks.Where(x => x.SpeakerId == speakerId).ToListAsync();
        }
    }
}

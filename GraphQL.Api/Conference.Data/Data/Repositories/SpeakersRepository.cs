using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public class SpeakersRepository
    {
        private readonly ConferenceDbContext dbContext;

        public SpeakersRepository(ConferenceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<Speaker>> GetAll()
        {
            return dbContext.Speakers.ToListAsync();
        }

        public Task<Speaker> GetById(int id)
        {
            return dbContext.Speakers.FindAsync(id);
        }


        /// <summary>
        /// demo for dataloader
        /// </summary>
        /// <param name="talkIds"></param>
        /// <returns></returns>
        public async Task<ILookup<int, Speaker>> GetAllSpeakersInOneGo(IEnumerable<int> talkIds)
        {
            var speakers = new List<Speaker>();
            speakers = await dbContext.Talks.Where(pr => talkIds.Contains(pr.Id)).Select(x => x.Speaker).ToListAsync();
            return speakers.ToLookup(r => r.Id);
        }

    }
}

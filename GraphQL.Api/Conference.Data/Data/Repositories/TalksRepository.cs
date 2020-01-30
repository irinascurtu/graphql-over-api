using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conference.Data.Data.Repositories
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



        public async Task<IEnumerable<Talk>> GetAllAsync()
        {
            return await dbContext.Talks.ToListAsync();
        }

        public Task<List<Talk>> GetAllForSpeaker(int speakerId)
        {
            return dbContext.Talks.Where(x => x.SpeakerId == speakerId).ToListAsync();
        }

        public Task<Talk> GetById(int id)
        {
            return dbContext.Talks.Include(s => s.Speaker).FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Talk> Add(Talk talk)
        {
            await dbContext.Talks.AddAsync(talk);
            await dbContext.SaveChangesAsync();
            return talk;
        }

    }

}

using Feedbacks.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedbacks.Api.Data.Repositories
{

    public class FeedbackRepository
    {
        private readonly FeedbacksDbContext dbContext;

        public FeedbackRepository(FeedbacksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<Feedback>> GetAll()
        {
            return dbContext.Feedbacks.ToListAsync();
        }


        public async Task<IEnumerable<Feedback>> GetForIds(IEnumerable<int> talkIds)
        {
            return await dbContext.Feedbacks.Where(pr => talkIds.Contains(pr.TalkId)).ToListAsync();
        }

        public Task<List<Feedback>> GetForTalk(int talkId)
        {
            return dbContext.Feedbacks.Where(x => x.TalkId == talkId).ToListAsync();
        }

        public Task<Feedback> GetById(int id)
        {
            return dbContext.Feedbacks.FindAsync(id);
        }

    }
}

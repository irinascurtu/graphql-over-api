using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Data.Infrastructure;

namespace GraphQL.Api.Data.Repositories
{
    public class SpeakersRepository
    {
        private readonly ConferenceDbContext dbContext;

        public SpeakersRepository(ConferenceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

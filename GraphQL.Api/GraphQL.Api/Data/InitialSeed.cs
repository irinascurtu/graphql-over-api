using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Data.Infrastructure;

namespace GraphQL.Api.Data
{
    public static class InitialSeed
    {
        public static void Seed(this ConferenceDbContext dbContext)
        {
            if (!dbContext.Speakers.Any())
            {

            }
        }
    }
}

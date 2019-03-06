using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Infrastructure;
using System.Linq;

namespace GraphQL.Api.Data
{
    public static class InitialSeed
    {
        public static void Seed(this ConferenceDbContext dbContext)
        {
            if (!dbContext.Speakers.Any())
            {
                dbContext.Speakers.Add(new Speaker()
                {
                    CompanyName = "Edava",
                    CompanyWebsite = "http://endava.com",
                    Email = "irina@endava.com",
                    FirstName = "Irina",
                    LastName = "Scurtu",
                    Position = "Design Lead",
                    Description = "lalalaalala",
                    PageSlug = "irina-scurtu"

                });

                dbContext.Speakers.Add(new Speaker()
                {
                    CompanyName = "Edava",
                    CompanyWebsite = "http://endava.com",
                    Email = "irina@endava.com",
                    FirstName = "Irina",
                    LastName = "Scurtu",
                    Position = "Design Lead",
                    Description = "lalalaalala",
                    PageSlug = "irina-scurtu"

                });

                dbContext.Speakers.Add(new Speaker()
                {
                    CompanyName = "Edava",
                    CompanyWebsite = "http://xyz.com",
                    Email = "irina@xyz.com",
                    FirstName = "Irina",
                    LastName = "xyz",
                    Position = "Devops",
                    Description = "lalalaalala",
                    PageSlug = "irina-xyz"

                });

            }

            if (!dbContext.Talks.Any())
            {
                dbContext.Talks.Add(new Talk()
                {
                    Description = "lalaa",
                    Title = "GraphQL",
                    SpeakerId = dbContext.Speakers.First().Id
                });
                dbContext.Talks.Add(new Talk()
                {
                    Description = "lalaa",
                    Title = "Yet another graphql talk 2",
                    SpeakerId = dbContext.Speakers.First().Id
                });

            }
        }
    }
}

using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Infrastructure;
using System.Linq;

namespace GraphQL.Api.Data
{
    public static class InitialSeed
    {
        public static void Seed(this ConferenceDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Speakers.Any())
            {
                dbContext.Speakers.Add(new Speaker()
                {
                    CompanyName = "Microsoft",
                    CompanyWebsite = "http://microsoft.com",
                    Email = "scott@hanselman.com",
                    FirstName = "Scott",
                    LastName = "Hanselman",
                    Position = "Program Manager",
                    Description = "Speaker, Teacher, Coder, Blogger",
                    PageSlug = "scott-hanselman",
                    GitHub = "http:///github.com",
                    LinkedIn = "http:///linkedin.com"

                });

                dbContext.Speakers.Add(new Speaker()
                {
                    CompanyName = "Endava",
                    CompanyWebsite = "http://endava.com",
                    Email = "irinas@endava.com",
                    FirstName = "Irina",
                    LastName = "Scurtu",
                    Position = "Design Lead",
                    Description = "lalalaalala",
                    PageSlug = "irina-scurtu",
                    GitHub = "http:///github.com",
                    LinkedIn = "http:///linkedin.com"
                });

                dbContext.Speakers.Add(new Speaker()
                {
                    CompanyName = "Google",
                    CompanyWebsite = "http://google.com",
                    Email = "irina@xyz.com",
                    FirstName = "Irina",
                    LastName = "xyz",
                    Position = "Devops",
                    Description = "lalalaalala",
                    PageSlug = "irina-xyz",
                    GitHub = "http:///github.com",
                    LinkedIn = "http:///linkedin.com"

                });

            }
            dbContext.SaveChanges();
            if (!dbContext.Talks.Any())
            {
                dbContext.Talks.Add(new Talk()
                {
                    Description = "There is an entire universe outside REST apis. You just need to fly there",
                    Title = "GraphQL",
                    SpeakerId = dbContext.Speakers.First().Id
                });

                dbContext.Talks.Add(new Talk()
                {
                    Description = "this could be a super nice talk, and it was. Super nice, Vital topic",
                    Title = "Yet another graphql talk 2",
                    SpeakerId = dbContext.Speakers.First().Id
                });

            }

            dbContext.SaveChanges();
        }
    }
}

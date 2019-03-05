using GraphQL.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Api.Data.Infrastructure
{
    public class ConferenceDbContext : DbContext
    {


        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options) : base(options)
        {

        }

        public DbSet<Speaker> Speakers { get; set; }
    }
}

using Feedbacks.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedbacks.Api.Data
{
    public class FeedbacksDbContext : DbContext
    {
        public FeedbacksDbContext(DbContextOptions<FeedbacksDbContext> options) : base(options)
        {

        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}


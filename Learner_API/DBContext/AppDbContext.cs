using Learner_API.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Learner_API.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Learner> SEA_LearnerSubscriber { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AM7K2K6;initial Catalog=CourseDB;Integrated Security=True");
        //}
    }
}

using Holism.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Saeed.Quran.DataAccess.DbContexts
{
    public class TopicDbContext : DbContext
    {
        string databaseName;

        public TopicDbContext()
            : base()
        {
        }

        public TopicDbContext(string databaseName)
            : base()
        {
            this.databaseName = databaseName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("SaeedQuran")).AddInterceptors(new PersianInterceptor());
        }

        public ICollection<Saeed.Quran.DataAccess.Models.Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.Topic>().ToTable("Topics");
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.Topic>().Ignore(i => i.RelatedItems);
            base.OnModelCreating(modelBuilder);
        }
    }
}

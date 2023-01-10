using Holism.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Saeed.Quran.DataAccess.DbContexts
{
    public class TopicVerseDbContext : DbContext
    {
        string databaseName;

        public TopicVerseDbContext()
            : base()
        {
        }

        public TopicVerseDbContext(string databaseName)
            : base()
        {
            this.databaseName = databaseName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("SaeedQuran")).AddInterceptors(new PersianInterceptor());
        }

        public ICollection<Saeed.Quran.DataAccess.Models.TopicVerse> TopicVerses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.TopicVerse>().ToTable("TopicVerses");
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.TopicVerse>().Ignore(i => i.RelatedItems);
            base.OnModelCreating(modelBuilder);
        }
    }
}

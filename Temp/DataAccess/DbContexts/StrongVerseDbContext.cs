using Holism.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Saeed.Quran.DataAccess.DbContexts
{
    public class StrongVerseDbContext : DbContext
    {
        string databaseName;

        public StrongVerseDbContext()
            : base()
        {
        }

        public StrongVerseDbContext(string databaseName)
            : base()
        {
            this.databaseName = databaseName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("SaeedQuran")).AddInterceptors(new PersianInterceptor());
        }

        public ICollection<Saeed.Quran.DataAccess.Models.StrongVerse> StrongVerses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.StrongVerse>().ToTable("StrongVerses");
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.StrongVerse>().Ignore(i => i.RelatedItems);
            base.OnModelCreating(modelBuilder);
        }
    }
}

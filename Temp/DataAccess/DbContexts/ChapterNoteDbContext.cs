using Holism.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Saeed.Quran.DataAccess.DbContexts
{
    public class ChapterNoteDbContext : DbContext
    {
        string databaseName;

        public ChapterNoteDbContext()
            : base()
        {
        }

        public ChapterNoteDbContext(string databaseName)
            : base()
        {
            this.databaseName = databaseName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("SaeedQuran")).AddInterceptors(new PersianInterceptor());
        }

        public ICollection<Saeed.Quran.DataAccess.Models.ChapterNote> ChapterNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.ChapterNote>().ToTable("ChapterNotes");
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.ChapterNote>().Ignore(i => i.RelatedItems);
            base.OnModelCreating(modelBuilder);
        }
    }
}

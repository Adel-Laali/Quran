using Holism.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Saeed.Quran.DataAccess.DbContexts
{
    public class VerseNoteDbContext : DbContext
    {
        string databaseName;

        public VerseNoteDbContext()
            : base()
        {
        }

        public VerseNoteDbContext(string databaseName)
            : base()
        {
            this.databaseName = databaseName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("SaeedQuran")).AddInterceptors(new PersianInterceptor());
        }

        public ICollection<Saeed.Quran.DataAccess.Models.VerseNote> VerseNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.VerseNote>().ToTable("VerseNotes");
            modelBuilder.Entity<Saeed.Quran.DataAccess.Models.VerseNote>().Ignore(i => i.RelatedItems);
            base.OnModelCreating(modelBuilder);
        }
    }
}

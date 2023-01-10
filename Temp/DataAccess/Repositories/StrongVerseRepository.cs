using Holism.EntityFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq.Expressions;
using Saeed.Quran.DataAccess.DbContexts;

namespace Saeed.Quran.DataAccess.Repositories
{
    public partial class StrongVerseRepository : Repository<Saeed.Quran.DataAccess.Models.StrongVerse>
    {
        public StrongVerseRepository(string databaseName = null)
            : base(new StrongVerseDbContext(databaseName))
        {
        }

        public override string TableName
        {
            get
            {
                return "[StrongVerses]";
            }
        }

        public override Expression<Func<Saeed.Quran.DataAccess.Models.StrongVerse, bool>> ExistenceFilter(Saeed.Quran.DataAccess.Models.StrongVerse t)
        {
            Expression<Func<Saeed.Quran.DataAccess.Models.StrongVerse, bool>> result = null;
            if (t.Id > 0)
            {
                result = i => i.Id == t.Id;
            }
            else
            {
                result = i => (i.ChapterNumber == t.ChapterNumber && i.ChapterNumber != null) && (i.VerseNumber == t.VerseNumber && i.VerseNumber != null);
            }
            return result;
        }

    }
}

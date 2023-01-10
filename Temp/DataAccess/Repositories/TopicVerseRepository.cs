using Holism.EntityFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq.Expressions;
using Saeed.Quran.DataAccess.DbContexts;

namespace Saeed.Quran.DataAccess.Repositories
{
    public partial class TopicVerseRepository : Repository<Saeed.Quran.DataAccess.Models.TopicVerse>
    {
        public TopicVerseRepository(string databaseName = null)
            : base(new TopicVerseDbContext(databaseName))
        {
        }

        public override string TableName
        {
            get
            {
                return "[TopicVerses]";
            }
        }

        public override Expression<Func<Saeed.Quran.DataAccess.Models.TopicVerse, bool>> ExistenceFilter(Saeed.Quran.DataAccess.Models.TopicVerse t)
        {
            Expression<Func<Saeed.Quran.DataAccess.Models.TopicVerse, bool>> result = null;
            if (t.Id > 0)
            {
                result = i => i.Id == t.Id;
            }
            else
            {
                result = i => (i.ChapterNumber == t.ChapterNumber && i.ChapterNumber != null) && (i.TopicId == t.TopicId && i.TopicId != null) && (i.VerseNumber == t.VerseNumber && i.VerseNumber != null);
            }
            return result;
        }

    }
}

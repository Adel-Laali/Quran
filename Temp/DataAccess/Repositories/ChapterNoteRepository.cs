using Holism.EntityFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq.Expressions;
using Saeed.Quran.DataAccess.DbContexts;

namespace Saeed.Quran.DataAccess.Repositories
{
    public partial class ChapterNoteRepository : Repository<Saeed.Quran.DataAccess.Models.ChapterNote>
    {
        public ChapterNoteRepository(string databaseName = null)
            : base(new ChapterNoteDbContext(databaseName))
        {
        }

        public override string TableName
        {
            get
            {
                return "[ChapterNotes]";
            }
        }

        public override Expression<Func<Saeed.Quran.DataAccess.Models.ChapterNote, bool>> ExistenceFilter(Saeed.Quran.DataAccess.Models.ChapterNote t)
        {
            Expression<Func<Saeed.Quran.DataAccess.Models.ChapterNote, bool>> result = null;
            if (t.Id > 0)
            {
                result = i => i.Id == t.Id;
            }
            else
            {
                result = i => i.Id == t.Id;
            }
            return result;
        }

    }
}

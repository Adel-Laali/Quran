using Holism.EntityFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq.Expressions;
using Saeed.Quran.DataAccess.DbContexts;

namespace Saeed.Quran.DataAccess.Repositories
{
    public partial class QuranNoteRepository : Repository<Saeed.Quran.DataAccess.Models.QuranNote>
    {
        public QuranNoteRepository(string databaseName = null)
            : base(new QuranNoteDbContext(databaseName))
        {
        }

        public override string TableName
        {
            get
            {
                return "[QuranNotes]";
            }
        }

        public override Expression<Func<Saeed.Quran.DataAccess.Models.QuranNote, bool>> ExistenceFilter(Saeed.Quran.DataAccess.Models.QuranNote t)
        {
            Expression<Func<Saeed.Quran.DataAccess.Models.QuranNote, bool>> result = null;
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

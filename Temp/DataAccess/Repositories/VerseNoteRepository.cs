using Holism.EntityFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq.Expressions;
using Saeed.Quran.DataAccess.DbContexts;

namespace Saeed.Quran.DataAccess.Repositories
{
    public partial class VerseNoteRepository : Repository<Saeed.Quran.DataAccess.Models.VerseNote>
    {
        public VerseNoteRepository(string databaseName = null)
            : base(new VerseNoteDbContext(databaseName))
        {
        }

        public override string TableName
        {
            get
            {
                return "[VerseNotes]";
            }
        }

        public override Expression<Func<Saeed.Quran.DataAccess.Models.VerseNote, bool>> ExistenceFilter(Saeed.Quran.DataAccess.Models.VerseNote t)
        {
            Expression<Func<Saeed.Quran.DataAccess.Models.VerseNote, bool>> result = null;
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

using Holism.EntityFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq.Expressions;
using Saeed.Quran.DataAccess.DbContexts;

namespace Saeed.Quran.DataAccess.Repositories
{
    public partial class TopicRepository : Repository<Saeed.Quran.DataAccess.Models.Topic>
    {
        public TopicRepository(string databaseName = null)
            : base(new TopicDbContext(databaseName))
        {
        }

        public override string TableName
        {
            get
            {
                return "[Topics]";
            }
        }

        public override Expression<Func<Saeed.Quran.DataAccess.Models.Topic, bool>> ExistenceFilter(Saeed.Quran.DataAccess.Models.Topic t)
        {
            Expression<Func<Saeed.Quran.DataAccess.Models.Topic, bool>> result = null;
            if (t.Id > 0)
            {
                result = i => i.Id == t.Id;
            }
            else
            {
                result = i => i.Title == t.Title && i.Title != null;
            }
            return result;
        }

    }
}

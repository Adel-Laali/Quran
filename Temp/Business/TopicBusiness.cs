using Holism.Business;
using Holism.EntityFramework;
using Saeed.Quran.DataAccess;
using Saeed.Quran.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saeed.Quran.Business
{
    public class TopicBusiness : Business<Topic, Topic>
    {
        protected override Repository<Topic> ModelRepository => RepositoryFactory.Topic;

        protected override ViewRepository<Topic> ViewRepository => RepositoryFactory.Topic;
    }
}

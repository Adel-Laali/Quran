using Holism.Business;
using Holism.EntityFramework;
using Saeed.Quran.DataAccess;
using Saeed.Quran.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saeed.Quran.Business
{
    public class TopicVerseBusiness : Business<TopicVerse, TopicVerse>
    {
        protected override Repository<TopicVerse> ModelRepository => RepositoryFactory.TopicVerse;

        protected override ViewRepository<TopicVerse> ViewRepository => RepositoryFactory.TopicVerse;
    }
}

namespace Saeed.Quran.DataAccess.Models
{
    public class TopicVerse : Holism.EntityFramework.IEntity
    {
        public TopicVerse()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public long TopicId { get; set; }

        public int ChapterNumber { get; set; }

        public int VerseNumber { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}

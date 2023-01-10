namespace Saeed.Quran.DataAccess.Models
{
    public class ChapterNote : Holism.EntityFramework.IEntity
    {
        public ChapterNote()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public int ChapterNumber { get; set; }

        public string Note { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}

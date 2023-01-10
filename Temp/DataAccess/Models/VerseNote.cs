namespace Saeed.Quran.DataAccess.Models
{
    public class VerseNote : Holism.EntityFramework.IEntity
    {
        public VerseNote()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public int ChapterNumber { get; set; }

        public int VerseNumber { get; set; }

        public string Note { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}

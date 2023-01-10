namespace Saeed.Quran.DataAccess.Models
{
    public class StrongVerse : Holism.EntityFramework.IEntity
    {
        public StrongVerse()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public int ChapterNumber { get; set; }

        public int VerseNumber { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}

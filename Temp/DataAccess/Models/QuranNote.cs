namespace Saeed.Quran.DataAccess.Models
{
    public class QuranNote : Holism.EntityFramework.IEntity
    {
        public QuranNote()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}

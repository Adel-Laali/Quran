namespace Saeed.Quran.DataAccess.Models
{
    public class Topic : Holism.EntityFramework.IEntity
    {
        public Topic()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}

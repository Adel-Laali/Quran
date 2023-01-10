using Data.Quran.Business;
using Holism.Business;
using Holism.EntityFramework;
using Holism.Framework;
using Holism.Validation;
using Saeed.Quran.DataAccess;
using Saeed.Quran.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Saeed.Quran.Business
{
    public class VerseNoteBusiness : Business<VerseNote, VerseNote>
    {
        protected override Repository<VerseNote> ModelRepository => RepositoryFactory.VerseNote;

        protected override ViewRepository<VerseNote> ViewRepository => RepositoryFactory.VerseNote;

        protected override void ModifyListBeforeReturning(List<VerseNote> items)
        {
            var chapterNumbers = items.Select(i => (long)i.ChapterNumber).ToList();
            var chapters = new ChapterBusiness().GetList(chapterNumbers);
            foreach (var item in items)
            {
                item.RelatedItems.Chapter = chapters.Single(i => i.Number == item.ChapterNumber);
            }
            base.ModifyListBeforeReturning(items);
        }

        public override void Validate(VerseNote model)
        {
            model.ChapterNumber.Ensure().IsGreaterThanZero("سوره صحیح نیست").And().IsLessThanOrEqualTo(114, "شماره آخرین سوره 114 باید باشه");
            var chapter = new ChapterBusiness().Get(model.ChapterNumber);
            model.VerseNumber.Ensure().IsGreaterThanZero("ایه صحیح نیست").And().IsLessThanOrEqualTo(chapter.LastVerseNumber.Value, $"سوره {chapter.Title} {chapter.LastVerseNumber} آیه داره.");
            model.Note.Ensure().IsSomething("نکته خالی است");
            base.Validate(model);
        }

        public List<VerseNote> GetNotes(int chapter, int verse)
        {
            var notes = GetList(i => i.ChapterNumber == chapter && i.VerseNumber == verse);
            return notes;
        }
    }
}

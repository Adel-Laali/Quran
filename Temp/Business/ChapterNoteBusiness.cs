using Data.Quran.Business;
using Holism.Business;
using Holism.EntityFramework;
using Holism.Validation;
using Saeed.Quran.DataAccess;
using Saeed.Quran.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saeed.Quran.Business
{
    public class ChapterNoteBusiness : Business<ChapterNote, ChapterNote>
    {
        protected override Repository<ChapterNote> ModelRepository => RepositoryFactory.ChapterNote;

        protected override ViewRepository<ChapterNote> ViewRepository => RepositoryFactory.ChapterNote;

        protected override void ModifyListBeforeReturning(List<ChapterNote> items)
        {
            var chapterNumbers = items.Select(i => (long)i.ChapterNumber).ToList();
            var chapters = new ChapterBusiness().GetList(chapterNumbers);
            foreach (var item in items)
            {
                item.RelatedItems.Chapter = chapters.Single(i => i.Number == item.ChapterNumber);
            }
            base.ModifyListBeforeReturning(items);
        }

        public override void Validate(ChapterNote model)
        {
            model.ChapterNumber.Ensure().IsGreaterThanZero("سوره صحیح نیست").And().IsLessThanOrEqualTo(114, "شماره آخرین سوره 114 باید باشه");
            model.Note.Ensure().IsSomething("نکته خالی است");
            base.Validate(model);
        }

        public List<ChapterNote> GetNotes(int chapter)
        {
            var notes = GetList(i => i.ChapterNumber == chapter);
            return notes;
        }
    }
}

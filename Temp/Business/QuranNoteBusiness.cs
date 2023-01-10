using Holism.Business;
using Holism.EntityFramework;
using Holism.Validation;
using Saeed.Quran.DataAccess;
using Saeed.Quran.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saeed.Quran.Business
{
    public class QuranNoteBusiness : Business<QuranNote, QuranNote>
    {
        protected override Repository<QuranNote> ModelRepository => RepositoryFactory.QuranNote;

        protected override ViewRepository<QuranNote> ViewRepository => RepositoryFactory.QuranNote;

        public override void Validate(QuranNote model)
        {
            model.Note.Ensure().IsSomething("نکته خالی است");
            base.Validate(model);
        }
    }
}

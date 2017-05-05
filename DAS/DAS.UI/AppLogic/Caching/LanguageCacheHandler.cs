using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAS.UI.AppLogic.CacheModels;
using DAS.Domain.Model;

namespace DAS.UI.AppLogic.Caching
{
    public class LanguageCacheHandler : CacheHandler<IList<LanguageDTO>>
    {
        public LanguageCacheHandler(string key, bool loadImmediately) : base(key, loadImmediately) { }
        protected override IList<LanguageDTO> LoadFromDB()
        {
            using (DASEntities db = new DASEntities())
            {
                List<LanguageDTO> languages = new List<LanguageDTO>();
                IQueryable<Language> dbLanguages = db.Languages.OrderBy(lng => lng.LanguageId);
                foreach (var dbLanguage in dbLanguages)
                {
                    languages.Add(new LanguageDTO() { LanguageId = dbLanguage.LanguageId, Name = dbLanguage.Name });
                }
                return languages;
            }
        }
    }
}
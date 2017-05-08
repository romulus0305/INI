using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INIGroup.Domain.Model;

namespace INIGroup.AppLogic.Caching
{
    public class LanguageCacheHandler : CacheHandler<IList<Language>>
    {
        public LanguageCacheHandler(string key, bool loadImmediately) : base(key, loadImmediately) { }
        protected override IList<Language> LoadFromDB()
        {
            using (INIGroupEntities db = new INIGroupEntities())
            {
                List<Language> languages = new List<Language>();
                IQueryable<Language> dbLanguages = db.Languages.OrderBy(lng => lng.LanguageId);
                foreach (var dbLanguage in dbLanguages)
                {
                    languages.Add(new Language() { LanguageId = dbLanguage.LanguageId, Name = dbLanguage.Name });
                }
                return languages;
            }
        }
    }
}
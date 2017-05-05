using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DAS.Backoffice.AppLogic.Caching {

    public class GlobalCache
    {       
        public LanguageCacheHandler LanguageCache { get; private set; }
    
        private GlobalCache() 
        {
            
            this.LanguageCache = new LanguageCacheHandler("DAS_Languages", true);
        }

        private static GlobalCache _instance;

        public static GlobalCache GetInstance() 
        {
            if (_instance == null) 
            {
                _instance = new GlobalCache();
            }
            return _instance;
        }

    }
}
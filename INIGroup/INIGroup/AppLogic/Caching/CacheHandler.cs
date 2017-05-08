using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INIGroup.AppLogic.Caching
{
 public abstract class CacheHandler<T> where T : class {
        protected string _cacheKey;
        protected object _cacheLock = new object();
        protected abstract T LoadFromDB();
        public T Data {
            get {
                T data = (T)HttpContext.Current.Cache[_cacheKey];
                if (data == null) {
                    lock (_cacheLock) {
                        data = (T)HttpContext.Current.Cache[_cacheKey];
                        if (data == null) {
                            data = SetupData();
                        }
                    }
                }
                return data;
            }
        }
        public T SetupData() {
            T data = LoadFromDB();
            HttpContext.Current.Cache.Add( 
                _cacheKey,
                data,
                new System.Web.Caching.CacheDependency(System.Web.HttpContext.Current.Server.MapPath("~/AppLogic/Caching/CacheVersion.txt")),
                System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(
                        int.Parse(System.Configuration.ConfigurationManager.AppSettings["CacheDurationHours"]),
                        int.Parse(System.Configuration.ConfigurationManager.AppSettings["CacheDurationMinutes"]),
                        int.Parse(System.Configuration.ConfigurationManager.AppSettings["CacheDurationSeconds"])
                        ),
                System.Web.Caching.CacheItemPriority.Default,
                null);
            return data;
        }
        public void ClearCache() {
            lock (_cacheLock) {
                if (HttpContext.Current.Cache[_cacheKey] != null) {
                    HttpContext.Current.Cache.Remove(_cacheKey);
                }
            }
        }
        public CacheHandler(string key, bool loadImmediately) {
            this._cacheKey = key;
            if (loadImmediately) SetupData(); 
        }
        private CacheHandler() { }
    }
}
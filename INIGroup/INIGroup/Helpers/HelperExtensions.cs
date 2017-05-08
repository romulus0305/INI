using INIGroup.AppLogic.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INIGroup.Helpers
{
    public static class HelperExtensions
    {
        // TODO: label extractor
        public static string INIGroupLabel(this HtmlHelper helper, string viewId, string elementId)
        {
            return LabelCache.GetLabel(viewId, elementId);
        }

        public static string INIGroupLabel(string viewId, string elementId)
        {
            return LabelCache.GetLabel(viewId, elementId);
        }
    }
}
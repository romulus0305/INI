

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Backoffice.AppLogic.Caching;

namespace DAS.Backoffice.Helpers
{
    public static class HelperExtensions
    {
      // TODO: label extractor
        public static string PTPLabel(this HtmlHelper helper, string viewId, string elementId)
        {
            return LabelCache.GetLabel(viewId, elementId);
        }
    }
}
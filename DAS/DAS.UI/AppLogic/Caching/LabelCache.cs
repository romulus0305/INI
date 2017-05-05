
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAS.Domain.Model;
using System.Web.Configuration;


namespace DAS.UI.AppLogic.Caching
{
    public static class LabelCache
    {
        private class LabelsHandler : CacheHandler<Dictionary<string, Dictionary<string, string>>>
        {
            protected override Dictionary<string, Dictionary<string, string>> LoadFromDB()
            {
                return new Dictionary<string, Dictionary<string, string>>();
            }
            public LabelsHandler(string key)
                : base(key, false)
            {
            }
        }

        private static LabelsHandler labels = new LabelsHandler("PTP_Labels");

        public static string GetLabel(string viewId, string elementId)
        {
            string imagesPath = WebConfigurationManager.AppSettings["imagesPath"];
            if (HttpContext.Current.Session["lngId"] == null)
            {
                HttpContext.Current.Session["lngId"] = 1;
            };
            Dictionary<string, string> viewLabels;
            if (labels.Data.ContainsKey(viewId))
            {
                viewLabels = labels.Data[viewId];
            }
            else
            {
                viewLabels = new Dictionary<string, string>();
                DASEntities db = new DASEntities();
                var dbLabels = db.Labels.Where(lb => lb.ViewId == viewId);
                if (!dbLabels.Any())
                {
                    throw new Exception("Invalid viewId");
                }
                foreach (var dbLabel in dbLabels)
                {
                    if (viewId == "Home")
                    {
                        viewLabels.Add(dbLabel.ElementId + "_" + dbLabel.LanguageId, dbLabel.Text.Replace("../Content/", imagesPath));
                    }
                    else {

                        viewLabels.Add(dbLabel.ElementId + "_" + dbLabel.LanguageId, dbLabel.Text);
                    }
                   
                  //  viewLabels.Add(dbLabel.ElementId + "_" + dbLabel.LanguageId, dbLabel.Text.Replace("../Content/", "../DAS/Content/"));
                }
            }
          
            string labelKey = elementId + "_" + HttpContext.Current.Session["lngId"];
            if (!viewLabels.ContainsKey(labelKey) && (int)HttpContext.Current.Session["lngId"] != 1)
            {
                labelKey = elementId + "_1";
            }
            return viewLabels[labelKey];
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using DAS.Backoffice.Models.News;
using System.Web;
using DAS.Domain.Model;
using DAS.Backoffice.AppLogic.Caching;


namespace DAS.Backoffice.Builders.Home
{
    public class NewsBuilder
    {

        public static NewsListModel BuildNews(DASEntities db)
        {
            NewsListModel model = new NewsListModel();
           
            
            int languageId = (int)HttpContext.Current.Session["lngId"];
            model.NewsList = db.News.Where(l => l.LanguageId == languageId && l.Archive==false ).Select(n => new NewsModel() { NewsId = n.NewsId, Name = n.Name, Text = n.Text, Year = n.Year, Ord = n.Ord, Archive=n.Archive, LanguageId=n.LanguageId }).OrderByDescending(l => l.Year).ThenByDescending(l=> l.Ord).ToList();
        
            IList<int> pomArch = db.News.Include("Archive").Where(l => l.LanguageId == languageId && l.Archive == true).Select(k => k.Archives.FirstOrDefault().ArchiveId).Distinct().ToList();
           
            string archiveLbl = LabelCache.GetLabel("Home", "lblArchive");
            string newsLbl = LabelCache.GetLabel("Home", "lblNovosti");
            
            var list = db.Archives.OrderByDescending(l=>l.Year).ToList();
            model.ArchiveList = new List<ArchiveModel>();
            foreach (var item in pomArch)
            {
                Archive temp = list.OrderByDescending(m=>m.Year).FirstOrDefault(b => b.ArchiveId == item);
                model.ArchiveList.Add(new ArchiveModel() { ArchiveId =temp.ArchiveId, Name = archiveLbl + " " + temp.Year });    
            }

            model.ArchiveList.Add(new ArchiveModel() { ArchiveId = 0, Name = newsLbl });
            model.ArchiveList = model.ArchiveList.OrderByDescending(m => m.ArchiveId).ToList();
            model.SelectedArchiveId = 0;
            
            return model;
        }

        public static IList<NewsModel> BuildArchivedNews(DASEntities db, int ArchiveId)
        {

            int languageId = (int)HttpContext.Current.Session["lngId"];           
            Archive temp = db.Archives.Include("News").Where(j => j.ArchiveId == ArchiveId).FirstOrDefault();
            
            IList<NewsModel> list = new List<NewsModel>();
            foreach (News tempC in temp.News)
            {
               
                if (languageId == tempC.LanguageId)
                {
                    NewsModel news = new NewsModel() { NewsId = tempC.NewsId, Name = tempC.Name, Text = tempC.Text, Year = tempC.Year, Ord = tempC.Ord, Archive = tempC.Archive, LanguageId = tempC.LanguageId };
                    list.Add(news);
                }
                
            }
            
            return list;
        }

        public static IList<NewsModel> BuildCurrentNews(DASEntities db)
        {
             int languageId = (int)HttpContext.Current.Session["lngId"];
            IList<NewsModel> model = db.News.Where(l => l.LanguageId == languageId && l.Archive==false ).Select(n => new NewsModel() { NewsId = n.NewsId, Name = n.Name, Text = n.Text, Year = n.Year, Ord = n.Ord, Archive=n.Archive, LanguageId=n.LanguageId }).OrderByDescending(l => l.Year).ThenBy(l=> l.Ord).ToList();

            

            return model;
        }
    }
}
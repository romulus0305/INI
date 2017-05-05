using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DAS.Backoffice.Models.News
{
    public class NewsListModel
    {
        public IList<NewsModel> NewsList { get; set; }
        public int SelectedArchiveId { get; set; }
        public IList<ArchiveModel> ArchiveList { get; set; }
        public String ContentRight { get; set; }
       
    }
}
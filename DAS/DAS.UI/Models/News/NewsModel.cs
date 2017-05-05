using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.UI.Models.News
{
    public class NewsModel
    {
        public int NewsId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Year { get; set; }
        public int Ord { get; set; }
        public int LanguageId { get; set; }
        public bool Archive { get; set; }
       
    }
}
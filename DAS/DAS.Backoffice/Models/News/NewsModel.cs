using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DAS.Backoffice.Models.News
{
    public class NewsModel
    {
        public int NewsId { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Name { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Text { get; set; }
       [UIHint("tinymce_jquery_full"), AllowHtml]
        public int Year { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public int Ord { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public int LanguageId { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public bool Archive { get; set; }
       
    }
}
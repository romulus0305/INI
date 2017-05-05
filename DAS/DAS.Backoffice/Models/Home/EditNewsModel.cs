using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DAS.Backoffice.Models.Home
{
    public class EditNewsModel
    {
        
        public int newsId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Year { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public String ContentTextEditor { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DAS.Backoffice.Models.Home
{
    public class HomeModel
    {
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public String ContentLeft { get; set; }
         [UIHint("tinymce_jquery_full"), AllowHtml]
        public String ContentRight { get; set; }
         [UIHint("tinymce_jquery_full"), AllowHtml]
        public String LeftLink { get; set; }
         [UIHint("tinymce_jquery_full"), AllowHtml]
        public String ContentRightDoc { get; set; }
         [UIHint("tinymce_jquery_full"), AllowHtml]
        public String ContentRightBottom { get; set; }
      
       
    }
}
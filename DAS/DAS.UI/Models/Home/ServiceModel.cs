using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DAS.UI.Models.Home
{
    public class ServiceModel : Controller
    {
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentLeft { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentRight { get; set; }

    }
}

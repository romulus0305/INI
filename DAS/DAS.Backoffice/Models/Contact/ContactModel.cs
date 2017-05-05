using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace DAS.Backoffice.Models.Contact
{
    public class ContactModel
    {
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentLeft { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ContentRight { get; set; }
    }
}
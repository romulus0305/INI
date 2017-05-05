using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DAS.Backoffice.Models.Home
{
    public class EditModel
    {
        [UIHint("tinymce_jquery_full")]
        public String ContentTextEditor { get; set; }
        public string ViewId { get; set; }  
        public string ElementId { get; set; }

    }
}
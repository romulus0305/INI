using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Backoffice.Models.Application
{
    public class ApplicationCategory
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string TotalPermanent { get; set; }
        public string TotalTemporary { get; set; }
        public int ApplicationId { get; set; }

    }
}
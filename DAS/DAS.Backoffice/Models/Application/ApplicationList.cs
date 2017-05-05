using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IniCore.Web.Mvc.Html;


namespace DAS.Backoffice.Models.Application
{
    public class ApplicationList
    {
        public IList<ApplicationForm> ListOfApplication { get; set; }
        public GridDescriptor Descriptor { get; set; }
    }
}
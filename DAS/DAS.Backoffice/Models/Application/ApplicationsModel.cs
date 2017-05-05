using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAS.Backoffice.Models.Home;
namespace DAS.Backoffice.Models.Application
{
    public class ApplicationsModel
    {
        public ApplicationListFilterModel Filters { get; set; }
        public ApplicationList Applications { get; set; }
    }
}
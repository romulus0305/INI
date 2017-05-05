using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Backoffice.Models.Application
{
    public class ApplicationLocationActivities
    {
        public int id {get; set;}
        public string location {get; set;}
        public string activity {get; set;}
        public int applicationId {get; set;}
    }
}
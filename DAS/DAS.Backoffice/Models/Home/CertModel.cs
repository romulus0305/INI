using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Backoffice.Models.Home
{
    public class CertModel
    {
        public int CertId { get; set; }
        public string Standard { get; set; }
        public string CertName { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
        public IList<StatusModel> Statuses { get; set; }

    }
}
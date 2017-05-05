using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.UI.Models.Home
{
    public class ClientsModel
    {
        public FilterModel Filters { get; set; }
        public ClientList Clients { get; set; }
    }
}
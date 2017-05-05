using IniCore.Web.Mvc.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.UI.Models.Home
{
    public class ClientList
    {
        public IList<ClientModel> ListOfClients { get; set; }
        public GridDescriptor Descriptor { get; set; }
    }
}
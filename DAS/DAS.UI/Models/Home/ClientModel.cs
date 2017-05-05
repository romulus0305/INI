﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.UI.Models.Home
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public IList<CertModel> Certificates { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.UI.Models.Home
{
    public class FilterModel
    {
        public string Name { get; set; }
        public string Standard { get; set; }
        public int SelectedStatusId { get; set; }
        public IList<StatusModel> Statuses { get; set; }
    }
}
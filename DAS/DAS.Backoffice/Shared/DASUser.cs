using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Backoffice.Shared
{
    public class DASUser
    {
        public int SelectedLanguageId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsDASUser { get; set; }




        public static DASUser GetLogggedUser()
        {
            if (HttpContext.Current.Session["DASUser"] != null)
            {
                DASUser l = (DASUser)HttpContext.Current.Session["DASUser"];
                return l;
            }
            else
            {
                return null;
            }
        }

     
    }

        

}
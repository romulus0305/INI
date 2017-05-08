using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INIGroup.Domain.Model;
using INIGroup.AppLogic.Caching;

namespace INIGroup.Controllers
{
    public class HomeController : Controller
    {
        private INIGroupEntities db = new INIGroupEntities();

        protected INIGroupEntities Db { get { return db; } }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            string temp = INIGroup.AppLogic.Caching.LabelCache.GetLabel("Contact", "lblContact");
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Quality()
        {
            return View();
        }
    
    
    
    
    
    
    
    
    
    
    
    }











}

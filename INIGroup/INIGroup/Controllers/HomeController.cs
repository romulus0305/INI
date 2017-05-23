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
        public ActionResult ChangeLanguage(int LanguageId)
        {
            HttpContext.Session["lngId"] = LanguageId;
            return Json(new { success = true });
        }
        public ActionResult Index()
        {
            string temp = LabelCache.GetLabel("Customers", "lbl3");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Link = 13;
            return View();
        }

        public ActionResult Quality()
        {
            ViewBag.Link = 12;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Link = 11;
            return View();
        }

        public ActionResult News()
        {
            ViewBag.Link = 10;
            return View();
        }

        public ActionResult Customers()
        {
            
            return View();
        }

        public ActionResult Testimoni()
        {

            return View();
        }

        public ActionResult CaseStudies()
        {

            return View();
        }
         public ActionResult isoCert()
        {

            return View();
        }
         public ActionResult Education()
         {

             return View();
         }

         public ActionResult Benefit()
         {

             return View();
         }


         public ActionResult Apps()
         {

             return View();
         }

         public ActionResult Intranet()
         {

             return View();
         }

         public ActionResult E_engeniring() 
         {
             return View(); 
         }


         public ActionResult App_examples() 
         {
             return View();
         }

         public ActionResult Infrastructure()
         {
             return View();
         }




    }











}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.UI.Models.Home;
using DAS.UI.Models.Application;
using DAS.UI.Models.News;
using DAS.UI.AppLogic._Global;
using DAS.Domain.Model;
using DAS.UI.Builders.Home;
using IniCore.Web.Mvc.Html;
using IniCore.Web.Mvc;
using DAS.UI.Mail;
using System.Data;
using System.Web.UI.WebControls;

namespace DAS.UI.Controllers
{

   
    public class HomeController : DASController
    {
        //
        // GET: /Home/
        public ActionResult ChangeLanguage(int LanguageId)
        {
            HttpContext.Session["lngId"] = LanguageId;
            return Json(new { success = true });
        }

        public ActionResult Index()
        {
            ViewBag.Link = 1;
            int lngId = 1;
            if (Int32.TryParse(Request.QueryString["lng"], out lngId)) {
                HttpContext.Session["lngId"] = lngId;
            }
            return View();
        }

        public ActionResult Welcome()
        {
            ViewBag.Link = 1;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Link = 5;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Link = 8;

            return View();
        }

        public ActionResult Offers()
        {

            ViewBag.Link = 2;
            return View();
        }

        public ActionResult Application()
        {
            ViewBag.Link = 6;
       
            return View();
        }
        public ActionResult ApplicationForm()
        {
            ViewBag.Link = 6;
            DAS.UI.Models.Application.ApplicationForm form = new DAS.UI.Models.Application.ApplicationForm();
            form.Categories = new List<ApplicationCategory>();
      
            form.Categories.Add(new ApplicationCategory() { Category = " ", TotalPermanent = " ", TotalTemporary = " " });
            form.Categories.Add(new ApplicationCategory() { Category = " ", TotalPermanent = " ", TotalTemporary = " " });
            form.Categories.Add(new ApplicationCategory() { Category = " ", TotalPermanent = " ", TotalTemporary = " " });
            form.Categories.Add(new ApplicationCategory() { Category = " ", TotalPermanent = " ", TotalTemporary = " " });
            
            form.locationActivities= new List<ApplicationLocationActivities>();
            form.locationActivities.Add(new ApplicationLocationActivities(){ location="" , activity=" "});
       
            form.LanguageId = (int)Session["lngId"];
            return View(form);
        }
        public ActionResult Clients() {
            if (HttpContext.Session["lngId"] == null) {
                HttpContext.Session["lngId"] = 1;
            }
            ClientsModel model = HomeBuilder.BuildClients(Db);
            ViewBag.Link = 3;
            return View(model);
        }

        public JsonResult FindClients(FilterModel filters, GridDescriptor request)
        {
            ClientList model = HomeBuilder.FilterClients(Db, request, filters);
            return Json(ResponseStatus.Success, RenderPartialViewToString("ClientList", model));
        }

       

        public ActionResult News()
        {
            NewsListModel model = NewsBuilder.BuildNews(Db);

            ViewBag.Link = 4;
            return View(model);

        }

        public JsonResult OpenArchive(int ArchiveId)
        {

            IList<NewsModel> model = NewsBuilder.BuildArchivedNews(Db,ArchiveId);
            return Json(ResponseStatus.Success, RenderPartialViewToString("OpenNews", model));
        }

        public ActionResult Services()
        {
            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }


            ViewBag.Link = 7;


            ServiceModel model = new ServiceModel();
            model.ContentLeft = Db.Labels.Where(m => m.ViewId == "Services" && m.ElementId == "ContentLeft" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRight = Db.Labels.Where(m => m.ViewId == "Services" && m.ElementId == "ContentRight" && m.LanguageId == lngId).FirstOrDefault().Text;

            return View(model);
        }

      
        public ActionResult OpenClientDetails(int ClientId)
        {           
           ClientModel model = ClientDetailsBuilder.Build(ClientId, Db);
           model.ClientId = ClientId;
           return Json(ResponseStatus.Success, RenderPartialViewToString("OpenClientDetails", model));
          
        }
        public JsonResult OpenCurrentNews()
        {

            IList<NewsModel> model = NewsBuilder.BuildCurrentNews(Db);
            return Json(ResponseStatus.Success, RenderPartialViewToString("OpenNews", model));
        }

        public ActionResult AddCategoryEditor()
        {
            ApplicationCategory model = new ApplicationCategory();
            return Json(ResponseStatus.Success, RenderPartialViewToString("AddCategory", model), JsonRequestBehavior.AllowGet);
        }

       
        public JsonResult AddCategory(string text, string tt, string tp, IList<ApplicationCategory> categories)
        {

            ApplicationCategory model = new ApplicationCategory();
            model.Category = text;
            model.TotalPermanent = tp;
            model.TotalTemporary = tt;
            categories.Add(model);
            return Json(ResponseStatus.Success, RenderPartialViewToString("ApplicationCategory", categories));


        }


        public JsonResult SubmitApplication(DAS.UI.Models.Application.ApplicationForm model, IList<ApplicationCategory> categories, IList<AppFormLocationActivity> locAct)
        {
             int lngId = (int)Session["lngId"];



            DAS.Domain.Model.ApplicationForm af = new  DAS.Domain.Model.ApplicationForm();
            af.ApllicationId = Db.ApplicationForms.Select(j => j.ApllicationId).Max() + 1;
            af.ISO9001 = model.ISO9001;
            af.ISO14001 = model.ISO14001;
            af.BSOHSAS18001 = model.BSOHSAS18001;
            af.ISO27001 = model.ISO27001;
            af.ISO22301 = model.ISO22301;
            af.OtherIso = model.OtherIso;
            af.Other = model.Other;

            af.CompanyName = model.CompanyName;
            af.Adress = model.Adress;
           // af.Place = model.Place;
            af.Telephone = model.Telephone;
            af.Extension = model.Extension;
            af.Email = model.Email;
            af.CompanyWebsite = model.CompanyWebsite;

            af.ManagementRepresentativeName = model.ManagementRepresentativeName;
            af.JobTitle = model.JobTitle;
            af.PrimaryContactForAuditPurposes = model.PrimaryContactForAuditPurposes;
            af.PrimaryContactTelephone = model.PrimaryContactTelephone;
            af.NameOfConsultant = model.NameOfConsultant;
            af.ConsultantTelephone = model.ConsultantTelephone;
            af.NatureOfBusiness = model.NatureOfBusiness;
            af.NumberOfYearsAtThisSite = model.NumberOfYearsAtThisSite;
            //af.PrincipleServicesOrProducts = model.PrincipleServicesOrProducts;
            af.ActivitiesOnClientsSites = model.ActivitiesOnClientsSites;

            af.ISO9001_2 = model.ISO9001_2;
            af.ISO14001_2 = model.ISO14001_2;
            af.BSOHSAS18001_2 = model.BSOHSAS18001_2;
            af.ISO27001_2 = model.ISO27001_2;
            af.ISO22301_2 = model.ISO22301_2;
            af.OtherIso_2 = model.OtherIso_2;
            af.Other_2 = model.Other_2;

            af.StandardTransferred = model.StandardTransferred;
            af.NameOfPresentCertificationBody = model.NameOfPresentCertificationBody;
            af.CertificateExpiryDate = model.CertificateExpiryDate;
            af.DateNextCertificationBodyVisit = model.DateNextCertificationBodyVisit;
            //af.TotalNumberOfEmployees = model.TotalNumberOfEmployees;
            //af.TotalNumberOfCompanyDirectors = model.TotalNumberOfCompanyDirectors;
            af.NumberOfLocations = model.NumberOfLocations;
            //af.AllSitesMainActivites = model.AllSitesMainActivites;
            af.TotalPermanent = model.TotalPermanent;
            af.TotalTemporary = model.TotalTemporary;
            af.Applicant = model.Applicant;
            af.DateCreated = DateTime.Now;
         


            Db.ApplicationForms.Add(af);
            Db.SaveChanges();

            ApplicationFormCatagory list = new ApplicationFormCatagory();
            ApplicationFormCatagory temp;
            
            int tp=0;
            int tt=0;

            foreach (var item in categories)
            {

                if (item.Category != " " && item.Category != null)
                {
                temp = new ApplicationFormCatagory();
                temp.CategoryId = Db.ApplicationFormCatagories.Select(j => j.CategoryId).Max() + 1;
                temp.ApplicationId = af.ApllicationId;
                temp.Category = item.Category;
                temp.TotalPermanent = item.TotalPermanent;
                temp.TotalTemporary = item.TotalTemporary;



                if (item.TotalPermanent != " " && item.TotalPermanent !=null)
                {
                    tp += Int32.Parse(item.TotalPermanent);
                }

                if (item.TotalTemporary != " " && item.TotalTemporary != null)
                {
                    tt += Int32.Parse(item.TotalTemporary);
                }

                Db.ApplicationFormCatagories.Add(temp);
                Db.SaveChanges(); 
                }
            }

            af.TotalPermanent = tp.ToString();
            af.TotalTemporary = tt.ToString();
            Db.SaveChanges(); 

            AppFormLocationActivity listLA = new AppFormLocationActivity();
            AppFormLocationActivity pom;


            foreach (var loc in locAct)
            {

                if (loc.Activity != " " && loc.Location != " " && loc.Activity !=null && loc.Location !=null)
                {
                pom = new AppFormLocationActivity();
                pom.Id = Db.AppFormLocationActivities.Select(j => j.Id).Max() + 1;
                pom.ApplicationId = af.ApllicationId;
                pom.Activity = loc.Activity;
                pom.Location = loc.Location;
                Db.AppFormLocationActivities.Add(pom);
                Db.SaveChanges();
                }
            }


    
            bool OK = Mailer.Send(Db, af);
            string message;
            if (lngId == 1)
            {
                message = "Prijava je uspešno poslata.";
            }else if(lngId == 2){
                message = "Пријавата е успешно пратена.";
            }
            else if (lngId == 3)
            {
                message = "Prijava je uspješno poslata.";
            }else {

                message = "The application was sent successfully.";
            }
            if (!OK)
            {

                if (lngId == 1)
                {
                    message = "Došlo je do problema. Molim Vas, pokušajte ponovo.";
                }
                else if (lngId == 2)
                {
                    message = "Настана проблем. Ве молиме обидете се повторно.";
                }
                else if (lngId == 3)
                {
                    message = "Došlo je do problema. Molim Vas, probajte ponovo.";
                }
                else
                {

                    message = "A problem has occurred. Please try again.";
                }
              
                return Json(ResponseStatus.Error, message);
            }
            else return Json(ResponseStatus.Success, message);

        }


        public ActionResult AddLocationActivityEditor()
        {
            ApplicationLocationActivities model = new ApplicationLocationActivities();
            return Json(ResponseStatus.Success, RenderPartialViewToString("AddLocationActivity", model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddLocationActivity( string location, string activity, IList<ApplicationLocationActivities> locAct) {

            ApplicationLocationActivities model = new ApplicationLocationActivities();
            model.location = location;
            model.activity = activity;
            locAct.Add(model);
            return Json(ResponseStatus.Success, RenderPartialViewToString("ApplicationLocationActivities", locAct));

        
        }
    }
     
}

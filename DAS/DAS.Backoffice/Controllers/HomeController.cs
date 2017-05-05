using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAS.Backoffice.Models.Home;
using DAS.Backoffice.Models.About;
using DAS.Backoffice.Models.Offers;
using DAS.Backoffice.Models.News;
using DAS.Backoffice.Models.Contact;
using DAS.Backoffice.Models.Application;
using DAS.Backoffice.AppLogic._Global;
using DAS.Domain.Model;
using DAS.Backoffice.Builders.Home;
using IniCore.Web.Mvc.Html;
using IniCore.Web.Mvc;
using System.IO;
using System.Web.Configuration;
using Aspose.Words;

namespace DAS.Backoffice.Controllers
{
    public class HomeController : DASController
    {
        
        public ActionResult ChangeLanguage(int LanguageId)
        {
            Session["lngId"] = LanguageId;
            return Json(new { success = true });
        }

        public ActionResult Index()
        {
            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }
             
            ViewBag.Link = 1;
            HomeModel model = new HomeModel();
            model.ContentLeft = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "ContentLeft" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRight = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "ContentRight" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRightDoc = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "ContentRightDoc" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRightBottom = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "ContentRightBottom" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.LeftLink = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "LeftLink" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRight = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "ContentRight" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRightDoc = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "ContentRightDoc" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRightBottom = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "ContentRightBottom" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.LeftLink = Db.Labels.Where(m => m.ViewId == "Home" && m.ElementId == "LeftLink" && m.LanguageId == lngId).FirstOrDefault().Text;
            return View(model);
        }

        public ActionResult EditText(string viewId, string elementId)
        {

            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }
            
            EditModel model = new EditModel();
            model.ViewId = viewId;
            model.ElementId = elementId;
            model.ContentTextEditor = Db.Labels.Where(m => m.ViewId == viewId && m.ElementId == elementId && m.LanguageId == lngId).FirstOrDefault().Text;
            return Json(ResponseStatus.Success, new { html = RenderPartialViewToString("EditText", model) });
        }

        public ActionResult SaveText(string viewId, string elementId, string contentTextEditor)
        {

            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }

            contentTextEditor = contentTextEditor.Replace("<a href", "<a class=\"link\" href");
            contentTextEditor = contentTextEditor.Replace("<ul>","<ul id=\"basiclist\" style=\"text-align: left;\">");
            contentTextEditor = contentTextEditor.Replace("<div id=\"QMS\">", "<div id=\"QMS\"><a name=\"QMS\">");
            contentTextEditor = contentTextEditor.Replace("<div id=\"EMS\">", "<div id=\"EMS\"><a name=\"EMS\">");
            contentTextEditor = contentTextEditor.Replace("<div id=\"OHSAS\">", "<div id=\"OHSAS\"><a name=\"OHSAS\">");
            contentTextEditor = contentTextEditor.Replace("<div id=\"ISMS\">", "<div id=\"ISMS\"><a name=\"ISMS\">");
            contentTextEditor = contentTextEditor.Replace("<div id=\"ITSMS\">", "<div id=\"ITSMS\"><a name=\"ITSMS\">");
            contentTextEditor = contentTextEditor.Replace("<div id=\"BCP\">", "<div id=\"BCP\"><a name=\"BCP\">");
            contentTextEditor = contentTextEditor.Replace("<div id=\"FSMS\">", "<div id=\"FSMS\"><a name=\"FSMS\">");
            contentTextEditor = contentTextEditor.Replace("</div>", "</a></div>");
            Label lbl = Db.Labels.Where(m => m.ViewId == viewId && m.ElementId == elementId && m.LanguageId == lngId).FirstOrDefault();
            lbl.Text = contentTextEditor;
            Db.SaveChanges();
           
            return Json(ResponseStatus.Success, null);
        }

        public ActionResult Welcome()
        {
            ViewBag.Link = 1;

            return View();
        }

        public ActionResult About()
        {
            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }
             

            ViewBag.Link = 5;
            AboutModel model = new AboutModel();
            model.ContentLeft = Db.Labels.Where(m => m.ViewId == "About" && m.ElementId == "ContentLeft" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRight = Db.Labels.Where(m => m.ViewId == "About" && m.ElementId == "ContentRight" && m.LanguageId == lngId).FirstOrDefault().Text;

            return View(model);
        }

        public ActionResult Contact()
        {

            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }
              
            ViewBag.Link = 8;
            ContactModel model = new ContactModel();
            model.ContentLeft = Db.Labels.Where(m => m.ViewId == "Contact" && m.ElementId == "ContentLeft" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRight = Db.Labels.Where(m => m.ViewId == "Contact" && m.ElementId == "ContentRight" && m.LanguageId == lngId).FirstOrDefault().Text;

            return View(model);

        }

        public ActionResult Offers()
        {
            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }
              
            ViewBag.Link = 2;
            OffersModel model = new OffersModel();
            model.ContentLeft = Db.Labels.Where(m => m.ViewId == "Offers" && m.ElementId == "ContentLeft" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRight = Db.Labels.Where(m => m.ViewId == "Offers" && m.ElementId == "ContentRight" && m.LanguageId == lngId).FirstOrDefault().Text;
    
            return View(model);
        }

        public ActionResult Application()
        {

            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }
             

            ViewBag.Link = 6;


            ApplicationModel model = new ApplicationModel();
            model.ContentLeft = Db.Labels.Where(m => m.ViewId == "Application" && m.ElementId == "ContentLeft" && m.LanguageId == lngId).FirstOrDefault().Text;
            model.ContentRight = Db.Labels.Where(m => m.ViewId == "Application" && m.ElementId == "ContentRight" && m.LanguageId == lngId).FirstOrDefault().Text;

            return View(model);
        }

        public ActionResult ApplicationForm()

        {
            ApplicationsModel model = HomeBuilder.BuildApplications(Db);
            ViewBag.Link = 6;
            return View(model);
        }
        public ActionResult Clients()
        {
            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
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

        public JsonResult FindApplication(ApplicationListFilterModel  filters, GridDescriptor request)
        {
           
                ApplicationList model = HomeBuilder.FilterApplications(Db, request, filters);
                return Json(ResponseStatus.Success, RenderPartialViewToString("ApplicationList", model));

        }

 

        public ActionResult News()
        {

            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }
              
            NewsListModel model = NewsBuilder.BuildNews(Db);
            model.ContentRight = Db.Labels.Where(m => m.ViewId == "News" && m.ElementId == "ContentRight" && m.LanguageId == lngId).FirstOrDefault().Text;
            ViewBag.Link = 4;
            return View(model);

        }

        public JsonResult OpenArchive(int ArchiveId)
        {

            IList<NewsModel> model = NewsBuilder.BuildArchivedNews(Db, ArchiveId);
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
        public ActionResult OpenApplicationDetails(int ApplicationId){

          DAS.Backoffice.Models.Application.ApplicationForm model = Db.ApplicationForms.Where(m => m.ApllicationId == ApplicationId).Select(m => new DAS.Backoffice.Models.Application.ApplicationForm() { 
              ApplicationId = m.ApllicationId, BSOHSAS18001 = (bool)m.BSOHSAS18001, CompanyName = m.CompanyName, Adress = m.Adress, Place = m.Place, Email = m.Email, Telephone = m.Telephone, Applicant = m.Applicant,
              ISO14001 = (bool)m.ISO14001, ISO22301 = (bool)m.ISO22301, ISO27001 = (bool)m.ISO27001, ISO9001 = (bool)m.ISO9001, OtherIso = (bool)m.OtherIso, Other = m.Other,
              CompanyWebsite=m.CompanyWebsite, PrimaryContactForAuditPurposes=m.PrimaryContactForAuditPurposes, PrimaryContactTelephone=m.PrimaryContactTelephone,
              NatureOfBusiness=m.NatureOfBusiness,NumberOfYearsAtThisSite=m.NumberOfYearsAtThisSite,PrincipleServicesOrProducts=m.PrincipleServicesOrProducts,
              ActivitiesOnClientsSites=m.ActivitiesOnClientsSites, NameOfPresentCertificationBody=m.NameOfPresentCertificationBody,CertificateExpiryDate=m.CertificateExpiryDate,
              TotalNumberOfEmployees=m.TotalNumberOfEmployees,TotalNumberOfCompanyDirectors=m.TotalNumberOfCompanyDirectors,NumberOfLocations=m.NumberOfLocations,
              AllSitesMainActivites=m.AllSitesMainActivites,TotalPermanent=m.TotalPermanent, TotalTemporary=m.TotalTemporary, Extension=m.Extension, ManagementRepresentativeName=m.ManagementRepresentativeName, 
              JobTitle=m.JobTitle, NameOfConsultant=m.NameOfConsultant, ConsultantTelephone=m.ConsultantTelephone, ISO14001_2=(bool)m.ISO14001_2,ISO9001_2=(bool)m.ISO9001_2,ISO22301_2=(bool)m.ISO22301_2,ISO27001_2=(bool)m.ISO27001_2,BSOHSAS18001_2=(bool)m.BSOHSAS18001_2,
              StandardTransferred=m.StandardTransferred, DateNextCertificationBodyVisit=m.DateNextCertificationBodyVisit, Other_2=m.Other_2, OtherIso_2= (bool)m.OtherIso_2
          }).FirstOrDefault();

          model.Categories = new List <ApplicationCategory>();
          IList<ApplicationFormCatagory> categories = Db.ApplicationFormCatagories.Where(j => j.ApplicationId == ApplicationId).ToList();
          ApplicationCategory temp;
          foreach (var item in categories){

              temp = new ApplicationCategory() { ApplicationId = ApplicationId, CategoryId = item.CategoryId, Category = item.Category, TotalPermanent = item.TotalPermanent, TotalTemporary = item.TotalTemporary };
              model.Categories.Add(temp); 
          }

          model.locationActivities = new List<ApplicationLocationActivities>();
          IList<AppFormLocationActivity> locAct = Db.AppFormLocationActivities.Where(k => k.ApplicationId == ApplicationId).ToList();
          ApplicationLocationActivities pom;
          foreach (var item in locAct) {

              pom = new ApplicationLocationActivities() { applicationId = ApplicationId,id = item.Id, location = item.Location ,activity = item.Activity, };
              model.locationActivities.Add(pom);

          }

          return Json(ResponseStatus.Success, RenderPartialViewToString("OpenApplicationDetails", model));

        }
        public JsonResult OpenCurrentNews()
        {

            IList<NewsModel> model = NewsBuilder.BuildCurrentNews(Db);
            return Json(ResponseStatus.Success, RenderPartialViewToString("OpenNews", model));
        }

        public JsonResult AddClient(ClientModel model)
        {

            Client newClient;
            newClient = new Client();
            newClient.ClientId = Db.Clients.Select(j => j.ClientId).Max() + 1; 
            newClient.Name = model.ClientName;
            newClient.Address = model.Address;
            newClient.Description = model.Description;
            newClient.DateChange = DateTime.Now;
            newClient.Ord = Db.Clients.Select(j => j.Ord).Max() + 1; 
            Db.Clients.Add(newClient);
            Db.SaveChanges();

            ClientModel modelClient = ClientDetailsBuilder.Build(newClient.ClientId, Db);
            return Json(ResponseStatus.Success, new { clientId = newClient.ClientId , Certificate=newClient.Certificates });
        }


        public ActionResult AddClientEditor()
        {
            return Json(ResponseStatus.Success, RenderPartialViewToString("ClientAdd", new ClientModel()), JsonRequestBehavior.AllowGet);
        }

 

        public ActionResult EditNews(int newsId)
        {
            DAS.Domain.Model.News newsEdit = Db.News.Where(m => m.NewsId == newsId).FirstOrDefault();

            EditNewsModel model = new EditNewsModel();
            model.newsId = newsId;
            model.Name = newsEdit.Name;
            model.Year = newsEdit.Year;

            model.ContentTextEditor = newsEdit.Text;
            return Json(ResponseStatus.Success, RenderPartialViewToString("NewsEditor", model));
        }

        public ActionResult SaveNews(int newsId, string newsName, int newsYear, string contentTextEditor)
        {

            var lngId = 1;
            if (Session["lngId"] != null)
            {
                lngId = (int)Session["lngId"];
            }

            if (newsId == 0)
            {


                News newsNews;
                newsNews = new News();
                newsNews.NewsId = Db.News.Select(j => j.NewsId).Max() + 1;
                newsNews.Name = newsName;
                newsNews.Year = newsYear;
                newsNews.Text = contentTextEditor;
                newsNews.LanguageId = lngId;
                newsNews.Ord = newsNews.NewsId;
                Db.News.Add(newsNews);
               
            }
            else
            {

                News news = Db.News.Where(m => m.NewsId == newsId).FirstOrDefault();
                news.Text = contentTextEditor;
                news.Name = newsName;
                news.Year = newsYear;

            }

                Db.SaveChanges();

                return Json(ResponseStatus.Success, new { reload = true });
            
        }

        public ActionResult AddNewsEditor()
        {
            EditNewsModel model = new EditNewsModel() { newsId = 0 };
            return Json(ResponseStatus.Success,  RenderPartialViewToString("NewsEditor", model), JsonRequestBehavior.AllowGet);
        }

    


        public ActionResult Upload(HttpPostedFileBase file, string tooltip)
        {
            string PHYSICAL_PATH = WebConfigurationManager.AppSettings["physicalPathContent"];
            try
            {
                string imagePath = PHYSICAL_PATH + "Images\\nav";
                UploadModel model = new UploadModel();
                String path1 = "";
                string path="";
                string pathUI = "";
                if (file.ContentLength > 0)
                {                    
                    var fileName = Path.GetFileName(file.FileName);
                     path = Path.Combine(Server.MapPath("~/Content/Images/nav"), fileName);
                    pathUI = Path.Combine(imagePath, fileName);
                    path1 = "~/Content/Images/nav/"+fileName;
                    file.SaveAs(path);
                    file.SaveAs(pathUI);
                }
                ViewBag.Message = "Upload successful";
                model.ImageUrl = path1;
                model.tooltip = tooltip;
                return PartialView("Example",model);
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return PartialView("Example");
            }            

        }

        public ActionResult Example()
        {
            UploadModel model = new UploadModel();
            model.ImageUrl = "";
            return PartialView("Example", model);
        }


        public JsonResult SaveClient(int clientId, string clientName, string adress, string description, bool date)
        {


            /*ModelState.Clear();*/
            Client client = Db.Clients.Where(m => m.ClientId == clientId).FirstOrDefault();
            client.Name = clientName;
            client.Address = adress;
            client.Description = description;
            client.Ord = client.Ord;
            if (date == true)
            {
                client.DateChange = DateTime.Now;
            }
            Db.SaveChanges();
            ClientModel model = ClientDetailsBuilder.Build(client.ClientId, Db);
            return Json(ResponseStatus.Success, new { html = RenderPartialViewToString("OpenClientDetails", model) });
        }

        public JsonResult EditCertificate(int certId)
        {
            Certificate c = Db.Certificates.Where(j => j.CertificateId == certId).FirstOrDefault();
            CertModel model = new CertModel() { CertId =c.CertificateId,CertName=c.CertificateName,Standard=c.Standard, StatusID=c.StatusId};
            model.Statuses = ClientDetailsBuilder.BuildStatuses(Db);
       

            return Json(ResponseStatus.Success, new { html = RenderPartialViewToString("EditCertificate", model) });
        }

        public JsonResult SaveCerftificate(int certId, string certName, string standard, int statusId)
         {
             Certificate c = Db.Certificates.Where(j => j.CertificateId == certId).FirstOrDefault();
            IList <CertModel> model = new List<CertModel>();
             c.CertificateName = certName;
             c.Standard = standard;
             c.StatusId = statusId;
             Db.SaveChanges();

             IList<Certificate> certs = Db.Certificates.Where(j => j.ClientId ==c.ClientId ).ToList();
             CertModel temp;
             foreach (var item in certs)
             {
                 temp = new CertModel() { CertId = item.CertificateId, CertName = item.CertificateName, Standard = item.Standard };
                 temp.Status = ClientDetailsBuilder.GetStatusName(Db, item.StatusId);
                 temp.StatusID = item.StatusId;
                 model.Add(temp);
                
             }
           

             return Json(ResponseStatus.Success, new { html = RenderPartialViewToString("Certificate", model) });

          }


        public JsonResult DeleteCertificate(int clientId, int certId) {

            Certificate c = Db.Certificates.Where(j => j.CertificateId == certId).FirstOrDefault();
            IList<CertModel> model = new List<CertModel>();
            Db.Certificates.Remove(c);
            Db.SaveChanges();

            IList<Certificate> certs = Db.Certificates.Where(j => j.ClientId == c.ClientId).ToList();
            CertModel temp;
            foreach (var item in certs)
            {
                temp = new CertModel() { CertId = item.CertificateId, CertName = item.CertificateName, Standard = item.Standard };
                temp.Status = ClientDetailsBuilder.GetStatusName(Db, item.StatusId);
                temp.StatusID = item.StatusId;
                model.Add(temp);

            }

            return Json(ResponseStatus.Success, new { html = RenderPartialViewToString("Certificate", model) });
        }

        public ActionResult AddCertificateEditor()
        {
            CertModel model = new CertModel();
            model.Statuses = ClientDetailsBuilder.BuildStatuses(Db);
            return Json(ResponseStatus.Success, RenderPartialViewToString("AddCertificate",model), JsonRequestBehavior.AllowGet);
        }


     
        public JsonResult AddCertificate(int clientId, string certName, string standard, int statusId)
        {

            /*ModelState.Clear();*/
            Certificate cert;
            cert = new Certificate();
            cert.CertificateId = Db.Certificates.Select(j => j.CertificateId).Max()+1;
            cert.CertificateName = certName;
            cert.ClientId = clientId;
            cert.Standard = standard;
            cert.StatusId = statusId;
            Db.Certificates.Add(cert);
            Db.SaveChanges();

            IList<CertModel> model = new List<CertModel>();

            IList<Certificate> certs = Db.Certificates.Where(j => j.ClientId == cert.ClientId).ToList();
            CertModel temp;
            foreach (var item in certs)
            {
                temp = new CertModel() { CertId = item.CertificateId, CertName = item.CertificateName, Standard = item.Standard };
                temp.Status = ClientDetailsBuilder.GetStatusName(Db, item.StatusId);
                temp.StatusID = item.StatusId;
                model.Add(temp);

            }
          
            return Json(ResponseStatus.Success, new { html = RenderPartialViewToString("Certificate", model) });
        }

        public ActionResult ApplicationWord(int appId)
        {
 
            MemoryStream stream = new MemoryStream();
            string path = Server.MapPath("~/Content/");

            DAS.Backoffice.Models.Application.ApplicationForm model = Db.ApplicationForms.Where(m => m.ApllicationId == appId).Select(m => new DAS.Backoffice.Models.Application.ApplicationForm()
            {
                ApplicationId = m.ApllicationId,
                CompanyName = m.CompanyName,
                Adress = m.Adress,
                Place = m.Place,
                Telephone = m.Telephone,
                Email = m.Email,
                Applicant = m.Applicant,
                ISO14001 = (bool)m.ISO14001,
                ISO22301 = (bool)m.ISO22301,
                ISO27001 = (bool)m.ISO27001,
                ISO9001 = (bool)m.ISO9001,
                BSOHSAS18001 = (bool)m.BSOHSAS18001,
                OtherIso = (bool)m.OtherIso,
                Other = m.Other,
                CompanyWebsite = m.CompanyWebsite,
                PrimaryContactForAuditPurposes = m.PrimaryContactForAuditPurposes,
                PrimaryContactTelephone = m.PrimaryContactTelephone,
                NatureOfBusiness = m.NatureOfBusiness,
                NumberOfYearsAtThisSite = m.NumberOfYearsAtThisSite,
                PrincipleServicesOrProducts = m.PrincipleServicesOrProducts,
                ActivitiesOnClientsSites = m.ActivitiesOnClientsSites,
                NameOfPresentCertificationBody = m.NameOfPresentCertificationBody,
                CertificateExpiryDate = m.CertificateExpiryDate,
                TotalNumberOfEmployees = m.TotalNumberOfEmployees,
                TotalNumberOfCompanyDirectors = m.TotalNumberOfCompanyDirectors,
                NumberOfLocations = m.NumberOfLocations,
                AllSitesMainActivites = m.AllSitesMainActivites,
                SalesTotalPermanent = m.SalesTotalPermanent,
                SalesTotalTemporary = m.SalesTotalTemporary,
                MarketingTotalPermanent = m.MarketingTotalPermanent,
                ManufacturingTotalTemporary = m.ManufacturingTotalTemporary,
                MarketingTotalTemporary = m.MarketingTotalTemporary,
                AdministrationTotalPermanent = m.AdministrationTotalPermanent,
                AdministrationTotalTemporary = m.AdministrationTotalTemporary,
                DesignTotalPermanent = m.DesignTotalPermanent,
                DesignTotalTemporary = m.DesignTotalTemporary,
                ManufacturingTotalPermanent = m.ManufacturingTotalPermanent,
                OtherTotalPermanent = m.OtherTotalPermanent,
                OtherTotalTemporary = m.OtherTotalTemporary,
                TotalPermanent = m.TotalPermanent,
                TotalTemporary = m.TotalTemporary,
                Extension = m.Extension,
                ManagementRepresentativeName = m.ManagementRepresentativeName,
                JobTitle = m.JobTitle,
                NameOfConsultant = m.NameOfConsultant,
                ConsultantTelephone = m.ConsultantTelephone,
                ISO14001_2 = (bool)m.ISO14001_2,
                ISO9001_2 = (bool)m.ISO9001_2,
                ISO22301_2 = (bool)m.ISO22301_2,
                ISO27001_2 = (bool)m.ISO27001_2,
                BSOHSAS18001_2 = (bool)m.BSOHSAS18001_2,
                StandardTransferred = m.StandardTransferred,
                DateNextCertificationBodyVisit = m.DateNextCertificationBodyVisit,
                Other_2=m.Other_2,
                OtherIso_2=(bool)m.OtherIso_2,
                date_created = (DateTime)m.DateCreated
                

            }).FirstOrDefault();


            model.Categories = new List<ApplicationCategory>();
            IList<ApplicationFormCatagory> categories = Db.ApplicationFormCatagories.Where(j => j.ApplicationId == appId).ToList();
            ApplicationCategory temp;
            foreach (var item in categories)
            {

                temp = new ApplicationCategory() { ApplicationId = appId, CategoryId = item.CategoryId, Category = item.Category, TotalPermanent = item.TotalPermanent, TotalTemporary = item.TotalTemporary };
                model.Categories.Add(temp);
            }

            model.locationActivities = new List<ApplicationLocationActivities>();
            IList<AppFormLocationActivity> locAct = Db.AppFormLocationActivities.Where(k => k.ApplicationId == appId).ToList();
            ApplicationLocationActivities pom;
            foreach (var item in locAct)
            {

                pom = new ApplicationLocationActivities() { applicationId = appId, id = item.Id, location = item.Location, activity = item.Activity };
                model.locationActivities.Add(pom);

            }



            Aspose.Words.Document dst = ReportBuilder.Execute("", path, model);
            dst.Save(stream, SaveFormat.Doc);
            byte[] docData = stream.ToArray();
            stream.Dispose();
            return File(docData, "application/doc", model.CompanyName + ".doc");
        }



        public ActionResult AddArchiveEditor()
        {

            ArchiveYearModel model = new ArchiveYearModel();
            return Json(ResponseStatus.Success, RenderPartialViewToString("ArchiveEditor", model), JsonRequestBehavior.AllowGet);

        }


        public JsonResult ArchiveNews(int year)
        {
            
         
            IList<News> news = Db.News.Where(l => l.Year==year && l.Archive==false).ToList();
            
            News temp;
            Archive temp2 = new Archive();
            
            int arhciveId = Db.Archives.Select(j => j.ArchiveId).Max() + 1;
            temp2.ArchiveId = arhciveId;
            temp2.Year = year;

            foreach (var item in news)
            {
                
                temp = Db.News.Where(n => n.NewsId == item.NewsId).FirstOrDefault();
                temp.Archive = true; 
                temp.Name = item.Name;
                temp.Text = item.Text;
                temp.Year = item.Year;
                temp.Ord = item.Ord;
                temp.LanguageId = item.LanguageId;
             
                Db.SaveChanges();

                temp2.News.Add(temp);

            }

            Db.Archives.Add(temp2);
            Db.SaveChanges();
            NewsListModel model = NewsBuilder.BuildNews(Db);

            
            return Json(ResponseStatus.Success, RenderPartialViewToString("News", model), JsonRequestBehavior.AllowGet);


        }


        public JsonResult DeleteNews(int newsId) {

 

            News news = Db.News.Where(n => n.NewsId == newsId).FirstOrDefault();
            Db.News.Remove(news);
            Db.SaveChanges();

            return Json(ResponseStatus.Success, new { reload = true });


        }


        public JsonResult DeleteClient(int clientID)
        {

          
            IList<Certificate> certs = Db.Certificates.Where(j => j.ClientId == clientID).ToList();
            foreach (var item in certs)
            {
                Db.Certificates.Remove(item);
                Db.SaveChanges();
            }

            Client client = Db.Clients.Where(m => m.ClientId == clientID).FirstOrDefault();
            Db.Clients.Remove(client);
            Db.SaveChanges();

            return Json(ResponseStatus.Success, new { reload = true });


        }

        public JsonResult DeleteApplication(int applicationId)
        {


            DAS.Domain.Model.ApplicationForm application = Db.ApplicationForms.Where(a => a.ApllicationId == applicationId).FirstOrDefault();
            Db.ApplicationForms.Remove(application);
            Db.SaveChanges();

            return Json(ResponseStatus.Success, new { reload = true });


        }

   
    }
}

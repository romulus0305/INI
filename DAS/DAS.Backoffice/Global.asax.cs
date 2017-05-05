using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DAS.Backoffice
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterLicenses();
        }

        private void RegisterLicenses()
        {
            string licenseAsposeWordPath = Server.MapPath("~/Licenses/Aspose.Words.lic");
            if (System.IO.File.Exists(licenseAsposeWordPath))
            {
                Aspose.Words.License licenseWord = new Aspose.Words.License();
                licenseWord.SetLicense(licenseAsposeWordPath);
            }
            string licenseAsposePdfPath = Server.MapPath("~/Licenses/Aspose.Pdf.lic");
            if (System.IO.File.Exists(licenseAsposePdfPath))
            {
                Aspose.Pdf.License licensePdf = new Aspose.Pdf.License();
                licensePdf.SetLicense(licenseAsposePdfPath);
            }
        }
    }
}
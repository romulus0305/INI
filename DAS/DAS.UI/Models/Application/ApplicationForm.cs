using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DAS.UI.Helpers;

namespace DAS.UI.Models.Application
{
    public class ApplicationForm
    {
        public int ApplicationId { get; set; }
        public bool ISO9001 { get; set; }
        public bool ISO14001 { get; set; }
        public bool BSOHSAS18001 { get; set; }
        public bool ISO27001 { get; set; }
        public bool ISO22301 { get; set; }
        public bool OtherIso { get; set; }
        public string Other { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string Place { get; set; }
        public string Telephone { get; set; }
        public string Extension { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9._%-]+[a-zA-Z0-9])+@[a-zA-Z._-]+?\.[a-zA-Z]{2,3}$", ErrorMessageResourceName = "EmailExpression", ErrorMessageResourceType = typeof(Translation))]
        public string Email { get; set; }
        public string CompanyWebsite { get; set; }
        public string ManagementRepresentativeName { get; set; }
        public string JobTitle { get; set; }
        public string PrimaryContactForAuditPurposes { get; set; }
        public string PrimaryContactTelephone { get; set; }
        public string NameOfConsultant { get; set; }
        public string ConsultantTelephone { get; set; }
        public bool ISO9001_2 { get; set; }
        public bool ISO14001_2 { get; set; }
        public bool BSOHSAS18001_2 { get; set; }
        public bool ISO27001_2 { get; set; }
        public bool ISO22301_2 { get; set; }
        public bool OtherIso_2 { get; set; }
        public string Other_2 { get; set; }
        public string NatureOfBusiness { get; set; }
        public string NumberOfYearsAtThisSite { get; set; }
        public string PrincipleServicesOrProducts { get; set; }
        public string ActivitiesOnClientsSites { get; set; }
        public string StandardTransferred { get; set; }
        public string NameOfPresentCertificationBody { get; set; }
        public string CertificateExpiryDate { get; set; }
        public string DateNextCertificationBodyVisit { get; set; }
        public string TotalNumberOfEmployees { get; set; }
        public string TotalNumberOfCompanyDirectors { get; set; }
        public string NumberOfLocations { get; set; }
        public string AllSitesMainActivites { get; set; }
        public string SalesTotalPermanent { get; set; }
        public string SalesTotalTemporary { get; set; }
        public string MarketingTotalPermanent { get; set; }
        public string MarketingTotalTemporary { get; set; }
        public string AdministrationTotalPermanent { get; set; }
        public string AdministrationTotalTemporary { get; set; }
        public string DesignTotalPermanent { get; set; }
        public string DesignTotalTemporary { get; set; }
        public string ManufacturingTotalPermanent { get; set; }
        public string ManufacturingTotalTemporary { get; set; }
        public string OtherTotalPermanent { get; set; }
        public string OtherTotalTemporary { get; set; }
        public string TotalPermanent { get; set; }
        public string TotalTemporary { get; set; }
        public string Applicant { get; set; }
        public int LanguageId { get; set; }
        public DateTime date_created { get; set; }
        public IList<ApplicationCategory> Categories { get; set; }
        public IList<ApplicationLocationActivities> locationActivities { get; set; }



        class Translation
        {

            public static string EmailExpression 
            {
                get
                {
                    return Translate(1);
                }
            }


            public static string Translate(int field)
            {
                if (field == 1)
                {
                    return HelperExtensions.PTPLabel("ApplicationForm", "EmailExpression");
                }
               
                
                return "";


            }


        }
    }


}
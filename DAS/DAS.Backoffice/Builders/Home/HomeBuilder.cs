using DAS.Domain.Model;
using DAS.Backoffice.Models.Home;
using DAS.Backoffice.Models.Application;
using IniCore.Web.Mvc.Html;
using IniCore.Web.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Backoffice.Builders.Home
{
    public class HomeBuilder
    {
        public static ClientsModel BuildClients(DASEntities db)
        {
            ClientsModel model = new ClientsModel();
            int languageId = (int)HttpContext.Current.Session["lngId"];
            model.Filters = new FilterModel();

            model.Filters.Statuses = BuildStatuses(db);
            /*todo; dodati labelu Svi u labels*/

            string stat = "...";

            stat = db.Labels.Where(s => s.ViewId == "Clients" && s.ElementId == "lblSearchStat" && s.LanguageId == languageId).Select(ps => ps.Text).FirstOrDefault();

            model.Filters.Statuses.Add(new StatusModel() { StatusId = 0, StatusName = stat });
            /*in backoffice selected status is All*/
            model.Filters.SelectedStatusId = 0;
            model.Filters.Statuses = model.Filters.Statuses.OrderBy(m => m.StatusId).ToList();
           
            GridDescriptor desc = new GridDescriptor(new SortDescriptor() { PropertyName = "DateChange", Order = SortOrder.Descending }) { Pager = new PagerDescriptor(1, 20, db.Labels.Where(l => l.ViewId == "Clients" && l.ElementId == "lblPageSize" && l.LanguageId == languageId).Select(l => l.Text).FirstOrDefault(), 5) };

            IQueryable<Client> clients = db.Clients.AsQueryable();

            /*initial filter will be only with active status*/
            //clients = clients.Where(m => m.Certificates.Any(l => l.StatusId == 1));
            IList<Client> listC = clients.Slice(desc).ToList();
            model.Clients = new ClientList() { Descriptor = desc, ListOfClients = new List<ClientModel>() };
            ClientModel clientM;
            CertModel certM;
            foreach (var item in listC)
            {

                clientM = new ClientModel() { ClientId = item.ClientId, Address = item.Address, ClientName = item.Name, Description = item.Description, Certificates = new List<CertModel>() };
                foreach (var itemC in item.Certificates)
                {
                    //if (itemC.StatusId==1)
                    //{                      
                    certM = new CertModel() { CertId = itemC.CertificateId, CertName = itemC.CertificateName, Standard = itemC.Standard };
                    certM.Status = GetStatusName(db, itemC.StatusId);
                    clientM.Certificates.Add(certM);
                    //}
                }
                model.Clients.ListOfClients.Add(clientM);
            }
            return model;
        }

        public static ClientList FilterClients(DASEntities db, GridDescriptor desc, FilterModel filters)
        {

            ClientList model = new ClientList() { Descriptor = desc, ListOfClients = new List<ClientModel>() };
            IQueryable<Client> clients = db.Clients.AsQueryable();
            IQueryable<vw_ClientsBackoffice> clientsF = db.vw_ClientsBackoffice.AsQueryable();
            string filStandard = "";
            if (filters == null)
            {
                filters = new FilterModel();
            }


            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                filStandard = filters.Name.Replace(":", "").Replace("/", "").Replace("-", "").Replace("–", "").Replace("\"", "").Replace(".", "");
                clientsF = clientsF.Where(m => m.Name.Contains(filStandard));
            }


            if (filters.SelectedStatusId != 0)
            {
                if (!string.IsNullOrWhiteSpace(filters.Standard))
                {
                    clientsF = clientsF.Where(b => b.StatusId == filters.SelectedStatusId && b.Standard.Contains(filters.Standard));
                }
                else
                {
                    clientsF = clientsF.Where(m => m.StatusId == filters.SelectedStatusId);
                }

            }
            else if (!string.IsNullOrWhiteSpace(filters.Standard))
            {

                clientsF = clientsF.Where(m => m.Standard.Contains(filters.Standard));
            }

            IList<int> clientIds = clientsF.Select(k => k.ClientId).Distinct().ToList();


            IList<Client> listC = clients.Where(h => clientIds.Contains(h.ClientId)).Slice(desc).ToList();
            ClientModel clientM;
            CertModel certM;
            foreach (var item in listC)
            {
                clientM = new ClientModel() { ClientId = item.ClientId, Address = item.Address, ClientName = item.Name, Description = item.Description, Certificates = new List<CertModel>() };
                foreach (var itemC in item.Certificates)
                {
                    if ((string.IsNullOrWhiteSpace(filters.Standard) || itemC.Standard.Contains(filters.Standard.ToUpper())) && (filters.SelectedStatusId == 0 || filters.SelectedStatusId == itemC.StatusId))
                    {
                        certM = new CertModel() { CertId = itemC.CertificateId, CertName = itemC.CertificateName, Standard = itemC.Standard };
                        certM.Status = GetStatusName(db, itemC.StatusId);
                        clientM.Certificates.Add(certM);
                    }
                }
                model.ListOfClients.Add(clientM);
            }
            return model;
        }


        private static IList<StatusModel> BuildStatuses(DASEntities db)
        {
            IList<StatusModel> list;
            int languageId = (int)HttpContext.Current.Session["lngId"];
            if (languageId == 1)
            {
                list = db.Status.Select(m => new StatusModel() { StatusId = m.StatusId, StatusName = m.Name }).ToList();
            }
            else
            {
                list = db.Status_Lng.Where(n => n.LanguageId == languageId).Select(l => new StatusModel() { StatusId = l.StatusId, StatusName = l.Name }).ToList();
            }
            return list;
        }

        private static string GetStatusName(DASEntities db, int statusId)
        {
            int languageId = (int)HttpContext.Current.Session["lngId"];
            string name = db.Status.FirstOrDefault(m => m.StatusId == statusId).Name;

            if (languageId != 1)
            {
                DAS.Domain.Model.Status_Lng tran = db.Status_Lng.FirstOrDefault(n => n.LanguageId == languageId && n.StatusId == statusId);
                if (tran != null)
                {
                    name = tran.Name;
                }
            }
            return name;
        }


        public static ApplicationsModel BuildApplications(DASEntities db)
        {
            ApplicationsModel model = new ApplicationsModel();
            int languageId = (int)HttpContext.Current.Session["lngId"];

            GridDescriptor desc = new GridDescriptor(new SortDescriptor() { PropertyName = "DateCreated", Order = SortOrder.Descending }) { Pager = new PagerDescriptor(1, 20, db.Labels.Where(l => l.ViewId == "Clients" && l.ElementId == "lblPageSize" && l.LanguageId == languageId).Select(l => l.Text).FirstOrDefault(), 5) };
            IQueryable<DAS.Domain.Model.ApplicationForm> applications = db.ApplicationForms.AsQueryable();
            IList<DAS.Domain.Model.ApplicationForm> listA = applications.Slice(desc).ToList();

            model.Filters = new ApplicationListFilterModel();

            model.Applications = new ApplicationList() { Descriptor = desc, ListOfApplication = new List<DAS.Backoffice.Models.Application.ApplicationForm>() };
            DAS.Backoffice.Models.Application.ApplicationForm applicationModel;
            foreach (var item in listA)
            {

                applicationModel = new DAS.Backoffice.Models.Application.ApplicationForm() { ApplicationId = item.ApllicationId, CompanyName = item.CompanyName, Adress = item.Adress, Place = item.Place, Telephone = item.Telephone, Email = item.Email, Applicant = item.Applicant,
                    ISO14001 = (bool)item.ISO14001, ISO22301 = (bool)item.ISO22301, ISO27001 = (bool)item.ISO27001, ISO9001 = (bool)item.ISO9001,OtherIso = (bool)item.OtherIso, Other = item.Other,
                    CompanyWebsite=item.CompanyWebsite, PrimaryContactForAuditPurposes=item.PrimaryContactForAuditPurposes, PrimaryContactTelephone=item.PrimaryContactTelephone,
                    NatureOfBusiness=item.NatureOfBusiness,NumberOfYearsAtThisSite=item.NumberOfYearsAtThisSite,PrincipleServicesOrProducts=item.PrincipleServicesOrProducts,
                    ActivitiesOnClientsSites=item.ActivitiesOnClientsSites, NameOfPresentCertificationBody=item.NameOfPresentCertificationBody,CertificateExpiryDate=item.CertificateExpiryDate,
                    TotalNumberOfEmployees=item.TotalNumberOfEmployees,TotalNumberOfCompanyDirectors=item.TotalNumberOfCompanyDirectors,NumberOfLocations=item.NumberOfLocations,
                    AllSitesMainActivites=item.AllSitesMainActivites,SalesTotalPermanent=item.SalesTotalPermanent, SalesTotalTemporary=item.SalesTotalTemporary, MarketingTotalPermanent=item.MarketingTotalPermanent, ManufacturingTotalTemporary=item.ManufacturingTotalTemporary,
                    MarketingTotalTemporary=item.MarketingTotalTemporary,AdministrationTotalPermanent=item.AdministrationTotalPermanent, AdministrationTotalTemporary=item.AdministrationTotalTemporary,
                    DesignTotalPermanent=item.DesignTotalPermanent, DesignTotalTemporary=item.DesignTotalTemporary, ManufacturingTotalPermanent=item.ManufacturingTotalPermanent, 
                    OtherTotalPermanent=item.OtherTotalPermanent, OtherTotalTemporary=item.OtherTotalTemporary, TotalPermanent=item.TotalPermanent, TotalTemporary=item.TotalTemporary,Extension = item.Extension,ManagementRepresentativeName = item.ManagementRepresentativeName,
                    JobTitle = item.JobTitle,NameOfConsultant = item.NameOfConsultant,ConsultantTelephone = item.ConsultantTelephone,ISO14001_2 = (bool)item.ISO14001_2, ISO9001_2 = (bool)item.ISO9001_2,
                    ISO22301_2 = (bool)item.ISO22301_2,ISO27001_2 = (bool)item.ISO27001_2,BSOHSAS18001_2 = (bool)item.BSOHSAS18001_2, StandardTransferred = item.StandardTransferred,
                    DateNextCertificationBodyVisit = item.DateNextCertificationBodyVisit,  Other_2=item.Other_2,OtherIso_2= (bool)item.OtherIso_2,date_created=(DateTime)item.DateCreated

                };

                model.Applications.ListOfApplication.Add(applicationModel);
            }

            return model;
        }


        public static ApplicationList FilterApplications(DASEntities db, GridDescriptor desc, ApplicationListFilterModel filters)
        {

            ApplicationList model = new ApplicationList() { Descriptor = desc, ListOfApplication = new List<DAS.Backoffice.Models.Application.ApplicationForm>() };
            IQueryable<DAS.Domain.Model.ApplicationForm> applications = db.ApplicationForms.AsQueryable();
            int languageId = (int)HttpContext.Current.Session["lngId"];

            if (filters == null)
            {
                filters = new ApplicationListFilterModel();
            }

           
            string filApplication = "";


            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                filApplication = filters.Name.Replace(":", "").Replace("/", "").Replace("-", "").Replace("–", "").Replace("\"", "").Replace(".", "");
                applications = applications.Where(m => m.CompanyName.Contains(filApplication));
            }

            IList<DAS.Domain.Model.ApplicationForm> listA = applications.Slice(desc).ToList();
            DAS.Backoffice.Models.Application.ApplicationForm applicationModel;
            foreach (var item in listA)
            {

                applicationModel = new DAS.Backoffice.Models.Application.ApplicationForm() { ApplicationId = item.ApllicationId, CompanyName = item.CompanyName, Adress = item.Adress, Place = item.Place, Telephone = item.Telephone, Email = item.Email, Applicant = item.Applicant,
                    ISO14001 = (bool)item.ISO14001, ISO22301 = (bool)item.ISO22301, ISO27001 = (bool)item.ISO27001, ISO9001 = (bool)item.ISO9001, OtherIso = (bool)item.OtherIso, Other = item.Other,
                    CompanyWebsite=item.CompanyWebsite, PrimaryContactForAuditPurposes=item.PrimaryContactForAuditPurposes, PrimaryContactTelephone=item.PrimaryContactTelephone,
                    NatureOfBusiness=item.NatureOfBusiness,NumberOfYearsAtThisSite=item.NumberOfYearsAtThisSite,PrincipleServicesOrProducts=item.PrincipleServicesOrProducts,
                    ActivitiesOnClientsSites=item.ActivitiesOnClientsSites, NameOfPresentCertificationBody=item.NameOfPresentCertificationBody,CertificateExpiryDate=item.CertificateExpiryDate,
                    TotalNumberOfEmployees=item.TotalNumberOfEmployees,TotalNumberOfCompanyDirectors=item.TotalNumberOfCompanyDirectors,NumberOfLocations=item.NumberOfLocations,
                    AllSitesMainActivites=item.AllSitesMainActivites,SalesTotalPermanent=item.SalesTotalPermanent, SalesTotalTemporary=item.SalesTotalTemporary, MarketingTotalPermanent=item.MarketingTotalPermanent,
                    MarketingTotalTemporary=item.MarketingTotalTemporary,AdministrationTotalPermanent=item.AdministrationTotalPermanent, AdministrationTotalTemporary=item.AdministrationTotalTemporary,
                    DesignTotalPermanent=item.DesignTotalPermanent, DesignTotalTemporary=item.DesignTotalTemporary, ManufacturingTotalPermanent=item.ManufacturingTotalPermanent, ManufacturingTotalTemporary=item.ManufacturingTotalTemporary,
                    OtherTotalPermanent=item.OtherTotalPermanent, OtherTotalTemporary=item.OtherTotalTemporary, TotalPermanent=item.TotalPermanent, TotalTemporary=item.TotalTemporary,Extension = item.Extension,ManagementRepresentativeName = item.ManagementRepresentativeName,
                    JobTitle = item.JobTitle,NameOfConsultant = item.NameOfConsultant,ConsultantTelephone = item.ConsultantTelephone,ISO14001_2 = (bool)item.ISO14001_2, ISO9001_2 = (bool)item.ISO9001_2,
                    ISO22301_2 = (bool)item.ISO22301_2,ISO27001_2 = (bool)item.ISO27001_2,BSOHSAS18001_2 = (bool)item.BSOHSAS18001_2, StandardTransferred = item.StandardTransferred,
                    DateNextCertificationBodyVisit = item.DateNextCertificationBodyVisit, Other_2=item.Other_2,OtherIso_2= (bool)item.OtherIso_2,date_created=(DateTime)item.DateCreated
                
                };                                                                                                                                                                                          
                    
                   model.ListOfApplication.Add(applicationModel);
            }
    
            return model;
        }




    }
      
}
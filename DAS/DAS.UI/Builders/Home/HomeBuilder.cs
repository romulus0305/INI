using DAS.Domain.Model;
using DAS.UI.Models.Home;
using IniCore.Web.Mvc.Html;
using IniCore.Web.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.UI.Builders.Home
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

            string stat="...";

            stat= db.Labels.Where(s => s.ViewId == "Clients" && s.ElementId == "lblSearchStat" && s.LanguageId == languageId).Select(ps => ps.Text).FirstOrDefault();
               
            model.Filters.Statuses.Add(new StatusModel() { StatusId = 0, StatusName = stat});
            model.Filters.SelectedStatusId = 1;
            model.Filters.Statuses = model.Filters.Statuses.OrderBy(m => m.StatusId).ToList();
            GridDescriptor desc = new GridDescriptor(new SortDescriptor() { PropertyName = "DateChange", Order = SortOrder.Descending }) { Pager = new PagerDescriptor(1, 20, db.Labels.Where(l => l.ViewId == "Clients" && l.ElementId == "lblPageSize" && l.LanguageId == languageId ).Select(l => l.Text).FirstOrDefault(), 5) };
            
            IQueryable<Client> clients = db.Clients.AsQueryable(); 
           
            /*initial filter will be only with active status*/
            clients = clients.Where(m => m.Certificates.Any(l => l.StatusId == 1));
            IList<Client> listC = clients.Slice(desc).ToList();
            model.Clients = new ClientList() { Descriptor = desc, ListOfClients = new List<ClientModel>() };
            ClientModel clientM;
            CertModel certM; 
            foreach (var item in listC)
            {

                clientM = new ClientModel() { ClientId = item.ClientId, Address = item.Address, ClientName = item.Name, Description = item.Description, Certificates = new List<CertModel>() };
                foreach (var itemC in item.Certificates)
	            {
                    if (itemC.StatusId==1)
                    {                      
                    certM = new CertModel() { CertId = itemC.CertificateId, CertName = itemC.CertificateName, Standard = itemC.Standard };
                    certM.Status = GetStatusName(db,itemC.StatusId);
                    clientM.Certificates.Add(certM);
                    }
	            }
                model.Clients.ListOfClients.Add(clientM);
            }
            return model;
        }

        public static ClientList FilterClients(DASEntities db, GridDescriptor desc, FilterModel filters)
        { 

            ClientList model = new ClientList() { Descriptor = desc, ListOfClients = new List<ClientModel>() };
            IQueryable<Client> clients = db.Clients.AsQueryable();
            IQueryable<vw_Clients> clientsF = db.vw_Clients.AsQueryable();
            string filStandard = "";
            if (filters == null)
            {
                filters = new FilterModel();
                filters.SelectedStatusId = 1;
            }
            

            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                filStandard = filters.Name.Replace(":", "").Replace("/", "").Replace("-", "").Replace("–", "").Replace("\"","").Replace(".","");
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


        private static IList<StatusModel> BuildStatuses(DASEntities db) {
            IList<StatusModel> list;
            int languageId = (int)HttpContext.Current.Session["lngId"];
            if (languageId == 1)
            {
                list = db.Status.Select(m => new StatusModel() { StatusId = m.StatusId, StatusName = m.Name }).ToList();
            }
            else {
                list = db.Status_Lng.Where(n => n.LanguageId == languageId).Select(l => new StatusModel() { StatusId = l.StatusId, StatusName = l.Name }).ToList();
            }
            return list;
        }

        private static string GetStatusName(DASEntities db, int statusId) {
            int languageId = (int)HttpContext.Current.Session["lngId"];
            string name = db.Status.FirstOrDefault(m => m.StatusId == statusId).Name;

            if (languageId != 1)
            {
                DAS.Domain.Model.Status_Lng tran = db.Status_Lng.FirstOrDefault(n => n.LanguageId == languageId && n.StatusId == statusId);
                if (tran != null) {
                    name = tran.Name;
                }
            }
            return name;
        }
    }
}
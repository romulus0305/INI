using System;
using System.Collections.Generic;
using System.Linq;
using DAS.UI.Models.Home;
using System.Web;
using DAS.Domain.Model;
using DAS.UI.AppLogic.Caching;

namespace DAS.UI.Builders.Home
{
    public class ClientDetailsBuilder
    {
        public static ClientModel Build(int ClientId, DASEntities db)
        {
                //ClientModel model = new ClientModel();
                ClientModel model = db.Clients.Where(a => a.ClientId == ClientId).Select(a => new ClientModel() { ClientName = a.Name, Description = a.Description, Address = a.Address, ClientId = a.ClientId}).FirstOrDefault();
                model.Certificates = new List<CertModel>();

                IList<Certificate> certs = db.Certificates.Where(j => j.ClientId == ClientId).ToList();
                CertModel temp;
                foreach (var item in certs)
                {
                    temp = new CertModel() { CertId = item.CertificateId, CertName = item.CertificateName, Standard = item.Standard };
                    temp.Status = GetStatusName(db,item.StatusId);
                    temp.Statuses = BuildStatuses(db);
                    temp.StatusID = item.StatusId;

                    model.Certificates.Add(temp);
                    
                }
                return model;
            }




        public static string GetStatusName(DASEntities db, int statusId)
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

        public static IList<StatusModel> BuildStatuses(DASEntities db)
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

    }
    }


using DAS.Domain.Model;
using IniCore.Networking.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;


namespace DAS.UI.Mail {
    public class Mailer {

        private const string EmailWrapper = "<div style=\"font-family:Arial;font-size:11pt\">{0}</div>";

        public static bool Send(DASEntities db, ApplicationForm model)
        {
            int lngId = (int)HttpContext.Current.Session["lngId"];
            try {
             string ServerIP = WebConfigurationManager.AppSettings["MailServerIP"];
             string ServerUsername = WebConfigurationManager.AppSettings["MailServerUsername"];
             string ServerPassword = WebConfigurationManager.AppSettings["MailServerPassword"];
             int ServerPort = Int32.Parse(WebConfigurationManager.AppSettings["MailServerPort"]);
             string DefaultMailAddress = WebConfigurationManager.AppSettings["DefaultMailAddress"];
             string ReceiverMailAddress = model.Email;
             string ReceiverCCMailAddress = WebConfigurationManager.AppSettings["ReceiverMailAddress"];

             
            Postman postman = new Postman(ServerIP, ServerUsername, ServerPassword, ServerPort);

            string bodyText;
  
            if (lngId == 1) {
                bodyText = "Poštovani/a,<br/><br/>";
                bodyText += "Vaša aplikacija je primljena. Ponudu ćete dobiti u roku od 72h ili će vas kontaktirati neko iz DAS SEE kancelarije.<br/><br/>";
                bodyText += "S poštovanjem,<br/>";
                bodyText += "DAS SEE Office<br/>";
                bodyText += "office@das-see.com<br/>";
                bodyText += "www.das-see.com<br/>";
            }
            else if (lngId == 2)
            {
                bodyText = "Почитувани/а,<br/><br/>";
                bodyText += "Вашата апликација е примена. Ќе добиете понуда во рок од 72 часа или ќе ве контактират некој од канцеларијата на DAS SEE officе.<br/><br/>";
                bodyText += "Со почит,<br/>";
                bodyText += "DAS SEE Office<br/>";
                bodyText += "office@das-see.com<br/>";
                bodyText += "www.das-see.com<br/>";
            }
            else if (lngId == 3)
            {
                bodyText = "Poštovani/a,<br/><br/>";
                bodyText += "Vaša aplikacija je primljena. Ponudu ćete dobiti u roku od 72h ili će vas kontaktirati neko iz DAS SEE ureda.<br/><br/>";
                bodyText += "S poštovanjem,<br/>";
                bodyText += "DAS SEE Office<br/>";
                bodyText += "office@das-see.com<br/>";
                bodyText += "www.das-see.com<br/>";
          
            }
            else
            {
                bodyText = "Dear Sir/Madam,<br/><br/>";
                bodyText += "Your application is received. You will get an offer within 72 hours or you will be contacted by someone from the DAS SEE office.<br/><br/>";
                bodyText += "Best regards,<br/>";
                bodyText += "DAS SEE Office<br/>";
                bodyText += "office@das-see.com<br/>";
                bodyText += "www.das-see.com<br/>";
            }
           

            StringBuilder body = new StringBuilder(string.Format(EmailWrapper, bodyText)); //container for every mail

            postman.SetFrom(DefaultMailAddress);
            postman.AddToList(ReceiverMailAddress);
            postman.AddCC(ReceiverCCMailAddress);
   
  
            if (lngId == 1) {

                postman.Subject = "Zahtev za ponudu: " + model.CompanyName; 

            }
            else if (lngId == 2)
            {
                postman.Subject = "Барање за понуда: " + model.CompanyName;

            }
            else if (lngId == 3)
            {
                postman.Subject = "Zahtjev za ponudu: " + model.CompanyName;

            }
            else
            {
                postman.Subject = "Request for offer: " + model.CompanyName;

            }                
               
            postman.Body = body.ToString();
            
                postman.SendMail();
                return true;
            }
            catch (Exception) {
                return false;
                throw;
            }
           
           
        }


        internal static bool Send(DASEntities Db, Models.Application.ApplicationForm model)
        {
            throw new NotImplementedException();
        }
    }
}
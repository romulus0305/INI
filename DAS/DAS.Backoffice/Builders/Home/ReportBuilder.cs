using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.Words;
using DAS.Backoffice.Models.Application;

namespace DAS.Backoffice.Builders.Home
{
    public class ReportBuilder
    {
        public static Aspose.Words.Document Execute(string f, string path, ApplicationForm model)
        {
            Aspose.Words.Document dstDoc = new Aspose.Words.Document(path + @"Templates\Template_AppForm.doc");
            return Populate(dstDoc, path, model);
        }

        public static Aspose.Words.Document Populate(Aspose.Words.Document doc1, string path, ApplicationForm model)
        {

            DocumentBuilder b = new DocumentBuilder(doc1);

            b.PageSetup.PageStartingNumber = 1;
            b.PageSetup.PageNumberStyle = NumberStyle.Number;

            b.MoveToDocumentStart();


            b.MoveToMergeField("ISO1");
            b.InsertCheckBox("ISO9001", (bool)model.ISO9001,0);

            b.MoveToMergeField("ISO2");
            b.InsertCheckBox("ISO22301", (bool)model.ISO22301, 0);
  
            b.MoveToMergeField("ISO3");
            b.InsertCheckBox("ISO14001", (bool)model.ISO14001, 0);

            b.MoveToMergeField("ISO4");
            b.InsertCheckBox("BSOHSAS18001", (bool)model.BSOHSAS18001, 0);

            b.MoveToMergeField("ISO5");
            b.InsertCheckBox("ISO27001", (bool)model.ISO27001, 0);

            b.MoveToMergeField("OtherIso");
            b.InsertCheckBox("OtherIso", (bool)model.OtherIso, 0);

            b.MoveToMergeField("1");
            b.InsertCheckBox("1", (bool)model.ISO9001_2, 0);

            b.MoveToMergeField("2");
            b.InsertCheckBox("2", (bool)model.ISO22301_2, 0);

            b.MoveToMergeField("3");
            b.InsertCheckBox("3", (bool)model.ISO14001_2, 0);

            b.MoveToMergeField("4");
            b.InsertCheckBox("4", (bool)model.BSOHSAS18001_2, 0);

            b.MoveToMergeField("5");
            b.InsertCheckBox("5", (bool)model.ISO27001_2, 0);

            b.MoveToMergeField("6");
            b.InsertCheckBox("6", (bool)model.OtherIso_2, 0);



            b.MoveToMergeField("CompanyName");
            Aspose.Words.Font font = b.Font;
            font.Size = 14;
            font.Name = "Calibri";
            b.Write(model.CompanyName);

            b.MoveToMergeField("Address");
            b.Write(model.Adress);

            b.MoveToMergeField("Telephone");
            b.Write(model.Telephone);

            b.MoveToMergeField("Email");
            b.Write(model.Email);

            if(model.Extension != null){

                b.MoveToMergeField("Extension");
                b.Write(model.Extension);

            }

            if (model.Other != null)
            {
                b.MoveToMergeField("Other");
                b.Write(model.Other);
            }

            if (model.Other_2 != null)
            {
                b.MoveToMergeField("Other_2");
                b.Write(model.Other_2);
               
            }


            if (model.CompanyWebsite != null)
            {
                b.MoveToMergeField("CompanyWebsite");
                b.Write(model.CompanyWebsite);
            }

            if (model.PrimaryContactForAuditPurposes != null)
            {
                b.MoveToMergeField("PrimaryContactForAuditPurposes");
                b.Write(model.PrimaryContactForAuditPurposes);
            }
             
            if(model.PrimaryContactTelephone != null){
                b.MoveToMergeField("PrimaryContactTelephone");
                b.Write(model.PrimaryContactTelephone);
            
            }
            if (model.NatureOfBusiness != null)
            {
          
                b.MoveToMergeField("NatureOfBusiness");
                b.Write(model.NatureOfBusiness);
            }

            if (model.NumberOfYearsAtThisSite != null)
            {
                b.MoveToMergeField("NumberOfYearsAtThisSite");
                b.Write(model.NumberOfYearsAtThisSite);
            }

            if (model.ActivitiesOnClientsSites != null)
            {
                b.MoveToMergeField("ActivitiesOnClientsSites");
                b.Write(model.ActivitiesOnClientsSites);
                b.MoveToMergeField("yes");
                b.InsertCheckBox("yes", true, 0);
                b.MoveToMergeField("no");
                b.InsertCheckBox("yes", false, 0);
            }
            else {
                b.MoveToMergeField("yes");
                b.InsertCheckBox("yes", false, 0);
                b.MoveToMergeField("no");
                b.InsertCheckBox("yes", true, 0);
            }

            if (model.NameOfPresentCertificationBody != null)
            {
                b.MoveToMergeField("NameOfPresentCertificationBody");
                b.Write(model.NameOfPresentCertificationBody);
            }
            if (model.CertificateExpiryDate != null)
            {
                b.MoveToMergeField("CertificateExpiryDate");
                b.Write(model.CertificateExpiryDate);
            }

            if (model.ManagementRepresentativeName != null)
            {
                b.MoveToMergeField("ManagementRepresentativeName");
                b.Write(model.ManagementRepresentativeName);
            }
            if (model.JobTitle != null)
            {
                b.MoveToMergeField("JobTitle");
                b.Write(model.JobTitle);
            }

            if (model.NameOfConsultant != null)
            {
                b.MoveToMergeField("NameOfConsultant");
                b.Write(model.NameOfConsultant);
            }

            if (model.ConsultantTelephone != null)
            {
                b.MoveToMergeField("ConsultantTelephone");
                b.Write(model.ConsultantTelephone);
            }

            if (model.StandardTransferred != null){
                b.MoveToMergeField("StandardTransferred");
                b.Write(model.StandardTransferred);
            
            }
            if (model.DateNextCertificationBodyVisit != null)
            {
                b.MoveToMergeField("DateNextCertificationBodyVisit");
                b.Write(model.DateNextCertificationBodyVisit);
            }
            if(model.NumberOfLocations != null){
                b.MoveToMergeField("NumberOfLocations");
                b.Write(model.NumberOfLocations);
            
            }

            if (model.locationActivities.Count >0){


                foreach (var item in model.locationActivities)
                {
                    b.MoveToMergeField("location");
                    b.Write(item.location);
                    b.InsertParagraph();
                }
                foreach (var item in model.locationActivities)
                {

                    b.MoveToMergeField("activity");
                    b.Write(item.activity);
                    b.InsertParagraph();
                }
            
            }


            if (model.Categories.Count > 0)
            {


                foreach (var item in model.Categories)
                {

                    b.MoveToMergeField("Category");
                    if (item.Category != null)
                    {
                        b.Write(item.Category);
                        b.InsertParagraph();
                    }
           
                }
                foreach (var item in model.Categories)
                {
                    b.MoveToMergeField("TotalPermanent");
                    if (item.TotalPermanent != null)
                    {
                        b.Write(item.TotalPermanent);
                        b.InsertParagraph();
                    }
             
                }
                foreach (var item in model.Categories)
                {
                    b.MoveToMergeField("TotalTemporary");
                    if (item.TotalTemporary != null)
                    {
                        b.Write(item.TotalTemporary);
                        b.InsertParagraph();

                    }
                }
                
            }

            if (model.TotalPermanent != null)
            {
                b.MoveToMergeField("TotalP");
                b.Write(model.TotalPermanent);
            }


            if (model.TotalTemporary != null)
            {
                b.MoveToMergeField("TotalT");
                b.Write(model.TotalTemporary);
            }

            b.MoveToDocumentEnd();
            doc1.MailMerge.DeleteFields();
            



            if (model.ISO22301 == true || model.ISO9001 == true)
            {
                Aspose.Words.Document standardDoc = new Aspose.Words.Document(path + @"Templates\ISO_9001_22301_Template.doc");
                doc1.AppendDocument(standardDoc, ImportFormatMode.KeepSourceFormatting);
            }
            if (model.ISO14001==true)
            {
                Aspose.Words.Document standardDoc = new Aspose.Words.Document(path + @"Templates\ISO_14001_Template.doc");
                doc1.AppendDocument(standardDoc, ImportFormatMode.KeepSourceFormatting);
            }
            if (model.BSOHSAS18001 == true)
            {
                Aspose.Words.Document standardDoc = new Aspose.Words.Document(path + @"Templates\BS_OHSAS_1800_Template.doc");
                doc1.AppendDocument(standardDoc, ImportFormatMode.KeepSourceFormatting);
            }

            if (model.ISO27001 == true)
            {
                Aspose.Words.Document standardDoc = new Aspose.Words.Document(path + @"Templates\ISO27001_Template.doc");
                doc1.AppendDocument(standardDoc, ImportFormatMode.KeepSourceFormatting);
            }

         

            return doc1;
        }
    }
}
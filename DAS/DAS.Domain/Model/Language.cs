//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAS.Domain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Language
    {
        public Language()
        {
            this.Documents = new HashSet<Document>();
            this.Labels = new HashSet<Label>();
            this.News = new HashSet<News>();
            this.Status_Lng = new HashSet<Status_Lng>();
        }
    
        public int LanguageId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Status_Lng> Status_Lng { get; set; }
    }
}

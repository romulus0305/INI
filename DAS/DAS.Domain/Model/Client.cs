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
    
    public partial class Client
    {
        public Client()
        {
            this.Certificates = new HashSet<Certificate>();
        }
    
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Ord { get; set; }
        public Nullable<System.DateTime> DateChange { get; set; }
    
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}

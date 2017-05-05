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
    
    public partial class News
    {
        public News()
        {
            this.Archives = new HashSet<Archive>();
        }
    
        public int NewsId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Year { get; set; }
        public int Ord { get; set; }
        public int LanguageId { get; set; }
        public bool Archive { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
    }
}
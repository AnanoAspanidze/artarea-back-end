//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtareaNew.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blogpost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blogpost()
        {
            this.BlogpostTranslates = new HashSet<BlogpostTranslate>();
        }
    
        public int Id { get; set; }
        public string Photo { get; set; }
        public int Authorid { get; set; }
        public System.DateTime Createdate { get; set; }
    
        public virtual Author Author { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogpostTranslate> BlogpostTranslates { get; set; }
    }
}
